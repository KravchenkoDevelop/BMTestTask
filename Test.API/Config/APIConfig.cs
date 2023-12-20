using System.Text.Json;
using System.Text.Json.Serialization;
using Test.API.Helpers;

namespace Test.API
{
    public static class APIConfig
    {
        public static void ApiSettings(this IServiceCollection services)
        {
            services.AddLogging();
            services.AddMvcCore().AddApiExplorer();

            services.AddControllers().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                o.JsonSerializerOptions.Converters.Add(new CustomDatetimeConverter());
                o.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddEndpointsApiExplorer();
        }

        public static void ApiRuntime(this IApplicationBuilder app)
        {
            app.UseStatusCodePages();
            app.UseDefaultFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
