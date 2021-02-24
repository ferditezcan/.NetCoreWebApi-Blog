using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Bussines.Abstract;
using Blog.Bussines.Concrete;
using Blog.DataAccess.Abstract;
using Blog.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blog.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddControllers();
            services.AddSingleton<IHotelService, HotelManager>();
            services.AddSingleton<IHotelRepository, HotelRepository>();

            services.AddSingleton<IPostService, PostManager>();
            services.AddSingleton<IPostRepository, PostRepository>();

            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddSwaggerDocument(config => {
                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "Ferdi Api";
                    doc.Info.Version = "1.0.0";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Ferdi Tezcan",
                        Url = "http://www.ferditezcan.cf",
                        Email = "tzcnferdi@gmail.com"
                    };
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();
       
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
