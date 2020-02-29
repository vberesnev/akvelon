using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace AkvelonTask
{
    class Result
    {
        public static void Print(List<string> data)
        {
            List<Employee> managers = new List<Employee>();
            foreach (var d in data) 
            {
                var arr = d.Split(',');
                var manager = new Employee(arr[0]);
                managers.Add(manager);
                for (int i = 1; i < arr.Length; i++) 
                {
                    manager.Subs.Add(new Employee(arr[i]));
                }
            }

            foreach (var manager in managers) 
            {
                manager.FindSubs(managers);
            }

            var superBoss = managers.FirstOrDefault(x => x.IsBoss);
            Print(0, superBoss);
        }

        public static void Print(int i, Employee emp)
        {
            for (int k = 0; k < i; k++)
            {
                Console.Write(" ");
            }
            Console.Write(emp.Title + "\n");
            foreach (var sub in emp.Subs)
            {
                Print(i + 4, sub);
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            List<string> data = new List<string>();
            data.Add("B2,E5,F6");
            data.Add("A1,B2,C3,D4");
            data.Add("D4,G7,I9");
            data.Add("G7,H8");

            Result.Print(data);
        }
    }

    
}
