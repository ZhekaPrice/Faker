using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleUseFaker;

namespace Faker
{
    class Program
    {
        static void Main(string[] args)
        {
            var faker = new Faker();
            Foo foo = faker.Create<Foo>();
            PrivateClass clas = faker.Create<PrivateClass>();
            Console.WriteLine(foo.Age);
            Console.WriteLine(foo.Name);
            Console.WriteLine(foo.IsTrue);
            Console.WriteLine(foo.Bar.Str);
            Console.WriteLine(foo.Bar.NewDouble);

            string intArrToString = "Bar IntList = ";
            foreach (int i in foo.Bar.IntList)
            {
                intArrToString += i + "; ";
            }
            Console.WriteLine(intArrToString);
            Console.WriteLine(foo.Bar.DateTime);
            Console.ReadLine();
        }
    }
}
