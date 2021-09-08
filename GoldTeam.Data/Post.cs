using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeam.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage ="There are too many characters in this field.")]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
    }
}
