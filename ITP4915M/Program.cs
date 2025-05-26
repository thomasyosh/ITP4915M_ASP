    using Microsoft.AspNetCore.Authentication;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using MySqlConnector;

    public class Program {
    private static void Main (string [] args) {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.

        builder.Services.AddControllers();
        // builder.Services.AddDbContext<DataContext>(options =>
        // {
        //     var ConnString = Environment.GetEnvironmentVariable("ConnectionString");
        //     options.UseMySql(
        //         ConnString,
        //         ServerVersion.AutoDetect(ConnString)
        //     );
        // });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(Environment.GetEnvironmentVariable("Token"))),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}



