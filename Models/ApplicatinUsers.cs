using System.ComponentModel.DataAnnotations;

namespace AdityaSoftwares.Models
{
    public class ApplicatinUsers
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Roles { get; set; }
    }
}
