using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.NetworkInformation;

namespace api
{
    [ApiController]
    [Route("CASNatal/health")]
    public class HealthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public HealthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("database")]
        public IActionResult DbIsConnected()
        {
            try
            {
                if (_context.Database.CanConnect()) return Ok("Connected to the database successfully.");
                
                return StatusCode(500, "Could not connect to the database");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Could not connect to the database: {ex.Message}");
            }
        }

        [HttpGet("maxConnections")]
        public IActionResult GetMaxConnections()
        {
            try
            {
                using var connection = _context.Database.GetDbConnection();
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = "SHOW max_connections";
                var result = command.ExecuteScalar();
                connection.Close();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Error retrieving max connections: {e.Message}");
            }
        }

        [HttpGet("activeConnections")]
        public IActionResult GetActiveConnections()
        {
            try
            {
                using var connection = _context.Database.GetDbConnection();
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = "SELECT pid, usename, datname, client_addr::text, state, backend_start FROM pg_stat_activity WHERE state = 'active'";
                var resultList = new List<object>();
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    resultList.Add(new
                    {
                        pid = reader["pid"],
                        usename = reader["usename"],
                        datname = reader["datname"],
                        client_addr = reader["client_addr"],
                        state = reader["state"],
                        backend_start = reader["backend_start"],
                    });
                }
                connection.Close();
                return Ok(resultList);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Error retrieving active connections: {e.Message}");
            }
        }

    }
}
