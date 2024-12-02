

namespace Shopping_Test.Controllers
{
    /*[Authorize(Roles = "Admin")]*/
    public class MarkaController : Controller
    {
     
        private readonly IUnitOfWork _unitOfWork;

        public MarkaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index() => View(await _unitOfWork.Markas.GetAll(n => n.Name, OrderBy.Descending));
        

        public async Task<IActionResult> Modify(int id)
        {
            if (id <= 0)
            {
                Marka marka = new Marka { };
                return View(marka);
            }
            var CheckMarka = await _unitOfWork.Markas.FindByCriteria(m=> m.Id == id);
            if (CheckMarka is null)
                return NotFound();
            return View(CheckMarka);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modify(Marka Marka)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            if (Marka.Name == null)
            {
                ModelState.AddModelError("Name", "Name is Empty!");
                return View(Marka);
            }

            if (await _unitOfWork.Markas.CheckAny(n => n.Name == Marka.Name))
            {
                ModelState.AddModelError("Name", "Name is Exist !");
                return View(Marka);
            }


            if (Marka.Id <= 0)
            {
                Marka marka = new Marka
                {
                    Name = Marka.Name
                };
                await _unitOfWork.Markas.Add(marka);
            }
            else
            {
                var marka = await _unitOfWork.Markas.FindByCriteria(m => m.Id == Marka.Id);

                if (marka is null)
                    return NotFound();

                marka.Name = Marka.Name;
            }
            await _unitOfWork.Complete();
            await _unitOfWork.caching.SetItems(NameModels.Markas, await _unitOfWork.getListItems.Markas());

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
                return BadRequest();

           Marka? marka = await _unitOfWork.Markas.FindByCriteria(m => m.Id == Id);
            if (_unitOfWork.Markas == null)
                return NotFound();
            _unitOfWork.Markas.Remove(marka);
            await _unitOfWork.Complete();
            await _unitOfWork.caching.SetItems(NameModels.Markas, await _unitOfWork.getListItems.Markas());

            return Ok();
        }
    }
}
