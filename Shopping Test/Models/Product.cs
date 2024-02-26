

namespace Shopping_Test.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(300)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; }

        [MaxLength(6)]
        public string Size { get; set; } = string.Empty;
        public int Rate { get; set; }
        public int? SizeNumber { get; set; }
        public string NameOfImage { get; set; } = string.Empty;
        public int? Discount { get; set; }




        //Navigation
        public int AgeStageId { get; set; }
        [ForeignKey("AgeStageId")]
        public virtual AgeStage AgeStage { get; set; } = default!;

        public int  MarkaId { get; set; }
        [ForeignKey("MarkaId")]
        public virtual Marka Marka { get; set; } = default!;

        public int HumanClassId { get; set; }
        [ForeignKey("HumanClassId")]
        public virtual HumanClass HumanClass { get; set; } = default!;

        public int ClothesClassificationId { get; set; }
        [ForeignKey("ClothesClassificationId")]
        public virtual ClothesClassification ClothesClassification { get; set; } = default!;

        public virtual ICollection<RevesationSystem> RevesationSystems { get; set; } = new List<RevesationSystem>();
        public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
        public virtual ICollection<UserProducts> UserProducts { get; set; } = new List<UserProducts>();

    }
}
