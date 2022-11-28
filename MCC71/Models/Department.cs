using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC71.Models
{
    internal class Department
    {
        public Department(int Id, string Name, int DIVISIONId)
        {
            this.Id = Id;
            this.Name = Name;
            this.DIVISIONId = DIVISIONId;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int DIVISIONId { get; private set; }
    }
}
