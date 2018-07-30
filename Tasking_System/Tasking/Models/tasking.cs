using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Tasking.Models
{
    public class tasking
    {
        [Key]
        public int Idd { get; set; }

        [Display(Name = "User Name")]
        public string UserId { get; set; }
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }
        [Display(Name = "Task Number")]
        public string TaskNumber { get; set; }

        [Display(Name = "Details")]
        public string TaskDesc { get; set; }

        [Display(Name = "Comments")]
        public string TaskComments { get; set; }

        [Display(Name = "Assiginee")]
        public int Id { get; set; }

        public bool completed { get; set; }

        public virtual CoreUser CoreUsers { get; set; }
    }
}