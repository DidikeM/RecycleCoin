using RecycleCoin.Entities.Concrete.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecycleCoin.WebUI.Models
{
    public class RecycleDetailModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int ProductPoint { get; set; }
        public int ProductQuantity { get; set; }
        public int SubTotalPrice { get; set; }
    }
}
