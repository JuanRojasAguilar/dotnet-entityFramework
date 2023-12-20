using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef;

public class TasksContext: DbContext
{
  public DbSet<Category> Categories {get;set;}
  public DbSet<Models.Task> Tasks {get; set;}
  public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<Category> categoryInit = new List<Category>();

    categoryInit.Add(new Category()
    {
      CategoryId = Guid.Parse("7555a122-8f47-42bf-a9ee-6a6a38ca99f8"),
      Name = "Pendient Categories",
      Difficulty = 20
    });

    categoryInit.Add(new Category()
    {
      CategoryId = Guid.Parse("ab74fad2-280c-438f-8341-afc117539c09"),
      Name = "Personal Categories",
      Difficulty = 50
    });

    modelBuilder.Entity<Category>(category =>
    {
      category.ToTable("Category");
      category.HasKey(p => p.CategoryId);

      category.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(150);
      category.Property(p => p.Description).IsRequired(false);
      category.Property(p => p.Difficulty);

      category.HasData(categoryInit);
    });

    List<Models.Task> taskInit = new List<Models.Task>();

    taskInit.Add(new Models.Task()
    {
      TaskId = Guid.Parse("f01b5a99-7b59-477b-899f-efce65d57366"),
      CategoryId = Guid.Parse("ab74fad2-280c-438f-8341-afc117539c09"),
      TaskPriority = Priority.Mid,
      Title = "Pay taxes",
      CreationDate = DateTime.Now,
    });

    taskInit.Add(new Models.Task()
    {
      TaskId = Guid.Parse("f01b5a99-7b59-477b-899f-efce65d573a5"),
      CategoryId = Guid.Parse("7555a122-8f47-42bf-a9ee-6a6a38ca99f8"),
      TaskPriority = Priority.Low,
      Title = "Do Excercise",
      CreationDate = DateTime.Now
    });

    modelBuilder.Entity<Models.Task>(task =>
    {
      task.ToTable("Task");
      task.HasKey(p => p.TaskId);
      task.HasOne(p => p.Category)
        .WithMany(p => p.Tasks)
        .HasForeignKey(p => p.CategoryId);

      task.Property(p => p.Title)
        .IsRequired()
        .HasMaxLength(200);
      task.Property(p => p.Description).IsRequired(false);
      task.Property(p => p.TaskPriority);
      task.Property(p => p.CreationDate);
      task.Ignore(p => p.Resume);

      task.HasData(taskInit);
    });
  }
}