    using Microsoft.AspNetCore.Authentication;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using MySqlConnector;
    using ITP4915M.Data;
    using ITP4915M.Helpers.File;
    using ITP4915M.Helpers.Extension;
    using ITP4915M.AppLogic.Exceptions;
    using ITP4915M.Helpers.LogHelper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.Filters;

    public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddControllers()
            .AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        builder.Services.AddDbContext<DataContext>(options =>
        {
            var ConnString = Environment.GetEnvironmentVariable("ConnectionString");
            options.UseMySql(
                ConnString,
                ServerVersion.AutoDetect(ConnString)
            );
        });

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
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Auth using the bearer",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
        builder.Services.AddCors(
            options =>
            {
                options.AddPolicy("default",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            }
        );
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.UseCors("default");
        Console.Title = "The Better Limited Server";

        string ConnStringParts = Environment.GetEnvironmentVariable("ConnectionString");
        using (var conn = new MySqlConnection(ConnStringParts))
        {
            try // test the connection with sql server
            {
                conn.Open();
            }
            catch (MySqlException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Timeout: {conn.ConnectionTimeout}s\nError occur during create a connection with MySQL server");
                Console.WriteLine("\t-Make sure you start the MySQL server");
                Console.WriteLine("\t-Make sure your connection string is correct");
                Console.WriteLine("\t-Make sure you have the right permissions");
                return;
            }
            finally
            {
                conn.Close();
                Console.ResetColor();
            }
        }

        ConsoleLogger.Debug("Version");

        app.Run();

        TempFileManager.CloseAllTempFile();
        ITP4915M.Helpers.File.PDFFactory.Instance.Dispose();
    }
}