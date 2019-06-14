using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using weatherappapi.ApiClients;
using weatherappapi.mapping;
using weatherappapi.models;
using weatherappapi.ApiCalls;

namespace weatherappapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional:false, reloadOnChange:false)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional:true)
            .AddEnvironmentVariables();
            configuration = builder.Build();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("corspolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());
            });

            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new CityModelMappingProfile());
                mc.AddProfile(new CurrentWeatherMappingProfile());
                mc.AddProfile(new WeatherForecastMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
            // services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();
            services.AddTransient<ILocationsRepository, LocationsRepository>();
            services.AddSingleton<IAppSettingsWrapper, AppSettingsWrapper>();
            services.AddSingleton<IWeatherApiCallFactory, WeatherApiCallFactory>();
            services.AddTransient<IWeatherApiClient, AerisWeatherApiClient>();
            services.Configure<AppSettings>(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0.1", new Info { Title = "WeatherApp API", Version = "v0.1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseCors("corspolicy");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v0.1/swagger.json", "WeatherApp API v0.1");
            });

            app.UseMvc();
        }
    }
}
