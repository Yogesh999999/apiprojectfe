using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{

    //public class animal
    //{
    //    public  virtual void sound()
    //    {
    //        Console.WriteLine("urrrr");
    //    }
    //}

    //public class dog : animal
    //{
    //    public  override void sound()
    //    {
    //        Console.WriteLine("bark");
    //    }


    //}

    abstract class animal
    {
        public abstract void animalsound();

        public void animal1()
        {
            Console.WriteLine("kow kow");
        }
    }

     class cat : animal 
    {

        public override void animalsound()
        {
            Console.WriteLine("meow");
        }
    }


    class Program
    {
        //String name;

        //public Program(String value)
        //{
        //    name = value;
        //    Console.WriteLine(name);

        //}

        //private String school;

        //public String School
        //{

        //    get { return school; }
        //    set { school = value; }
        //}

        //public class car
        //{

        //    public String name = "bmw";

        //    public void horn()
        //    {
        //        Console.WriteLine("bmw horn");
        //    }


        //}

        //public class bike : car
        //{

        //    public String bikename = "cbr";

        //}







        //String name = "yogesh";
        //int age = 60;
        //int y = 10;

        //static void Mymethod(String name = "india")
        //{
        //    Console.WriteLine($" it's {name} .i am from method (or) function as you want");
        //}

        //static int PlusMethod(int x, int y)
        //{
        //    return x + y;
        //}

        //static int PlusMethod(int x, int y, int z)
        //{
        //    return x + y + z;
        //}

        static void Main(string[] args)
        {

            cat obj = new cat();
            obj.animalsound();

            //animal obj = new animal();
            //obj.sound();
            //dog obj1 = new dog();
            //obj1.sound();

            //bike obj = new bike();
            //Console.WriteLine(obj.name);
            //Console.WriteLine(obj.bikename);
            //obj.horn();

            //Program myobj = new Program();

            //Program obj = new Program();
            //Console.WriteLine(obj.name); 
            //Console.WriteLine("helloworld");

            //String name = "Yogesh";
            //Console.WriteLine(name);

            //int age = 18;
            //Console.WriteLine(age);

            //int number;
            //number = 10;
            //Console.WriteLine(number);

            //Console.WriteLine(Convert.ToString(age));

            //Console.WriteLine("Enter a name.");

            //String name = Console.ReadLine();

            //Console.WriteLine(name);

            //int a = 10;
            //int b = 30;
            //Console.WriteLine($"this is the added value {a + b}");

            //Console.WriteLine("Enter your age");

            //int age = Convert.ToInt32(Console.ReadLine());
            //int valid = 18;

            //if (age >= valid)
            //{
            //    Console.WriteLine("you are eligible to vote");
            //}
            //else
            //{
            //    Console.WriteLine("You are not eligible to vote");
            //}

            //if (age >= valid)
            //{
            //    Console.WriteLine("Enter your age");
            //}
            //else if (age >= valid)
            //{
            //    Console.WriteLine($"You are eligible to vote age is {age}");
            //}
            //else
            //{
            //    Console.WriteLine($"You are not eligible to vote your age is less than {valid}");
            //}

            //int a = 10;
            //int b = 20;
            //string c = (a > b) ? "valid" : "invalid";
            //Console.WriteLine(c);

            //int age = 18;
            //switch (age)
            //{
            //    case 1:
            //        Console.WriteLine("hello");
            //        break;
            //    case 18:
            //        Console.WriteLine("Thankyou");
            //        break;
            //}

            //int a = 0;
            //while (a < 18)
            //{
            //    Console.WriteLine(a);
            //    a++;
            //}

            //int a = 1;
            //do
            //{
            //    Console.WriteLine(a);
            //    a++;
            //} while (a < 10);

            //for (int i = 1;i<=10;i++)
            //{
            //    Console.WriteLine(i + "i");
            //    for (int j = 1; j <= 10; j++)
            //    {
            //        Console.WriteLine(j + "j");
            //    } 
            //}


            //String[] name = { "yogesh", "bala", "sulthan" };
            //foreach(String a in name ){

            //    Console.WriteLine(a);

            //}

            //String[] a = { "y", "zz", "k", "l" };
            //a[1] = "yogesh";
            //Console.WriteLine(a[1]);
            //for (int i = 0; i < a.Length; i++)
            //{
            //    Console.WriteLine(a[i]);
            //}
            //Array.Sort(a);
            //foreach (string s in a)
            //{
            //    Console.WriteLine(s);
            //}

            //int[] b = { 10, 3, 4, 7 };
            //Array.Sort(b);

            //foreach (int i in b)
            //{
            //    Console.WriteLine(i);
            //}

            //Mymethod(name: "yogesh");
            //Mymethod();
            //Mymethod();
            //Mymethod();
            //int myNum1 = PlusMethod(8, 5);
            //int myNum2 = PlusMethod(8, 5, 6);
            //Console.WriteLine(myNum1);
            //Console.WriteLine(myNum2);

            //Program obj = new Program();

            //String k = obj.name;
            //Console.WriteLine(k);

            //Class1 my = new Class1();
            //String d = my.value;
            //Console.WriteLine(d);

            //Class1 obj1 = new Class1();
            //obj1.model = "ksharp";
            //obj1.color = "red";
            //obj1.year = 10;
            //obj1.fullthrottle();

            //Console.WriteLine(obj1.model);
            //Console.WriteLine(obj1.color);
            //Console.WriteLine(obj1.year);

            //Program obj = new Program("yogesh");

            //Program obj = new Program();

            //obj.School = "Holy";

            //Console.WriteLine(obj.School);

            //INHERITANCE


        }
    }
}
