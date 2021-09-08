using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeam.Models
{
    public class ReplyEdit
    {
        public int ReplyId { get; set; }
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
    }
}
