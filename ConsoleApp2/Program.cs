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

namespace ConsoleApp2
{
    class Result
    {
        public static void Print(List<string> data)
        {
            List<Employee> bosses = new List<Employee>();
            foreach (var d in data) 
            {
                var arr = d.Split(',');
                var boss = new Employee(arr[0], true);
                bosses.Add(boss);
                for (int i = 1; i < arr.Length; i++) 
                {
                    boss.Subs.Add(new Employee(arr[i], false));
                }
            }

            foreach (var boss in bosses) 
            {
                WhoIsTheBoss(boss, bosses);
            }

            var superBoss = bosses.FirstOrDefault(x => x.Level == 1);
            Print(0, superBoss);
        }

        public static void WhoIsTheBoss(Employee emp, List<Employee> bosses)
        {
            foreach (var boss in bosses)
            {
                var tempEmp = boss.Subs.FirstOrDefault(x => x.Title == emp.Title);
                if (tempEmp != null) 
                {
                    boss.Subs.Remove(tempEmp);
                    boss.Subs.Add(emp);
                    return;
                }
            }
            emp.Level = 1;
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

    class Employee
    {
        public string Title { get; set; }
        public bool IsBoss { get; set; }
        public List<Employee> Subs { get; set; }
        public int Level { get; set; }

        public Employee(string t, bool isBoss)
        {
            Title = t;
            IsBoss = isBoss;
            Subs = new List<Employee>();
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
