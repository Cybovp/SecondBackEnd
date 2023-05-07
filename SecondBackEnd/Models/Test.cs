using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace SecondBackEnd.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Test
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Range(18, 100, ErrorMessage ="You must be over 18 to register. Over 100? Seriously?")]
        public int Age { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="This is not a valid email, try: address@domain")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public bool KeepLoggedIn { get; set; }

    }
}
