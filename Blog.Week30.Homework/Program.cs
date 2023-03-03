using Blog.Week30.Homework.Data;
using Blog.Week30.Homework.Repository.Abstractions;
using Blog.Week30.Homework.Repository.Implementations;
using Blog.Week30.Homework.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(
       System.IO.Path.Combine("/Users/kamranimranli/desktop", "LogFiles", "Application", "diagnostics.txt"),
       rollingInterval: RollingInterval.Day,
       fileSizeLimitBytes: 10 * 1024 * 1024,
       retainedFileCountLimit: 2,
       rollOnFileSizeLimit: true,
       shared: true,
       flushToDiskInterval: TimeSpan.FromSeconds(1))
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog(); // <-- Add this line

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
    builder.Services.AddTransient<IBlogRepository, BlogRepository>();
    builder.Services.AddTransient<IPostRepository, PostRepository>();
    builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
    builder.Services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

    var app = builder.Build();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
