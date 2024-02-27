using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using WpfApi.MyDbContext;
using WpfApi.Service;
using WpfApi.Serviceinfo;
using WpfApiJT.Extensions;
using WpfApiJT.Service;
using WpfApiJT.Serviceinfo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ToDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("BookConn"));
}).AddUnitOfWork<ToDbContext>();

builder.Services.AddTransient<IToDoService, ToDoService>();
builder.Services.AddTransient<IMemoService, MemoService>();

//×¢²áAutoMapper·þÎñ
builder.Services.AddAutoMapper(typeof(AutoMapperProFile));

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
