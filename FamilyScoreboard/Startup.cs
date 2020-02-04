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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FamilyScoreboard.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Net.Http;

namespace FamilyScoreboard {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<FamilyScoreboardContext>(opt => opt.UseSqlite(Configuration.GetConnectionString("Sqlite")));
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<FamilyMemeberValidator>());
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTransient(ctx => {
                var client = new HttpClient() {
                    BaseAddress = new Uri("http://localhost/familyscoreboard/api/")
                };
                return client;
            });

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "Family Scoreboard API",
                    Description = "",
                    Contact = new OpenApiContact() {
                        Name = "God",
                        Email = "God@heaven.com",
                        Url = new Uri("http://www.IReallyHopeYouGetThisThisIsFakeContactInfo.net")
                    },
                    License = new OpenApiLicense {
                        Name = "MIT",
                        Url = new Uri("https://github.com/Mikesnorth/FamilyScoreboard/blob/master/LICENSE")
                    },
                });

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Family Scoreboard V1");
            });

        }
    }
}
