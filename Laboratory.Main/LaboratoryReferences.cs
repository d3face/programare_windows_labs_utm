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
                ["lab1"] = () => Laboratory._1.Program.Main(),
                ["lab2"] = () => Laboratory._2.Program.Main(),
                ["lab3"] = () => Laboratory._3.Program.Main(),
                ["lab4"] = () => Laboratory._4.Program.Main(),
                ["lab5"] = () => Laboratory._5.Program.Main(),
                ["lab6"] = () => Laboratory._6.Program.Main(),
                ["notepad"] = () =>
                {
                    ThreadStart p = () => Laboratory.Notepad.Program.Main();
                    var r = new Thread(p);
                    r.IsBackground = false;
                    r.Priority = ThreadPriority.AboveNormal;
                    r.TrySetApartmentState(ApartmentState.STA);
                    r.Start();
                },
            };
        }
        public static void Run(string what)
        {
            new Thread(ActionsHandler[what].Invoke).Start();
        }
    }
}
