using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Please Enter UserName")]
   
        public String UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter password")]
        public String Password { get; set; }
    }
}
