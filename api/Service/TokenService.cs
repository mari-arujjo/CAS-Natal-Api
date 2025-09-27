using api.AppUserIdentity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;


namespace api.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config; // armazena a configuração do sistema (info vem de appsettings.json)
        private readonly SymmetricSecurityKey _key; // guarda a chave de segurança usada para assinar e validar os tokens JWT
        public TokenService(IConfiguration config)
        {
            _config = config; // injeção de dependência
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"])); // lê do appsettings.json a chave de assinatura do token
            // 1 - converte a chave string em um array de bytes
            // 2 - cria a instancia de SymmetricSecurityKey com os bytes
            // será utilizado depois na hora de gerar p tken!!
        }

        public string CreateToken(AppUser user)
        {
            // as claims pares chave/valor que descrevem algo sobre o usuário. Elas podem conter a sua role, seu email, seu username e mais informações.
            // elas ficam dentro do proprio JWT, logo, não há necessidade de ir buscar a informação no banco, sendo um meio de verificação mais flexível e rápido.
            var claims = new List<Claim>
            {
               new Claim(JwtRegisteredClaimNames.Email, user.Email),
               new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims), // as claims do usuario
                Expires = DateTime.Now.AddDays(7), // tempo de expiração do token
                SigningCredentials = creds, // as credenciais de assinatura do token
                Issuer = _config["JWT:Issuer"], // emissor do token
                Audience = _config["JWT:Audience"] // audiencia do token
            };

            var tokenHandler = new JwtSecurityTokenHandler(); // CRIA O TOKEN
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
