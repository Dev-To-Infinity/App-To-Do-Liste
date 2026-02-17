using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Task
    {
        public Task(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public string Deadline { get; set; }
        public bool Checkmark { get; set; } 
    }


} 
