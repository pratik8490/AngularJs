using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DemoAngularWebAPI.API.Entities
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; }
        public int TaskID { get; set; }
    }
}
