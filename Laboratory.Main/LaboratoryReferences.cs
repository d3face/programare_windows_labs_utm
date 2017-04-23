using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratory.Main
{
    internal class LaboratoryReferences
    {
        private static Dictionary<string, Action> ActionsHandler;
        static LaboratoryReferences()
        {
            ActionsHandler = new Dictionary<string, Action>
            {
                ["start_lab1"] = () => Laboratory._1.Program.Main(),
                ["start_lab2"] = () => Laboratory._2.Program.Main(),
                ["start_lab3"] = () => Laboratory._3.Program.Main(),
                ["start_lab4"] = () => Laboratory._4.Program.Main(),
                ["start_lab5"] = () => Laboratory._5.Program.Main(),
                //["start_lab6"] = () => Laboratory._6.Program.Main(),
            };
        }
        public static void Run(string what)
        {
            new Thread(ActionsHandler[what.Replace("_Click", string.Empty)].Invoke).Start();
        }
    }
}
