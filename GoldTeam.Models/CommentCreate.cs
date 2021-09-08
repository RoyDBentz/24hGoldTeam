using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeam.Models
{
    public class CommentCreate
    {
        [MaxLength(400)]
        public string Text { get; set; }
    }
}
