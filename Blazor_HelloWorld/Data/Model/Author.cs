using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_HelloWorld.Data.Model
{
    public class Author
    {
        public int AuthorID { get; set; }
        [Required(ErrorMessage = "Please enter a First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Incorrect format for Email")]
        public string EmailAddress { get; set; }
        [Range(1000,Int32.MaxValue,ErrorMessage ="Salary should be greater than $1000")]
        public int Salary { get; set; }
    }
}
