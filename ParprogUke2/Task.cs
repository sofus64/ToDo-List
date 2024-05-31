using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParprogUke2
{
    
    
    internal class Task
    {
        private string _name;
        private string _description;

        public Task(string name, string description)
        {
            _description = description;
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
        public void SetName(string input)
        {
            _name = input;
        }
        public string GetDesc()
        {
            return _description;
        } 
        public void SetDesc(string input)
        {
            _description = input;
        }
    }
}
