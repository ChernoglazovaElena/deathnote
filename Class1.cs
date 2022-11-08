
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zametk
{
    public class bip
    {
        public string name;
        public string description;
        public string date;
        public string deadline;

        public bip(string name, string date, string description, string dateToComp)
        {
            this.name = name;
            this.description = description;
            this.date = date;
            this.deadline = dateToComp;
        }
    }
}