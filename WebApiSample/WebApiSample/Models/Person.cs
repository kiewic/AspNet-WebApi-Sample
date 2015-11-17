using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiSample.Models
{
    public class Person
    {
        [Key]
        public string Phone { get; set; }
        public string Name { get; set; }
    }
}
