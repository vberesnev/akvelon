using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AkvelonTask
{
    class Employee
    {
        public string Title { get; private set; }
        public bool IsBoss { get; set; }
        public List<Employee> Subs { get; set; }

        public Employee(string title)
        {
            Title = title;
            Subs = new List<Employee>();
        }

        public void FindSubs(List<Employee> managers)
        {
            foreach (var manager in managers)
            {
                var tempEmp = manager.Subs.FirstOrDefault(x => x.Title == this.Title);
                if (tempEmp != null)
                {
                    tempEmp.Subs = this.Subs;
                    return;
                }
            }
            this.IsBoss = true;
        }
    }
}
