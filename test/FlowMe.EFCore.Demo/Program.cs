using System;
using System.Linq;
using FlowMe.Persistence.Entity;
using Microsoft.Extensions.Internal;

namespace FlowMe.EFCore.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DemoDbContext())
            {
                Console.WriteLine("done");
            }
        }
    }
}