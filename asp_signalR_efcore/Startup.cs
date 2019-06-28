using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using asp_signalR_efcore.Hubs;
using asp_signalR_efcore.Models;
using asp_signalR_efcore.Services;

namespace asp_signalR_efcore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            // mvc模式添加
            services.AddMvc();

            //services.AddDbContextPool<MyContext>((opts) => { opts.UseMySQL(Configuration.GetConnectionString("MySql")); });
            // 配置mysql
            // 注意mysql.data.entityframeworkcore中有efcore
            // 如果在nuget中引用了efcore可能导致meth not find 错误。
            var mysql = "server=localhost;port=3306;database=mydb;uid=root;password=123456;CharSet=utf8;SslMode=none;Convert Zero Datetime=True; ";
            services.AddDbContextPool<MyContext>((opts) => { opts.UseMySQL(mysql); });

            // SignalR添加
            services.AddSignalR();

            // self services
            services.AddSingleton<IMyServices,MyServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc();
            app.UseSignalR(configure=> {
                configure.MapHub<MyHub>("/myhub");
            });
        }
    }
}
