namespace Cw4.Models;

public enum FurColor
{
    Orange,
    Tabby,
    White,
    Black,
    Gray,
    Tricolor
}

public enum Species
{
    Cat,
    Dog,
    Mouse,
    Hamster,
    GuineaPig,
    Parrot
}

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Species Category { get; set; }
    public double Mass { get; set; }
    public FurColor FurColor { get; set; }
}