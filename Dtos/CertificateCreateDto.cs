using System;
using System.ComponentModel.DataAnnotations;

namespace NsigVerificationAPI.Dtos
{
    public class CertificateCreateDto
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
