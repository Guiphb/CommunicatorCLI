using CommunicatorCLI.API.Builder;
using CommunicatorCLI.API.Infrastructure;
using CommunicatorCLI.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.WebSockets;

namespace CommunicatorCLI.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) { }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebSocketCommunication();
            services.AddCors(opt => opt.AddDefaultPolicy(p => p.AllowAnyOrigin()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseCors();
            app.UseWebSocketCommunication(new BusinessOptions(){ Path =  "/ws" });

            app.UseStaticFiles();
        }
    }
}
