using EmployeeManagement.Api.GlobalException;
using EmployeeManagement.Business;
using EmployeeManagement.Persistence.IRepository;
using EmployeeManagement.Persistence.Models;
using EmployeeManagement.Persistence.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "JWTAuthenticationServer",
            ValidAudience = "JWTServicePostmanClient",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("erdf7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs05hri")),
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
//filters
//builder.Services.AddMvc(options =>
//{
//    options.Filters.Add(typeof(GlobalExceptionalFilters));
//});
builder.Services.AddDbContext<DbEmployeeManagementContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("mvcConnection")));
//DI Container
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(EmployeeManager));
builder.Services.AddScoped(typeof(DepartmentManager));
builder.Services.AddScoped(typeof(DesignationManager));
builder.Services.AddCors();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "EmployeeManagement",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseMiddleware<GlobalException>();
app.UseAuthorization();
app.UseCors("EmployeeManagement");
app.MapControllers();
app.Run();