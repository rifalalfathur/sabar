
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    
    public class User
    {
        [Key]
        [ForeignKey("Id")]
        public int Id { get; set; }
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }


        public string Password { get; set; }


        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        [JsonIgnore]
        public virtual Role? Role { get; set; }

        
    }
}
