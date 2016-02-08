using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CombiTech.Solution.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ToDo
    {
        [Required]
        public int Id { get; set; }
        public string Description { get; set; }
        public string ProjectOnwer { get; set; }
        public DateTime Created { get; set; }
        public bool Active { get; set; }

    }
}


//public int Id { get; set; }
//public int PersonId { get; set; }
//public string Description { get; set; }
//public string ProjectOwner { get; set; }
//public string Members { get; set; }
//public Delegate Created { get; set; }
//public DateTime ProjectPeriod { get; set; }
//public DateTime DateTime { get; set; }