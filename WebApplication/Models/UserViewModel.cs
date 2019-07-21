using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Students.Web.Models
{
    public class UserViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Nume utilizator")]
        [MinLength(6)]
        [MaxLength(10)]
        public string UserName { get; set; }

        [DisplayName("Adresa de email")]
        [Required]
        public string Email { get; set; }

        public AddressViewModel Address { get; set; }

        public Gender Gender { get; set; }
    }

    public class AddressViewModel
    {
        [DisplayName("Strada")]
        public string Street { get; set; }

        [DisplayName("Oras")]
        [Required]
        public string City { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}