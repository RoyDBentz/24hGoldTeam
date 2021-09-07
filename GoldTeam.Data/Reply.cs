using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeam.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }
        [Required]
        string Text { get; set; }
        [Required]
        Guid AuthorId { get; set; }       

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
