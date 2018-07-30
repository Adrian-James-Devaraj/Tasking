using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Tasking.Models
{
    public class CoreUser
    {
        [Key]
        [Display(Name = "Assiginee")]
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public string IdNumber { get; set; }

    }
}