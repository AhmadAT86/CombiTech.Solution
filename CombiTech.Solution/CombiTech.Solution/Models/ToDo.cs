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
        public string ProjectOnwerId { get; set; }
        public DateTime Created { get; set; }
        public DateTime FinishedTime { get; set; }
        public bool Active { get; set; }
        public List<ProjectStructure> ProjectStructures { get; set; }

    }
}


