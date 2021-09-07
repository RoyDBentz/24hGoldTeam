using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeam.Models
{
    public class ReplyCreate
    {
        [Required]
        [MinLength(2, ErrorMessage ="Please use at least 2 character")]
        [MaxLength(10, ErrorMessage = "Must be 10 or less characters")]
        public string Title { get; set; }

        [MaxLength(400)]
        public string Content { get; set; }
    }
}
