
namespace Shopping_Test.Controllers
{
       /* [Authorize(Roles = "Admin")]*/
    public class CatogeryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CatogeryController(IUnitOfWork unitOfWork)
            {
             _unitOfWork = unitOfWork;
            }
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.ClothesClassifications.GetAll(c => c.Name, OrderBy.Ascending));
        }
    
  
        public async Task<IActionResult> Modify(int? id)
        {
            if(id == null)
            {
                ClothesClassification Catogery = new ClothesClassification { };
                return View(Catogery);
            }
            var catogery = await _unitOfWork.ClothesClassifications.FindByCriteria(c=> c.Id == id);
            if (catogery is null)
                return NotFound();
            return View(catogery);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modify(ClothesClassification Catogery)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            if (Catogery.Name == null)
            {
                ModelState.AddModelError("Name", "Name is Empty!");
                return View(Catogery);
            }

            if (await _unitOfWork.ClothesClassifications.CheckAny(n => n.Name == Catogery.Name))
            {
                ModelState.AddModelError("Name", "Name is Exist !");
                return View(Catogery);
            }


            if(Catogery.Id <= 0)
            {
                ClothesClassification catog = new ClothesClassification
                {
                    Name = Catogery.Name
                };
                await _unitOfWork.ClothesClassifications.Add(catog);
            }
            else
            {
               var catogery = await _unitOfWork.ClothesClassifications.FindByCriteria(c=> c.Id ==Catogery.Id);

                if (catogery is null)
                     return NotFound();

                catogery.Name = Catogery.Name;
            }
            await _unitOfWork.Complete();
            await _unitOfWork.caching.SetItems(NameModels.ClothesClassification, await _unitOfWork.getListItems.ClothsCalssification());

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
                return BadRequest();
            var catogery = await _unitOfWork.ClothesClassifications.FindByCriteria(c=> c.Id ==Id);
            if (catogery == null)
                return NotFound();
            _unitOfWork.ClothesClassifications.Remove(catogery);
            await _unitOfWork.Complete();

            await _unitOfWork.caching.SetItems(NameModels.ClothesClassification, await _unitOfWork.getListItems.ClothsCalssification());

            return Ok();
        }
    }

}
