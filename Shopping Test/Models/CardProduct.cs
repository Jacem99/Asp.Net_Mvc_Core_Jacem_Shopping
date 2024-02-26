
namespace Shopping_Test.Models
{
    public class CardProduct
    {
        public int CardId { get; set; }
        [ForeignKey("CardId")]
        public virtual Card Card { get; set; } = default!;
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = default!;
    }
}
