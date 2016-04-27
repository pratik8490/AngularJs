using DemoAngularWebAPI.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAngularWebAPI.Models
{
    public class TaskModel
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public List<Comments> Comments { get; set; }
        public string Label { get; set; }
        public string Category { get; set; }
        public string RowClass { get; set; }
    }

}
