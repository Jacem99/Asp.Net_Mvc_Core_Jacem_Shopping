

namespace Shopping_Test.Models
{
    public class ApplicationUser : IdentityUser
    {

        [MaxLength(60), Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(60),Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(150) , Display(Name ="Name")]
        public string DisplayName { get; set; } = string.Empty;
        public string NameOfImage{ get; set; } = string.Empty;



        //RelationShips
     
        public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
        public virtual ICollection<RevesationSystem> RevesationSystems { get; set; }= new List<RevesationSystem>();
        public virtual ICollection<UserProducts> UserProducts { get; set; } = new List<UserProducts>();

    }
}
