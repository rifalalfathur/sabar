using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.Drawing;
using System.Text.Json.Serialization;

namespace API.Models
{
    
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
