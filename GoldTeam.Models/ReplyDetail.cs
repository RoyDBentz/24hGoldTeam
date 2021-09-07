using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeam.Models
{
    public class ReplyDetail
    {
        public int ReplyId { get; set; }
        public string Text { get; set; }
        public string Content { get; set; }

        [Display(Name ="Created"]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name ="Modified"]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
