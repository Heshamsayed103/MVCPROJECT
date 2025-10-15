using System.ComponentModel.DataAnnotations;

namespace Company.G04.PL.Dtos
{
    public class ForgetPasswordDto
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required !!")]
        public string Email { get; set; }
    }
}
