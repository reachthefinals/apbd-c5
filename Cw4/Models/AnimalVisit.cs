namespace Cw4.Models;

public class AnimalVisit
{
    public DateTime visitDate { get; set; }
    public Animal animal { get; set; }
    public string visitDescription { get; set; }
    public double visitCost { get; set; }
}