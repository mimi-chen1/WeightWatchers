using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightWatchers.core.Response
{
    public  class SubscriberCardResponse
    {
        public int id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double BMI { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

    }
}
