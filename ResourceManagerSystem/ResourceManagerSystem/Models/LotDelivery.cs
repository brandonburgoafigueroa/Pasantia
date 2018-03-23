using System.ComponentModel.DataAnnotations;

namespace ResourceManagerSystem.Models
{
    public class LotDelivery
    {
        [Key]
        public int DeliveryID { set; get; }
        [Key]
        public int LotID { set; get; }

        public Delivery Delivery { set; get; }
        public Lot Lot { set; get; }
    }
}