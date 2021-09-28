using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.Events
{
    public class AddToCartEvent : PubSubEvent<AddToCartEvent.PayloadCart>
    {
        public class PayloadCart
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

    }

    public class SubtractedFromCartEvent : PubSubEvent<SubtractedFromCartEvent.PayloadCart>
    {
        public class PayloadCart
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }
    }

    public class RemovedFromCartEvent : PubSubEvent<RemovedFromCartEvent.PayloadCart>
    {
        public class PayloadCart
        {
            public int ProductId { get; set; }            
        }
    }
}
