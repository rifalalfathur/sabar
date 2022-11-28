using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Department
    {
        public Department(int Id, string Name, int divisionId)
        {
            this.Id = Id;
            this.Name = Name;
            this.divisionId = divisionId;
        }
        public Department()
        {

        }
        [Key]
        public int Id { get;  set; }
        public string Name { get;  set; }

        public int divisionId { get;  set; }
        [ForeignKey("divisionId")]
        public virtual Division Division { get; set; }





    }
}
