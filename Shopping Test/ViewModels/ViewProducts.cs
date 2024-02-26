

using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping_Test.Models;

namespace Shopping_Test.ViewModels
{
    public class ViewProducts
    {
        public Product product { get; set; } = default!;
        public IFormFile Image { get; set; } = default!;

        //Navigation
        public int AgeStageId { get; set; }
        public IEnumerable<SelectListItem> AgeStage { get; set; } = Enumerable.Empty<SelectListItem>(); 

        public int MarkaId { get; set; }
        public IEnumerable<SelectListItem> Markas { get; set; } = Enumerable.Empty<SelectListItem>();
        public int ClothesClassificationId { get; set; }
        public IEnumerable<SelectListItem> ClothesClassifications { get; set; } = Enumerable.Empty<SelectListItem>();

        public int HumanClassId { get; set; }
        public IEnumerable<SelectListItem> HumanClasses { get; set; } = Enumerable.Empty<SelectListItem>();
       }
}
