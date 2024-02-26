
namespace Shopping_Test.Models
{
    public class UserProducts
    {
        public string ApplicationUserId { get; set; } = string.Empty;
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; } = default!;

        public virtual Product Product { get; set; } = default!;
        [ForeignKey("ProductId")]
        public int ProductId { get; set; } 

    }
}
