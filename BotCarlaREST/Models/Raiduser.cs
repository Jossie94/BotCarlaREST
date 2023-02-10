using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BotCarlaREST.Models;

namespace BotCarlaREST.Models

{
    public class Raiduser
    {
        [Key]
        public int UserDId { get; set; }

        [ForeignKey("FK_Raid")]
        public string UserDName { get; set; }

    }
}
