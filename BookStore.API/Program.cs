using BookStore.API;
using BookStore.API.Data;
using BookStore.API.Repositories;
using Microsoft.EntityFrameworkCore;

CreateHostBuilder(args).Build().Run();


static IHostBuilder CreateHostBuilder(string[] args) =>
Host.CreateDefaultBuilder(args)
       .ConfigureWebHostDefaults(webHost => {

           webHost.UseStartup<Startup>();

       });
