using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;

namespace DateTimeGeneratorPlugin
{
    public class DateTimeGeneratorPlugin : IPlugin
    {
        private Random random;

        public Type type
        {
            get { return typeof(DateTime); }
        }

        public DateTimeGeneratorPlugin()
        {
            random = new Random();
        }

        public object GenerateRandomValue(Type type)
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }
    }
}
