using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeam.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "There are too many characters in this field.")]
    
        public string Text { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }


    }
}
