
using Microsoft.EntityFrameworkCore;

namespace Shopping_Test.Services
{
    public class ProxyResultOfProducts : IProxyResultOfProducts
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetSelectListItems _getSelectListItems;
        private readonly IConditionClassification _ConditionClass;

        public ProxyResultOfProducts(IGetSelectListItems getSelectListItems,
            IConditionClassification ConditionClass ,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          _getSelectListItems = getSelectListItems;
            _ConditionClass = ConditionClass;
        }
        public async Task<classificationsOfProducts> GetResultOfProducts(ClassProduct classProduct)
        {

            classificationsOfProducts classifyOfProducts = new classificationsOfProducts
            {
                ClothesClassifications = await _getSelectListItems.ClothsCalssification(),
                HumanClasses = await  _getSelectListItems.HumanClass(),
                AgeStages = await _getSelectListItems.AgeStages(),
                userProducts = await _unitOfWork.UserProducts.GetAll()
            };

            classifyOfProducts.Product = await _ConditionClass.Condition(classProduct).AsSplitQuery().AsNoTracking().ToListAsync();
            return classifyOfProducts;

        }
    }
}
