using System.ComponentModel.DataAnnotations;

namespace NsigVerificationAPI.Models
{
    public class Certificate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }
    }
}