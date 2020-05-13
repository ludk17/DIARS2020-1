using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Username { get; set; }
    }
}
