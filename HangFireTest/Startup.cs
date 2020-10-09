using System;
using Hangfire;
using Hangfire.PostgreSql;
using HangFireTest.Process;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HangFireTest
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(x => x.UsePostgreSqlStorage("Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=postgres;"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Teste - HangFire (Ueverson Pedroso)");
            });

            InitProcess();
        }

        private void InitProcess()
        {
            var division = new Division();
            RecurringJob.AddOrUpdate(() => division.DivisionRandom(), Cron.Hourly);

            var verification = new VerificationNumber();
            BackgroundJob.Schedule(() => verification.GerandoValorNumerico(), TimeSpan.FromMinutes(20));

        }
    }
}

