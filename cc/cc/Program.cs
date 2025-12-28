//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace month3
//{
//    //class Person
//    //{
//    //    public string Name { get; set; }
//    //    public int Age { get; set; }
//    //}

//    interface Animal
//    {
//        void myfirstmethod();
//    }

//    interface Food 
//    {
//        void myfood();

//    }

//    class Dog : Animal, Food
//    {
//        public void myfirstmethod()
//        {
//            Console.WriteLine("hello");
//        }
//        public void myfood()
//        {
//            Console.WriteLine("this is dog food");
//        }

//    }



//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //var people = new List<Person>
//            //{
//            //    new Person { Name = "Alice", Age = 30 },
//            //    new Person { Name = "Bob", Age = 17 },
//            //    new Person { Name = "Charlie", Age = 25 },
//            //    new Person { Name = "David", Age = 30 },
//            //    new Person { Name = "Eve", Age = 40 }
//            //};

//            //var adults = people.Where(p => p.Age >= 18);
//            //var agedperson = people.Where(p => p.Age >= 30);
//            //Console.WriteLine("Adults:");
//            //foreach (var p in adults)
//            //    Console.WriteLine($" - {p.Name} ({p.Age})");

//            //var names = people.Select(p => p.Name);
//            //Console.WriteLine("\nAll Names:");
//            //foreach (var name in names)
//            //    Console.WriteLine(" - " + name);

//            //var sorted = people.OrderBy(p => p.Age);
//            //Console.WriteLine("\nSorted By Age:");
//            //foreach (var p in sorted)
//            //    Console.WriteLine($"{p.Name}: {p.Age}");

//            //var grouped = people.GroupBy(p => p.Age);
//            //Console.WriteLine("\nGrouped By Age:");
//            //foreach (var group in grouped)
//            //{
//            //    Console.WriteLine($"Age {group.Key}:");
//            //    foreach (var person in group)
//            //        Console.WriteLine($" - {person.Name}");
//            //}

//            //Parallel.For(0, 10, i =>
//            //{
//            //    Console.WriteLine(i);
//            //});


//            Dog doggy = new Dog();
//            doggy.myfirstmethod();
//            doggy.myfood();

//        }
//    }
//}


using System;

public interface IEngine
{
    void Start();  
}

public class Engine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Engine is starting...");
    }
}

public class ElectricEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Electric engine is starting...");
    }
}

public class Dieselengine : IEngine
{
    public void Start()
    {
        Console.WriteLine("diesel engine is starting");
    }
}

public class Car
{
    private IEngine engine; 

    public Car(IEngine engine)
    {
        this.engine = engine;  
    }

    public void StartCar()
    {
        engine.Start();  
        Console.WriteLine("Car is now running.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IEngine engine = new Engine();
        Car car = new Car(engine);
        car.StartCar();

        IEngine electricEngine = new ElectricEngine();
        Car electricCar = new Car(electricEngine);
        electricCar.StartCar();

        IEngine diesel = new Dieselengine();
        Car car1 = new Car(diesel);
        car1.StartCar();
    }
}
