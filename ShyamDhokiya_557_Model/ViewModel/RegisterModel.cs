using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShyamDhokiya_557_Model.ViewModel
{
    public class RegisterModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter a Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Enter a Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter a Password")]
        [MinLength(6,ErrorMessage = "Password Length must be more than 6")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter a Confirm Password")]
        [MinLength(6, ErrorMessage = "Confirm Password Length must be more than 6")]
        public string ConfirmPassword { get; set; }
    }
}
