namespace APBD_5.Classes;

public interface IMockDatabase
{
    public ICollection<Animal> GetAllAnimals();
    public bool AddAnimal(Animal animal);
    public Animal? GetAnimalDetails(int id);
    public Animal? RemoveAnimal(int id);

    public ICollection<Appointment> GetAppointmentsRelatedToAnimal(int id);
    public bool AddAppointment(string date, int id, string description, int price);
}

public class MockDatabase : IMockDatabase
{
    private ICollection<Animal> _animals;
    private ICollection<Appointment> _appointments;

    public MockDatabase()
    {
        _animals = new List<Animal>
        {
            new Animal()
            {
                Category = Category.Cat,
                FurColor = "Orange",
                Id = 1,
                Mass = 5.5f,
                Name = "Maciej"
            },
            
            new Animal()
            {
                Category = Category.Dog,
                FurColor = "Beige",
                Id = 2,
                Mass = 15,
                Name = "Rex"
            }
        };

        _appointments = new List<Appointment>()
        {
            new Appointment()
            {
                Date = DateTime.Today,
                Animal = _animals.FirstOrDefault(a => a.Id == 1),
                Description = "Wizyta kontrolna",
                Price = 250
            }
        };
    }

    public ICollection<Animal> GetAllAnimals()
    {
        return _animals;
    }

    public bool AddAnimal(Animal animal)
    {
        _animals.Add(animal);
        return true;
    }

    public Animal? GetAnimalDetails(int id)
    {
        return _animals.FirstOrDefault(a => a.Id == id);
    }

    public Animal? RemoveAnimal(int id)
    {
        var animalToBeRemoved = _animals.FirstOrDefault(a => a.Id == id);
        if (animalToBeRemoved is null)
            return null;
        _animals.Remove(animalToBeRemoved);
        return animalToBeRemoved;
    }

    public ICollection<Appointment> GetAppointmentsRelatedToAnimal(int id)
    {
        var result = new List<Appointment>();
        foreach (var appointment in _appointments)
        {
            if (appointment.Animal.Id == id)
            {
                result.Add(appointment);
            }
        }

        return result;
    }

    public bool AddAppointment(string date, int id, string description, int price)
    {
        var targetAnimal = _animals.FirstOrDefault(a => a.Id == id);
        if (targetAnimal is null)
        {
            return false;
        }
        
        _appointments.Add(new Appointment()
            {
                Date = DateTime.Parse(date),
                Animal = targetAnimal,
                Description = description,
                Price = price
            }
        );
        return true;
    }
}