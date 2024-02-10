using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.data.Model;

namespace WeightWatchers.data.Entites
{
    [Table("Card")]
    public  class Card
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int? SubscriberId { get; set; }
        [ForeignKey(nameof(SubscriberId))]
        public  Subscriber subscriberOfCard { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:dd/mm/yyyy ")]
        public DateTime OpenDate { get; set; }
        public double BMI { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:dd/mm/yyyy ")]
        public DateTime UpdateDate { get; set; }



    }
}
