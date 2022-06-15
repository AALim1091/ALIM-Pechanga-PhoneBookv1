using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookv1.Shared.Models
{
    //Defines Database fields
    public class Employees 
    {
        //Primary Key
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]

        //For Ranking the Employee titles with one table
        public int TitleRank { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string MobilePhoneNumber { get; set; }
        [Required]
        public string PhoneExtension { get; set; }
        public string Comments { get; set; } 

       

    }
}
