using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace arquivei_api.Models
{
    public class Nfe
    {
        [Key]
        public string AccessKey { get; set; }
        public string Xml { get; set; }
        
    }
}
