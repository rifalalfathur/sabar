using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Drawing;

namespace WebApp.Models
{
    
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
