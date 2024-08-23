using ToDoApp.Domain.Interface;
using ToDoApp.Infrastructure.Data;
using ToDoApp.Infrastructure.Repositories;
using ToDoApp.Application.Commands.CreateToDoItemCommand;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Controllers
builder.Services.AddControllers();

// Register MediatR services from assemblies
builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssemblies(new[]
    {
        typeof(Program).Assembly, // This is your API assembly
        typeof(CreateToDoItemCommandHandler).Assembly // This is the assembly containing your MediatR handlers
    });
});

// Register the in-memory DbContext and repository
builder.Services.AddSingleton<ToDoAppDbContext>(); // Use Singleton since it's in-memory
builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();

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
