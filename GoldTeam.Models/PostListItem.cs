using GoldTeam.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTeam.Models
{
    public class PostListItem
    {
        public int PostId { get; set; }
        public string Title { get; set; }

    }
}
