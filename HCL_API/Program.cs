


/*
 OWNER : RAJESHWAR L
 GITHUB:https://github.com/Rajesh-laxman/HCL_API_MAC
 MAC   :/Users/rajeshwarl/Desktop/RL_FILES/csharpProject/HCL_TECH_WEB-API/CLONED HCL_API/HCL_API_MAC/HCL_API
 */
try { }
catch { }
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

