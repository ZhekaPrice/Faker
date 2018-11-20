using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Faker;
using ExampleUseFaker;

namespace TestFaker
{
    [TestFixture]
    public class Class1
    {
        private Faker.Faker faker;
        private PrivateClass exampleClass;
        private Foo foo;


        public void Start()
        {
            faker = new Faker.Faker();
            foo = faker.Create<Foo>();
            exampleClass = faker.Create<PrivateClass>();
        }

        [Test]
        public void TestString()
        {
            Start();
            Assert.True(!foo.Str1.Equals(""));
        }

        [Test]
        public void TestBool()
        {
            Start();
            Assert.IsTrue(foo.IsTrue);
        }

        [Test]
        public void TestClass()
        {
            Start();
            Assert.IsTrue(foo.Bar != null);
        }

        [Test]
        public void TestLong()
        {
            Start();
            Assert.IsTrue(foo.Long != 0L);
        }

        [Test]
        public void TestFloat()
        {
            Start();
            Assert.IsTrue(foo.Float != 0f);
        }

        [Test]
        public void TestList()
        {
            Start();
            Assert.IsTrue(foo.Bar.IntList.Count > 0);
        }

        [Test]
        public void TestChar()
        {
            Start();
            Assert.IsTrue(foo.Bar.Sumbol2 != ' ');
        }

        [Test]
        public void TestDateTime()
        {
            Start();
            Assert.IsFalse(foo.Bar.DateTime.Equals(foo.Bar.DateTime1));
        }

        [Test]
        public void TestPrivateConstructor()
        {
            Start();
            Assert.IsTrue(exampleClass == null);
        }
    }
}
