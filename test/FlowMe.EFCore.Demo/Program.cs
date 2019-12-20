using System;

namespace FlowMe.EFCore.Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new DemoDbContext())
            {
                Console.WriteLine("done");
            }
        }
    }
}