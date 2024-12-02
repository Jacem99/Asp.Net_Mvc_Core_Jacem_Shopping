

namespace Shopping_Test.Controllers
{
    /*[Authorize(Roles = "Admin")]*/
    public class HumanClassController : Controller
    {
     
        private readonly IUnitOfWork _unitOfWork;

        public HumanClassController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index() => View(await _unitOfWork.HumanClasses.GetAll(n => n.Name, OrderBy.Ascending));
        

        public async Task<IActionResult> Modify(int id)
        {
            if (id <= 0)
            {
                HumanClass human = new HumanClass { };
                return View(human);
            }
            var CheckHuman = await _unitOfWork.HumanClasses.FindByCriteria(m=> m.Id == id);
            if (CheckHuman is null)
                return NotFound();
            return View(CheckHuman);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modify(HumanClass humanClass)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            if (humanClass.Name == null)
            {
                ModelState.AddModelError("Name", "Name is Empty!");
                return View(humanClass);
            }

            if (await _unitOfWork.HumanClasses.CheckAny(n => n.Name == humanClass.Name))
            {
                ModelState.AddModelError("Name", "Name is Exist !");
                return View(humanClass);
            }


            if (humanClass.Id <= 0)
            {
                HumanClass human = new HumanClass
                {
                    Name = humanClass.Name
                };
                await _unitOfWork.HumanClasses.Add(human);
            }
            else
            {
                var human = await _unitOfWork.HumanClasses.FindByCriteria(m => m.Id == humanClass.Id);

                if (human is null)
                    return NotFound();

                human.Name = humanClass.Name;
            }
            await _unitOfWork.Complete();
            await _unitOfWork.caching.SetItems(NameModels.HumanClass, await _unitOfWork.getListItems.HumanClass());

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
                return BadRequest();

           HumanClass? humanClass = await _unitOfWork.HumanClasses.FindByCriteria(m => m.Id == Id);
            if (humanClass == null)
                return NotFound();
            _unitOfWork.HumanClasses.Remove(humanClass);
            await _unitOfWork.Complete();
            await _unitOfWork.caching.SetItems(NameModels.HumanClass, await _unitOfWork.getListItems.HumanClass());

            return Ok();
        }
    }
}
