﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;
using Persistance;
using System.IO;

using static System.Console;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            EntityDataManager bdd = new EntityDataManager();
            Self self = new Self(bdd);
            
            self.chargeAll();
            /*foreach(var u in self.menusROC)
            {
                WriteLine(u.ToString());
            }*/
            foreach (var u in self.usagerROC)
            {
                WriteLine(u.ToString());
            }
            foreach (var u in self.utilisateurROC)
            {
                WriteLine(u.ToString());
            }

            Read();
            
        }
    }
}