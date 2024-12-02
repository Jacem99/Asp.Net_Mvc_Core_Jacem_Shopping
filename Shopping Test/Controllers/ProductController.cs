
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
namespace Shopping_Test.Controllers
{
  /*  [Authorize(Roles = "Admin")]*/
    public class ProductController : Controller
    {

        private readonly List<string> _arrayOfExtentions = new() { ".png", ".jpg" };
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProcessImage _processImage;
        private readonly IProxyGetListItems _proxyGetListItems;
        private readonly IProxyResultOfProducts _proxyResultOfProducts;
        public ProductController(IProxyResultOfProducts proxyResultOfProducts,
            IUnitOfWork unitOfWork , IProcessImage processImage, IProxyGetListItems proxyGetListItems)
        {
            _unitOfWork = unitOfWork;
            _processImage = processImage;
            _proxyGetListItems = proxyGetListItems;
            _proxyResultOfProducts = proxyResultOfProducts;
    }


        public async Task<IActionResult> Index(ClassProduct classProduct)
        {
            // using redis without it      
            return View(await _proxyResultOfProducts.GetResultOfProducts(classProduct));
        }
        private async Task< IActionResult> Extention(ViewProducts viewProducts ,string view)
        {
            ModelState.AddModelError("product.Image", "Must have one of extentions from PNG,JPG ");
            return View(view, await GetSelectItems(viewProducts));
        }
        private async Task<IActionResult> Rate(ViewProducts viewProducts , string view)
        {
            ModelState.AddModelError("All", "Please Choice Rate less than or equal 5");
            return View(view, await GetSelectItems(viewProducts));
        }
        private async Task<IActionResult> Price(ViewProducts viewProducts , string view)
        {
            ModelState.AddModelError("All", "Please Enter price correct for product..!");
            return View(view, await GetSelectItems(viewProducts));
        }
       
        public async Task<IActionResult> Edit(int id)
        {
            ViewProducts viewProducts = new ViewProducts {};
            var vProduct = await GetSelectItems(viewProducts);
            vProduct.product = await _unitOfWork.Products.FindByCriteria(p => p.Id == id);
           return View(vProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ViewProducts viewProducts)
        {
            /*     if (!ModelState.IsValid)
          {
              return View(await GetSelectItem(viewProducts));
          } */
            var product = await _unitOfWork.Products.FindByCriteria(p=> p.Id == viewProducts.product.Id);
            if (product == null)
                return BadRequest();

            if (viewProducts == null)
                return BadRequest();

            var nameOfFile = _processImage.nameOfFile(viewProducts.Image);
            await _processImage.stream(FileSettings.imageProduct, viewProducts.Image , nameOfFile);

            product.Size = ((EnumClasses.Sizing)Int16.Parse(viewProducts.product.Size)).ToString();
            product.SizeNumber = viewProducts.product.SizeNumber;
          
            if(viewProducts.product.Rate > 5)
            {
                return await Rate(viewProducts, nameof(Edit));
            }
            if (viewProducts.product.Price < 0)
            {
                return await Price(viewProducts, nameof(Create));
            }

            product.Name = viewProducts.Image.FileName;
            product.Title = viewProducts.product.Title;
            product.Price = viewProducts.product.Price;
            product.Discount = viewProducts.product.Discount;
            product.AgeStageId = viewProducts.AgeStageId;
            product.ClothesClassificationId = viewProducts.ClothesClassificationId;
            product.HumanClassId = viewProducts.HumanClassId;
            product.MarkaId = viewProducts.MarkaId;
            product.Rate = viewProducts.product.Rate;
            product.NameOfImage = nameOfFile;

            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Create()
        {
            ViewProducts viewProducts = new ViewProducts { };
            return View(await GetSelectItems(viewProducts));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewProducts viewProducts)
        {
            /*     if (!ModelState.IsValid)
           {
               return View(await GetSelectItem(viewProducts));
           }
*/
            if (viewProducts.Image==null)
            {
                ModelState.AddModelError("product.Image", "Please Select Image Product !");
                return View(await GetSelectItems(viewProducts));
            }
            var nameOfFile = _processImage.nameOfFile(viewProducts.Image);
            await _processImage.stream(FileSettings.imageProduct,viewProducts.Image,nameOfFile);


      
            if (viewProducts == null)
                return BadRequest();

            if (viewProducts.product.Rate > 5)
            {
                return await Rate(viewProducts, nameof(Create));
            }
            if (viewProducts.product.Price < 0)
            {
                return await Price(viewProducts, nameof(Create));
            }
           
            Product product = new Product()
            {
                Name = nameOfFile,
                Title = viewProducts.product.Title,
                Price = viewProducts.product.Price,
                Size = ((EnumClasses.Sizing)Int16.Parse(viewProducts.product.Size)).ToString(),
                SizeNumber = viewProducts.product.SizeNumber,
                Discount = viewProducts.product.Discount,
                AgeStageId = viewProducts.AgeStageId,
                ClothesClassificationId = viewProducts.ClothesClassificationId,
                HumanClassId = viewProducts.HumanClassId,
                MarkaId = viewProducts.MarkaId,
                Rate = viewProducts.product.Rate,
                NameOfImage = nameOfFile,   
            };
            await _unitOfWork.Products.Add(product);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        private async Task<ViewProducts> GetSelectItems(ViewProducts viewProducts)
        {
            viewProducts.Markas = await _proxyGetListItems.Markas();
            viewProducts.ClothesClassifications = await _proxyGetListItems.ClothsCalssification();
            viewProducts.AgeStage = await _proxyGetListItems.AgeStages();
            viewProducts.HumanClasses = await _proxyGetListItems.HumanClass();
           
            return viewProducts;
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var product = await _unitOfWork.Products.FindByCriteria(p=> p.Id == Id);
            if(product is null)
            {
                return NotFound();
            };
            _unitOfWork.Products.Remove(product);
             await _unitOfWork.Complete();
            return Ok();
        }

    }
}
