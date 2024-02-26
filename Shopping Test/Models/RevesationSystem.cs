

namespace Shopping_Test.Models
{
    public class RevesationSystem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Data { get; set; }


        //Navigation
        public string ApplicationUserId { get; set; } = string.Empty;
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; } = default!;
       
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
