
using MeteoApi.Services;
using MeteoApi.Services.City;
using MeteoApi.Services.Interfaces;

namespace MeteoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            builder.Services.AddControllers();
            builder.Services.AddTransient<IWeatherApiConnect, WeatherApiConnect>();
            builder.Services.AddTransient<IPresentDayForecastService, PresentDayForecastService>();
            builder.Services.AddTransient<ICitiesJsonService, CitiesJsonService>();
            builder.Services.AddTransient<ICityCollectionService, CityCollectionService>();
            builder.Services.AddTransient<IFiveDaysForecastService, FiveDaysForecastService>();
            builder.Services.AddTransient<IFilesOperationService, FilesOperationService>();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
           
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}