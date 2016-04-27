using DemoAngularWebAPI.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAngularWebAPI.API.Entities
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public DateTime DueDate { get; set; }
        public string Label { get; set; }
        public string Category { get; set; }
    }
}
