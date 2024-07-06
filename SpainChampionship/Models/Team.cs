using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpainChampionship.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? City { get; set; }

        public int Wins { get; set; }
        public int Lose { get; set; }
        public int Draw { get; set; }
    }
}
