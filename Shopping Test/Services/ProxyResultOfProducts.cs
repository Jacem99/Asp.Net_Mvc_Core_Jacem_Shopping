
using Microsoft.EntityFrameworkCore;

namespace Shopping_Test.Services
{
    public class ProxyResultOfProducts : IProxyResultOfProducts
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConditionClassification _ConditionClass;

        public ProxyResultOfProducts(
            IConditionClassification ConditionClass ,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _ConditionClass = ConditionClass;
        }
        public async Task<classificationsOfProducts> GetResultOfProducts(ClassProduct classProduct)
        {

            classificationsOfProducts classifyOfProducts = new classificationsOfProducts
            {
                ClothesClassifications = await _unitOfWork.ClothesClassifications.GetAll(c => c.Name, OrderBy.Ascending),
                HumanClassifications = await _unitOfWork.HumanClasses.GetAll(m => m.Name, OrderBy.Ascending),
                AgeStages = await _unitOfWork.AgeStages.GetAll(a => a.Name, OrderBy.Ascending),
                userProducts = await _unitOfWork.UserProducts.GetAll()
            };

            classifyOfProducts.Product = await _ConditionClass.Condition(classProduct).AsSplitQuery().AsNoTracking().ToListAsync();
            return classifyOfProducts;

        }
    }
}
