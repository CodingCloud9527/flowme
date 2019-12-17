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
                var def = new ProcDef
                {
                    Description = "description",
                    Enable = true,
                    Version = 13,
                    ProcName = "sample",
                    BpmnDefContent = "hahaha"
                };

                var def2 = new ProcInst
                {
                  StartTime = DateTime.UtcNow,
                  StartUser = "333",
                  ProcDefRef = def
                };
                db.AddAsync(def2);
                db.AddAsync(def);
                db.SaveChanges();
                
                          


                Console.WriteLine("done");
            }
        }
    }
}