using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Company.G04.PL.Dtos
{
    public class CreateEmployeeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]

        public string Name { get; set; }


        [Range(22, 60 ,ErrorMessage = "Age must be between 22 and 60")]
        public int? Age { get; set; }


        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid !!")]
        public string Email { get; set; }


        [RegularExpression(@"[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-z]{4,10}-[a-zA-Z]{5,10}$",
                             ErrorMessage = "Address Must Be Like 123-Street-City-Country")]
        public string Address { get; set; }

        [Phone]
        public string Phone { get; set; }


        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Hiring Date")]
        public DateTime HiringDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Created Of Creation")]
        public DateTime CreateAt { get; set; }

        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }


        public string? ImageName { get; set; }
        public IFormFile? Image { get; set; }

    }
}
