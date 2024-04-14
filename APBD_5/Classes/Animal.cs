namespace APBD_5.Classes;

public enum Category
{
    Cat,
    Dog,
    Rodent
}

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; } 
    public float Mass { get; set; }
    public string FurColor { get; set; }
}