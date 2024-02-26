
namespace Shopping_Test.ViewModels
{
    public class classificationsOfProducts
    {
        [Display(Name ="Age Stage")]
        public int AgeStagesId { get; set; }
        public  IEnumerable<AgeStage> AgeStages { get; set; } = new List<AgeStage>();


        [Display(Name = "Human Class")]
        public int HumanClassificationsId { get; set; }
        public IEnumerable<HumanClass> HumanClassifications { get; set; } =new List<HumanClass>();


        [Display(Name = "Clothes Class")]
        public int ClothesClassificationsId { get; set; }
        public IEnumerable<ClothesClassification> ClothesClassifications { get; set; } = new List<ClothesClassification>();

        public IEnumerable<Product> Product { get; set; } = new List<Product>();
        public IEnumerable<UserProducts> userProducts { get; set; } = new List<UserProducts>();


    }
}
