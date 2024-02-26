

namespace Shopping_Test.Controllers
{
    /*[Authorize(Roles = "Admin")]*/
    public class AgeStagesController : Controller
    {
     
        private readonly IUnitOfWork _unitOfWork;

        public AgeStagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index() => View(await _unitOfWork.AgeStages.GetAll(n => n.Name, OrderBy.Ascending));
        

        public async Task<IActionResult> Modify(int id)
        {
            if (id <= 0)
            {
                AgeStage ageStage = new AgeStage { };
                return View(ageStage);
            }
            var CheckHuman = await _unitOfWork.AgeStages.FindByCriteria(m=> m.Id == id);
            if (CheckHuman is null)
                return NotFound();
            return View(CheckHuman);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modify(AgeStage AgeStage)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            if (AgeStage.Name == null)
            {
                ModelState.AddModelError("Name", "Name is Empty!");
                return View(AgeStage);
            }

            if (await _unitOfWork.AgeStages.CheckAny(n => n.Name == AgeStage.Name))
            {
                ModelState.AddModelError("Name", "Name is Exist !");
                return View(AgeStage);
            }


            if (AgeStage.Id <= 0)
            {
                AgeStage ageStage = new AgeStage
                {
                    Name = AgeStage.Name
                };
                await _unitOfWork.AgeStages.Add(ageStage);
            }
            else
            {
                var ageStage = await _unitOfWork.AgeStages.FindByCriteria(m => m.Id == AgeStage.Id);

                if (ageStage is null)
                    return NotFound();

                ageStage.Name = AgeStage.Name;
            }
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
                return BadRequest();

           AgeStage? AgeStage = await _unitOfWork.AgeStages.FindByCriteria(m => m.Id == Id);
            if (AgeStage == null)
                return NotFound();
            _unitOfWork.AgeStages.Remove(AgeStage);
            await _unitOfWork.Complete();
            return Ok();
        }
    }
}
