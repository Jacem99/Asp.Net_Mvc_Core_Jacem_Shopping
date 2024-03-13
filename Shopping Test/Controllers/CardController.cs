
namespace Shopping_Test.Controllers
{
   /*[Authorize]*/
    public class CardController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public CardController(
        UserManager<ApplicationUser> userManager ,
         IUnitOfWork unitOfWork)
        {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        }
        public async Task< IActionResult> Index()
        {
          
            string? IdUser = _userManager.GetUserId(User);
            IEnumerable<Card> Cards = new List<Card>();
            try
            {
                Cards = await _unitOfWork.Cards.GetAll(u => u.ApplicationUserId == IdUser && u.Favourite == true, new[] { "Products"});
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
           
             return View(Cards);
        }
        public async Task<ActionResult> Favourite()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var favourite = await _unitOfWork.Cards.GetAll(c => c.ApplicationUserId == userEmail && c.Favourite == true);
            return View(favourite);
        }
        public async Task<ActionResult> Buy()
        {
            string? idUser = _userManager.GetUserId(User);

            var buyedCards = await _unitOfWork.Cards.GetAll(u => u.ApplicationUserId == idUser && u.Buyed == true,new[] { "Products" });
            return View(buyedCards);
        }


        private string? UserId() =>  User.FindFirstValue(ClaimTypes.NameIdentifier);

        [HttpGet]
        public ActionResult UserIsSigned()
        {
            if (UserId() == null)
            {
                return Ok("NotLogin");
            };
            return Ok("Login");
        }

            [AllowAnonymous]
        public async Task<ActionResult> addFavourite(string Id)
        {
            ///Identity/Account/Login
            
            int productId = Convert.ToInt32(Id);
            UserProducts userProducts = new UserProducts
            {
                ApplicationUserId = UserId(),
                ProductId = productId
            };
            var checkFavourite = await _unitOfWork.Cards.FindByCriteria(f => f.ApplicationUserId == UserId() && f.ProductId == productId );
            if (checkFavourite is null)
            {
                Card card = new Card
                {
                    Favourite = true,
                    Buyed = false,
                    ApplicationUserId = UserId(),
                    ProductId = productId,
                    mount = 1
                };
                try
                {
                    await _unitOfWork.Cards.Add(card);
                    await _unitOfWork.Complete();
                    await _unitOfWork.UserProducts.Add(userProducts);
                    await _unitOfWork.Complete();
                }
                catch(Exception ex) {
                    return Ok(ex.Message);
                }
               
                return Ok();
            }
           
            if (checkFavourite.Buyed == true && checkFavourite.Favourite == false)
            {
                checkFavourite.Favourite = true;
                await _unitOfWork.UserProducts.Add(userProducts);
                await _unitOfWork.Complete();
            }
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> addBuyed(addBuyed addBuyed)
        {
           
            var checkBuyed = await _unitOfWork.Cards.FindByCriteria(f => f.ApplicationUserId == UserId() &&  f.ProductId == addBuyed.ProductId );
            if (checkBuyed is not null)
            {
                if (checkBuyed.Favourite==true && checkBuyed.Buyed==false)
                {
                    checkBuyed.Buyed = true;
                    checkBuyed.mount = addBuyed.ValueMount;
                    await _unitOfWork.Complete();
                    return Ok();
                }
                else if(checkBuyed.Favourite == true && checkBuyed.Buyed == true)
                {
                    checkBuyed.mount = addBuyed.ValueMount;
                    await _unitOfWork.Complete();
                    return Ok();
                 }
                }
                return Ok();
        }

        public async Task<IActionResult> Delete(string id)
        {
            int Id = Convert.ToInt32(id);
            var card = await _unitOfWork.Cards.FindByCriteria(c=> c.Id == Id);
            if (card is null)
            {
                return Ok();
            }
            _unitOfWork.Cards.Remove(card);
           await _unitOfWork.Complete();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFavourite(string id)
        {
            var productId = Convert.ToInt32(id);
            var card = await _unitOfWork.Cards.FindByCriteria(c=> c.ApplicationUserId == UserId() && c.ProductId == productId);
            if (card is null)
            {
                return Ok();
            }
            UserProducts userProducts =await _unitOfWork.UserProducts.FindByCriteria(u =>u.ApplicationUserId == card.ApplicationUserId && u.ProductId == card.ProductId);

            if(card.Favourite ==true && card.Buyed == false)
            {
                if (userProducts != null)
                    _unitOfWork.UserProducts.Remove(userProducts);

                _unitOfWork.Cards.Remove(card);
            }
            else if(card.Favourite == true && card.Buyed == true)
            {
                card.Favourite = false;
                if (userProducts != null)
                    _unitOfWork.UserProducts.Remove(userProducts);
            }
            await _unitOfWork.Complete();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBuyed(int id)
        {
            var Id = Convert.ToInt32(id);
            var card = await _unitOfWork.Cards.FindByCriteria(c => c.Id == id);
            if (card is null)
            {
                return Ok();
            }
            card.Buyed = false;
           await _unitOfWork.Complete();
            return Ok();
        }

    }
}

