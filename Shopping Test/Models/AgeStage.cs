

namespace Shopping_Test.Models
{
    public class AgeStage
    {
        [Key]
        public int Id { get; set; }
        [ MaxLength(200)]
        public string Name { get; set; } = string.Empty;    
       
        //Navigation
       
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();   

    }
}
