namespace RecycleCoin.WebUI.Models
{
    public class RecycleModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TotalCarbon { get; set; }
        public List<RecycleDetailModel>? recycleDetailModels { get; set; }
    }
}
