using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TasksDb"));
builder.Services.AddDbContext<TasksContext>(options => options.UseNpgsql(connection));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconnection", async ([FromServices] TasksContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok($"Database in memory {dbContext.Database.IsInMemory()}");
});

app.MapGet("/api/tareas", async ([FromServices] TasksContext dbContext) =>
{
  return Results.Ok(dbContext.Tasks.Include(p => p.Category));
});

app.MapPost("/api/tareas", async ([FromServices] TasksContext dbContext, [FromBody] projectef.Models.Task task) =>
{
  task.TaskId = Guid.NewGuid();
  task.CreationDate = DateTime.Now;
  await dbContext.Tasks.AddAsync(task);
  await dbContext.SaveChangesAsync();

  return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TasksContext dbContext, [FromBody] projectef.Models.Task task, [FromRoute] Guid id) =>
{
  var currentTask = dbContext.Tasks.Find(id);

  if (currentTask != null)
  {
    currentTask.CategoryId = task.CategoryId;
    currentTask.Title = task.Title;
    currentTask.TaskPriority = task.TaskPriority;
    currentTask.Description = task.Description;

    await dbContext.SaveChangesAsync();
    return Results.Ok();
  }
  return Results.NotFound();
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TasksContext dbContext, [FromRoute] Guid id) =>
{
  var currentTask = dbContext.Tasks.Find(id);

  if (currentTask != null)
  {
    dbContext.Remove(currentTask);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
  }

  return Results.NotFound();
});

app.Run();
