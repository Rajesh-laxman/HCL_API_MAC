/* OWNER : RAJESHWAR L
   GITHUB: https://github.com/Rajesh-laxman/HCL_API_MAC
   MAC   : /Users/rajeshwarl/Desktop/RL_FILES/csharpProject/HCL_TECH_WEB-API/CLONED HCL_API/HCL_API_MAC/HCL_API */


using HCL_API;
using HCL_API.DB_CONTEXT;
using HCL_API.MAPPINGS;
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
//builder.Services.AddScoped<IRegionRepository, mango_db_repository>();
builder.Services.AddAutoMapper(typeof(AUTO_MAPPER));
builder.Services.AddTransient<Custom_middleware_1>();

var app = builder.Build();   //insatance of this webapplication

/* configure method */
// Configure the HTTP request pipeline.

//exception handling
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
//app.Use(async context => await context.respone.);



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


/* ADDITIONAL */
app.Use(async (context, next) => {
    await context.Response.WriteAsync("\nUSE METHOD CALLED");
    await next();
    await context.Response.WriteAsync("\nUSE METHOD CALLED_2");
});

app.Map("/raju",map_method_1);
void map_method_1(IApplicationBuilder app)
{
    app.Use(async (context,next) =>
    {
        await context.Response.WriteAsync("\nRAJU MAP METHOD CALLED");
        await next();
    });
}

app.UseMiddleware<Custom_middleware_1>();
app.Run(async ( context) => { await context.Response.WriteAsync("\nRUN METHOD CALLED");
});

app.Run();

