using System.ComponentModel.DataAnnotations;


namespace HRmanagement.Models
{
    public class Employee
    {

        [Key]
        public int Emp_id { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public  string Emp_Name { get; set; }

        [Required]
        public  string Emp_Title { get; set; }

        [Required]
        public  string Emp_Department { get; set; }

        [Required, EmailAddress]
        public  string Emp_Email { get; set; }

        [Required, MinLength(11)]
        public  string Emp_Phone { get; set; }
    }
}
