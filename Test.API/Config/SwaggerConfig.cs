using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace Test.API
{
    public static class SwaggerConfig
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {   
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc($"v{Assembly.GetExecutingAssembly().GetName().Version.Major}", new OpenApiInfo
                {
                    Title = "TestTask API",
                    Version = $"v{Assembly.GetExecutingAssembly().GetName().Version.Major}",
                    Description = "Brand Monitor Test Task",
                    Contact = new OpenApiContact
                    {
                        Name = "Tatiana Kravchenko",
                        Email = "kravchenkodevelop@gmail.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License"
                    }
                });

                c.ResolveConflictingActions(apidescription => apidescription.First());
                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();
                c.CustomSchemaIds(t => t.FullName);
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
        }

        public static void SwaggerAppConfig(this IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            app.UseSwagger(o =>
            {
                o.RouteTemplate = "api-docs/{documentName}/swagger.json";
                o.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(o =>
            {
                o.DocumentTitle = "TestTask API";
                o.RoutePrefix = "api-docs";
                o.SwaggerEndpoint("../api-docs/v1/swagger.json", $"Test API v1");
            });
        }
    }
}
