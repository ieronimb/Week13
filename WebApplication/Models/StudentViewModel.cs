using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Students.Web.Models
{
    public class StudentViewModel: UserViewModel
    {
        [Required(ErrorMessage = "Numele este obligatoriu")]
        [DisplayName("Nume student")]
        public string StudentName { get; set; }        
        [DisplayName("Varsta student")]
        public int Age { get; set; }
       
    }
   
}