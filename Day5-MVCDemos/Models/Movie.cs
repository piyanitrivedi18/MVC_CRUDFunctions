using System.ComponentModel.DataAnnotations;

namespace Day5_MVCDemos.Models
{
    // To have a valid data, we add annotations
    // 
    public class User
    {
        [Required(ErrorMessage ="Id is must")]
        public int UserId { get; set; }
        [Required(ErrorMessage ="username is must")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="First Name is must")]
        [RegularExpression(@"[A-Za-z ]+",ErrorMessage ="Only alphabets are allowed")]
        [StringLength(20, ErrorMessage ="Max 20 characters are allowed")]
        [MinLength(10, ErrorMessage ="Min 10 characters are needed")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="DOJ is must")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh-ss}", ApplyFormatInEditMode = true)]
        [DateOfJoiningValidator]
        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }
        [Required]
        [Range(20,40, ErrorMessage ="Range is 20 to 40")]
        public int Age { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[A-Z][a-zA-Z0-9]+")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage ="Passwords do not match")]
        public string ReTypePassword { get; set; }
    }
}
