using RecycleCoin.API.Concrete;

namespace RecycleCoin.WebUI.Models
{
    public class IntroduceProductModel
    {
        public DetectedObject? detectedObject { get; set; }
        public List<RecycleDetailModel>? RecycleDetailModels { get; set; }
    }
}
