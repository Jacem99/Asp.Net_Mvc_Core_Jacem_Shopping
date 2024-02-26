
namespace Shopping_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProxyResultOfProducts _proxyResultOfProducts;
        private readonly IProcessImage _processImage;
        private readonly IGetSelectListItems _getSelectListItems;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IProxyResultOfProducts proxyResultOfProducts,
                              IProcessImage processImage,
                              IUnitOfWork unitOfWork,
                              IGetSelectListItems getSelectListItems)
        {
            _proxyResultOfProducts = proxyResultOfProducts;
            _processImage = processImage;
            _unitOfWork = unitOfWork;
            _getSelectListItems = getSelectListItems;
        }


        public async Task<IActionResult> Index(ClassProduct classProduct)
        {
            // using redis without it 
            return View(await _proxyResultOfProducts.GetResultOfProducts(classProduct));
        }

        public async Task<IActionResult> Create()
        {
            ViewProducts viewProducts = new ViewProducts { };
            return View(await GetSelectItem(viewProducts));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewProducts viewProducts)
        {
            IFormFileCollection file = Request.Form.Files;

            if (!ModelState.IsValid)
                 return View(await GetSelectItem(viewProducts));
 
            if (viewProducts == null)
                return BadRequest();

            //CheckImageFile
            if( await checkImage(viewProducts ,file))
                return View(await GetSelectItem(viewProducts));

             if (await addProduct(viewProducts, file) < 0)
             {
                 ModelState.AddModelError("All","Some Wrong happend in Creation, Please try again");
                 return View(await GetSelectItem(viewProducts));
             }
 
           return RedirectToAction(nameof(Index));
        }
        private async Task<bool> checkImage(ViewProducts viewProducts, IFormFileCollection file)
        {
          
            if (!file.Any())
                ModelState.AddModelError("Image", "Please Select Image Product !");

            // go to IprocessImage => checkExtention();
            if (!_processImage.allowExtention(file))
                ModelState.AddModelError("Image", $"Must have one of extentions from {FileSettings.allowExtentenstions}");

            // go to IprocessImage => get stream.toArrayofImage(); 
            if (await _unitOfWork.Products.CheckAny(p => p.NameOfImage == viewProducts.Image.FileName))
                ModelState.AddModelError("Image", "File Exist !!");
            return false;
        }
        private async Task<ViewProducts> GetSelectItem(ViewProducts viewProducts)
        {
            viewProducts.Markas = await _getSelectListItems.Markas();
            viewProducts.ClothesClassifications = await _getSelectListItems.ClothsCalssification();
            viewProducts.AgeStage = await _getSelectListItems.AgeStages();
            return viewProducts;
        }
        private async Task<int> addProduct(ViewProducts viewProducts, IFormFileCollection file)
        {
            var nameOfFile = _processImage.nameOfFile(file[0]);

            Product product = new Product()
            {
                Name = viewProducts.Image.FileName,
                Title = viewProducts.product.Title,
                NameOfImage = nameOfFile,
                Price = viewProducts.product.Price,
                Size = ((EnumClasses.Sizing)Int16.Parse(viewProducts.product.Size)).ToString(),
                SizeNumber = viewProducts.product.SizeNumber,
                Discount = viewProducts.product.Discount,
                AgeStageId = viewProducts.AgeStageId,
                ClothesClassificationId = viewProducts.ClothesClassificationId,
                MarkaId = viewProducts.MarkaId
            };
            await _unitOfWork.Products.Add(product);
            return await _unitOfWork.Complete();
        }

    } 


    //Classfication Human
    /*{
   public async Task<IActionResult> Human(string Name)
        return View(await _dbContext.products.Include(p => p.Marka).Where()
            .Include(p => p.ClothesClassification).AsSplitQuery()
            .AsNoTracking().ToListAsync());
    }
  */
    //Classfication AgeStage
    /*{
   public async Task<IActionResult> AgeStage(string Name)
        return View(await _dbContext.products.Include(p => p.Marka).Where()
            .Include(p => p.ClothesClassification).AsSplitQuery()
            .AsNoTracking().ToListAsync());
    }
  */
}
