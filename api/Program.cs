using api;
using api.AppUserIdentity;
using api.Courses.Repository;
using api.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext para PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configura o Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false; // numeros obrigatorios na senha
    options.Password.RequireLowercase = false; // letras minusculas obrigatorias na senha
    options.Password.RequireUppercase = false; // letras maiusculas obrigatorias na senha
    options.Password.RequireNonAlphanumeric = false; // caracteres especiais obrigatorios na senha
    options.Password.RequiredLength = 5; // tamanho minimo da senha
}).AddEntityFrameworkStores<ApplicationDbContext>();

//Configura o JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // valida a chave de assinatura do token 
        ValidIssuer = builder.Configuration["JWT:Issuer"], // emissor do token
        ValidateAudience = true, // valida o publico do token
        ValidAudience = builder.Configuration["JWT:Audience"], // audiencia do token
        ValidateIssuerSigningKey = true, // valida a chave de assinatura do token
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(
                builder.Configuration["JWT:SigningKey"] // chave de assinatura do token
            )
        )
    };
});

builder.Services.AddAuthorization();
builder.Services.AddControllers(); //chama controllers
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Habilita a autenticação
app.UseAuthorization(); // Habilita a autorização
app.MapControllers(); // Habilita chamada dos controllers

app.Run();