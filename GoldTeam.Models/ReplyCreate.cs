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

        [MaxLength(400)]
        public string Text { get; set; }

        [Required]
        public int CommentId { get; set; }
    }
}
