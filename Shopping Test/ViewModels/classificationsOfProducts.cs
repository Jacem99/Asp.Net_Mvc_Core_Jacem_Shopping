
namespace Shopping_Test.ViewModels
{
    public class classificationsOfProducts
    {
        [Display(Name ="Age Stage")]

        public int AgeStageId { get; set; }
        public IEnumerable<SelectListItem> AgeStages { get; set; } = Enumerable.Empty<SelectListItem>();


        [Display(Name = "Human Class")]

        public int HumanClassId { get; set; }
        public IEnumerable<SelectListItem> HumanClasses { get; set; } = Enumerable.Empty<SelectListItem>();


        [Display(Name = "Clothes Class")]

        public int ClothesClassificationId { get; set; }
        public IEnumerable<SelectListItem> ClothesClassifications { get; set; } = Enumerable.Empty<SelectListItem>();


        public IEnumerable<Product> Product { get; set; } = new List<Product>();
        public IEnumerable<UserProducts> userProducts { get; set; } = new List<UserProducts>();


    }
}



