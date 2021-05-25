using System;

namespace Opgave_3
{
    class Program
    {
        class Apple
        {
            public string Generation
            { get; set; }
        }

        // Det er encapsulated ved at det ikke ligger direkte i generation string
        static void Main(string[] args)
        {
            Apple myApple = new Apple();
            myApple.Generation = "13";
            Console.WriteLine(myApple.Generation);
        }
    }
}
