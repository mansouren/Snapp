using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.Generators
{
   public static class CodeGenerators
    {
        public static Guid GetId()
        {
            return Guid.NewGuid();
        }

        public static string GetFileName()
        {
            return Guid.NewGuid().ToString().Replace("-","");
        }

        public static string GetOrderCode()
        {
            Random random = new Random();
            return random.Next(10000000, 99000000).ToString();
        }

        public static string GetActiveCode()
        {
            Random random = new Random();
            return random.Next(100000, 990000).ToString();
        }
    }
}
