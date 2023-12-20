using System.Text.Json.Serialization;

namespace projectef.Models;

public class Task
{
  //[Key]
  public Guid TaskId {get; set;}

  //[ForeignKey("CategoryId")]
  public Guid CategoryId {get; set;}

  //[Required]
  //[MaxLength(200)]
  public string Title {get; set;}
  public string Description {get; set;}
  public Priority TaskPriority {get; set;}
  public DateTime CreationDate {get; set;}
  public virtual Category Category {get; set;}

  //[NotMapped]
  [JsonIgnore]
  public string Resume {get; set;}
}

public enum Priority
{
  Low,
  Mid,
  High
}
