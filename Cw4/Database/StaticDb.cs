using Cw4.Models;

namespace Cw4.Database;

public class StaticDb
{
    public static List<Animal> Animals { get; } = new List<Animal>();
    public static List<AnimalVisit> AnimalVisits { get; } = new List<AnimalVisit>();

    public static Animal? SelectAnimal(int id)
    {
        Animal? animal = Animals.Find(x => x.Id == id);
        return animal;
    }

    public static bool CreateAnimal(Animal animal)
    {
        var foundAnimal = Animals.Find(x => x.Id == animal.Id);
        if (foundAnimal != null) return false;

        Animals.Add(animal);
        return true;
    }

    public static bool UpdateAnimal(Animal animal)
    {
        var animalIndex = Animals.FindIndex(x => x.Id == animal.Id);
        if (animalIndex == -1) return false;

        Animals[animalIndex] = animal;
        return true;
    }

    public static bool DeleteAnimal(int id)
    {
        var animalIndex = Animals.FindIndex(x => x.Id == id);
        if (animalIndex == -1) return false;
        Animals.RemoveAt(animalIndex);
        return true;
    }
}