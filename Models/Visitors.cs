using System.ComponentModel.DataAnnotations;

namespace AdityaSoftwares.Models
{
    public class Visitors
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Contact { get; set; }
        public string email { get; set; }   
        public string Message { get; set; }
    }
}
