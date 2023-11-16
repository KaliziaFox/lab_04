namespace car
{
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
    public class CarComparer : IComparer<Car>
    {
        private string _type;

        public CarComparer(string type)
        {
            _type = type;
        }

        public string Type { get => _type; }

        public int Compare(Car? car1, Car? car2)
        {

            if (Type == "1")
            {
                return String.Compare(car1.Name, car2.Name);
            }
            else if (Type == "2")
            {
                if (car1.ProductionYear > car2.ProductionYear) return -1;
                else if (car2.ProductionYear > car1.ProductionYear) return 1;
                else return 0;
            }
            else
            {
                if (car1.MaxSpeed > car2.MaxSpeed) return -1;
                else if (car1.MaxSpeed < car2.MaxSpeed) return 1;
                else return 0;
            }
        }
    }
    //class program
    //{
    //    static void Main(string[] args)
    //    {
    //        Car[] garage = { new Car("BMW", 2022, 320), new Car("Lexus", 2023, 290), new Car("Maseraty", 2020, 400) };
    //        Console.WriteLine("Сhoose comparison option, please: 1 - name; 2 - year of production; 3 - max speed");
    //        string option = Console.ReadLine();
    //        Array.Sort(garage, new CarComparer(option));
    //        foreach (Car car in garage)
    //        {
    //            Console.WriteLine(car.Name);
    //        }
    //    }
    //}
}