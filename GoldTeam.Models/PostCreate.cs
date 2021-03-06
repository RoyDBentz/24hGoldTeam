using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeam.Models
{
    public class PostCreate
    {
        [Required]
        [MinLength(2, ErrorMessage ="Please enter at least 2 characters.")]
        [MaxLength(200, ErrorMessage ="There are too many characters in this field.")]
        public string Title { get; set; }
        [Required]
        [MaxLength(8000)]
        public string Text { get; set; }
    }
}
