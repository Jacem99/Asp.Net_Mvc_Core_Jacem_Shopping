using Shopping_Test.Models;


namespace Shopping_Test.ViewModels
{
    public class Edit_Product
    {
        public Product product { get; set; } = default!;


        //Navigation
        public int AgeStageId { get; set; }
        public IEnumerable<AgeStage> AgeStage { get; set; } = new List<AgeStage>();

        public int MarkaId { get; set; }
        public IEnumerable<Marka> Markas { get; set; } = new List<Marka>();

        public int ClothesClassificationId { get; set; }
        public IEnumerable<ClothesClassification> ClothesClassifications { get; set; } = new List<ClothesClassification>();
    }
}

