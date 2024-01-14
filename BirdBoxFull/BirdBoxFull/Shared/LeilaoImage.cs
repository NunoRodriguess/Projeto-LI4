using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdBoxFull.Shared
{
    public class LeilaoImage
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string LeilaoCodLeilao { get; set; }
        public Leilao Leilao { get; set; }
    }
}
