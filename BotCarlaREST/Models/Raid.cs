using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BotCarlaREST.Models;

namespace BotCarlaREST.Models
{
    public class Raid
    {
        [Key]
        public int RaidId { get; set; } //pk
        public DateTime Raiddate
        {
            get; set;

        }
        public string Tier { get; set; }
        public string Raidname { get; set; }

        public List <Raiduser> Raidusers { get; set; }
    }
    
}
