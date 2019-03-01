using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using WebApiQuiz.Models;
using Swashbuckle.AspNetCore.Swagger;
using WebApiQuiz.Repository;
using WebApiQuiz.Service;

namespace WebApiQuiz
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IQuestionsRepository,QuestionsRepository>();            
            services.AddScoped<IQuizCategoryRepository,QuizCategoryRepository>();  
            services.AddScoped<IQuizOptionRepository,QuizOptionRepository>();  
            services.AddScoped<IQuizService,QuizService>();

            services.AddDbContext<DBContext>(Con=> Con.UseSqlServer(Configuration["ConnectionString:TrainingDB"]));
            services.AddSwaggerGen(c=>{
                c.SwaggerDoc("v1",new Info(){
                     Version = "v1",
                    Title = "Quiz API",
                    Description = "Quiz API",
                    License =new License(){
                        Name = "Kgisl",
                        Url="Google.com"
                    }
                });
            });

            services.AddCors(opt =>{
                opt.AddPolicy("ngCrosPolicy",
                             Builder=>Builder
                                .WithOrigins("http://localhost:4200")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                );
                                }
            );
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }           

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            // Shows UseCors with named policy. Globally
           // app.UseCros("ngCrosPolicy");
             app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quiz API");
            });
        }
    }
}
