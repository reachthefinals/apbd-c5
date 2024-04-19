namespace Cw4.Models;

public class NewAnimalVisit
{
    public DateTime visitDate { get; set; }
    public int animalId { get; set; }
    public string visitDescription { get; set; }
    public double visitCost { get; set; }
}