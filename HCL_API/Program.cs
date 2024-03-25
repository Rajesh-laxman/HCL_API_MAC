/* OWNER : RAJESHWAR L
   GITHUB: https://github.com/Rajesh-laxman/HCL_API_MAC
   MAC   : /Users/rajeshwarl/Desktop/RL_FILES/csharpProject/HCL_TECH_WEB-API/CLONED HCL_API/HCL_API_MAC/HCL_API */


using HCL_API.DB_CONTEXT;
using HCL_API.REPOSITORIES;
using Microsoft.EntityFrameworkCore;

/* START_UP_CLASS */
var builder = WebApplication.CreateBuilder(args);
/* var builder_old = WebApplication.CreateBuilder(args).Build(); old version  */

/* configure services */
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*DB_CONTEXT*/
/* 4.2.ADD dbcontext in configure serive */
builder.Services.AddDbContext<HCL_DB_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HCL_API_CONECTION_STRING")));
/* 5.ADD Migrations */
/* 6.ADD CONTROLLERS */

builder.Services.AddScoped<IRegionRepository, Sql_Region_Repository>();



var app = builder.Build();   //insatance of this webapplication

/* configure method */
// Configure the HTTP request pipeline.

//exception handling
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
