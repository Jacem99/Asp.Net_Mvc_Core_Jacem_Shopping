
namespace Shopping_Test.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PMId { get; set; }
       
        [Column(TypeName ="nvarchar(100)")]
        public string NameOwnerCard { get; set; } = string.Empty;

        [Column(TypeName = "varchar(16)")]
        public string CardNumber { get; set; } = string.Empty;
       
        [Column(TypeName = "varchar(5)")]
        public string ExpirationDate { get; set; } = string.Empty; // MM/YY
       
        [Column(TypeName = "varchar(3)")]
        public string CVV { get; set; } = string.Empty;



        //Navigate
        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; } =string.Empty;
        public virtual ApplicationUser ApplicationUser { get; set; } = default!;

    }
}
