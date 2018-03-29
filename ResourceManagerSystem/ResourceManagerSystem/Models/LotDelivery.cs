using System.ComponentModel.DataAnnotations;

namespace ResourceManagerSystem.Models
{
    public class LotDelivery
    {
        [Key]
        public int LotDeliveryID { set; get; }
        
        public int DeliveryID { set; get; }
        
        public int LotID { set; get; }

        public Delivery Delivery { set; get; }
        public Lot Lot { set; get; }
    }
}