using car;

public class Car
{
    private string _name;
    private int _year;
    private double _speed;
    public Car(string name, int year, double speed)
    {
        _name = name;
        _year = year;
        _speed = speed;
    }
    public string Name { get => _name; }
    public int ProductionYear { get => _year; }
    public double MaxSpeed { get => _speed; }
}
public class CarCatalog
{
    private Car[] garage;
    public CarCatalog(Car[] garage) 
    { 
    this.garage = garage;
    }
    public IEnumerator<Car> GetEnumerator()
    {
        for (int i = 0; i < garage.Length; i++)
        {
            yield return garage[i];
        }
    }
    public IEnumerable<Car> Reverse()
    {
        for (int i = garage.Length  - 1; i >= 0; i--)
        {
            yield return garage[i];
        }
    }

    public IEnumerable<Car> GetCarByYear(int productionYear)
    {
        // Проход по элементам массива с фильтром по году выпуска
        foreach (Car car in garage)
        {
            if (car.ProductionYear == productionYear)
            {
                yield return car;
            }
        }
    }

    public IEnumerable<Car> GetCarByMaxSpeed(double speed)
    {
        foreach(Car car in garage)
        {
            if(car.MaxSpeed == speed)
            {
                yield return car;
            }
        }
    }
}
//public class Program
//{
//    static void Main(string[] args)
//    {
//        Car[] garage = { new Car("BMW", 2022, 320), new Car("Lexus", 2023, 290), new Car("Maseraty", 2020, 400) };
        
//        CarCatalog catalog = new CarCatalog(garage);


//        Console.WriteLine("Simple: ");
//        foreach (var car in catalog)
//        {
//            Console.WriteLine($"Name: {car.Name}, Year Production: {car.ProductionYear}, Max Speed: {car.MaxSpeed}");
//        }
//        Console.WriteLine();


//        Console.WriteLine("Reverse: ");
//        foreach (var car in catalog.Reverse())
//        {
//            Console.WriteLine($"Name: {car.Name}, Year Production: {car.ProductionYear}, Max Speed: {car.MaxSpeed}");
//        }
//        Console.WriteLine();


//        Console.WriteLine("Сhoose year for filter, please: ");
//        int year = int.Parse(Console.ReadLine());
//        Console.WriteLine("Year filter:");
//        foreach (var car in catalog.GetCarByYear(year))
//        {
//            Console.WriteLine($"Name: {car.Name}, Year Production: {car.ProductionYear}, Max Speed: {car.MaxSpeed}");
//        }
//        Console.WriteLine();


//        Console.WriteLine("Сhoose speed for filter, please: ");
//        int speed = int.Parse(Console.ReadLine());
//        Console.WriteLine("Speed filter:");
//        foreach (var car in catalog.GetCarByMaxSpeed(speed))
//        {
//            Console.WriteLine($"Name: {car.Name}, Year Production: {car.ProductionYear}, Max Speed: {car.MaxSpeed}");
//        }
//    }
//}