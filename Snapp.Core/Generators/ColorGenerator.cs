using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.Generators
{
   public static class ColorGenerator
    {
        public static string GetColorCode()
        {
            string[] colors = { "#d64161", "#feb236", "#ff7b25", "#6b5b95", "#878f99", "#a2b9bc", "#b5e7a0", "#ada397",
                                "#f7786b","#034f84","#ffef96","#e4d1d1", "#77a8a8", "#563f46", "#87bdd8", "#f4a688",
                                "#ffeead", "#c83349", "#eeac99", "#96ceb4", "#a2836e", "#f1e3dd", "#a79e84", "#b2b2b2"};
            Random random = new Random();
            int index = random.Next(colors.Length);
            return colors[index];
        }
    }
}
