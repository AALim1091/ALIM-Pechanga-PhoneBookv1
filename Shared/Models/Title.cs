using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookv1.Shared.Models
{
    //Defines Database fields
    public class Title
    {
        //Primary Key
        public int Id { get; set; }

        public int Rank {get;set;}

    }
}
