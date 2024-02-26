
namespace Shopping_Test.Models
{
    public class Card
    {
        public int Id { get; set; }
        public bool? Buyed { get; set; }
        public bool? Favourite { get; set; }
        public int mount { get; set; }




        //Navigate 
        public string ApplicationUserId { get; set; } = string.Empty;
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUsers { get; set; } = default!;

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Products { get; set; } = default!;

    }
}
