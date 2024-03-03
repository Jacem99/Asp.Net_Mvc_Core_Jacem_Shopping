
namespace Shopping_Test.Services
{
    public class ConditionClassfication : IConditionClassification
    {
        protected ApplicationDbContext _dbContext;
        public ConditionClassfication(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public IQueryable<Product> Condition(ClassProduct classProduct)
        {
            IQueryable<Product> resultProduct = _dbContext.Products;

            if (classProduct.ClothesClassificationsId > 0)
                resultProduct = resultProduct.Where(c => c.ClothesClassificationId == classProduct.ClothesClassificationsId);

            if (classProduct.AgeStagesId > 0)
                resultProduct = resultProduct.Where(c => c.AgeStageId == classProduct.AgeStagesId);

              if( classProduct.HumanClassificationsId > 0)
                resultProduct = resultProduct.Where(c => c.HumanClassId == classProduct.HumanClassificationsId);
            
            resultProduct = resultProduct.Include(p => p.Marka).Include(p => p.ClothesClassification).AsSplitQuery();

            return resultProduct;

        }
        /*  public IQueryable<Product> Condition(ClassProduct classProduct)
          {
              IQueryable<Product> resultProduct = _dbContext.products;

              if (classProduct.ClothesClassificationsId > 0 && classProduct.AgeStagesId > 0 && classProduct.HumanClassificationsId > 0)
              {
                  resultProduct = resultProduct.Where(c => c.ClothesClassificationId == classProduct.ClothesClassificationsId && c.HumanClassId == classProduct.HumanClassificationsId && c.AgeStageId == classProduct.AgeStagesId)
              }
              if (classProduct.ClothesClassificationsId > 0 && classProduct.HumanClassificationsId > 0 && classProduct.AgeStagesId == 0)
              {
                  resultProduct = resultProduct.Where(c => c.ClothesClassificationId == classProduct.ClothesClassificationsId && c.HumanClassId == classProduct.HumanClassificationsId);
              }
              if (classProduct.HumanClassificationsId > 0 && classProduct.AgeStagesId > 0 && classProduct.ClothesClassificationsId == 0)
              {
                  resultProduct = resultProduct.Where(c => c.HumanClassId == classProduct.HumanClassificationsId && c.AgeStageId == classProduct.AgeStagesId);
              }
              if (classProduct.ClothesClassificationsId > 0 && classProduct.AgeStagesId > 0 && classProduct.HumanClassificationsId == 0)
              {
                  resultProduct = resultProduct.Where(c => c.ClothesClassificationId == classProduct.ClothesClassificationsId && c.AgeStageId == classProduct.AgeStagesId);
              }
              if (classProduct.ClothesClassificationsId > 0 && classProduct.HumanClassificationsId == 0 && classProduct.AgeStagesId == 0)
              {
                  resultProduct = resultProduct.Where(c => c.ClothesClassificationId == classProduct.ClothesClassificationsId);
              }
              if (classProduct.HumanClassificationsId > 0 && classProduct.ClothesClassificationsId == 0 && classProduct.AgeStagesId == 0)
              {
                  resultProduct = resultProduct.Where(c => c.HumanClassId == classProduct.HumanClassificationsId);
              }
              if (classProduct.AgeStagesId > 0 && classProduct.HumanClassificationsId == 0 && classProduct.ClothesClassificationsId == 0)
              {
                  resultProduct = resultProduct.Where(c => c.AgeStageId == classProduct.AgeStagesId);
              }

              resultProduct = resultProduct.Include(p => p.Marka).Include(p => p.ClothesClassification).AsSplitQuery();

              return resultProduct;

          }*/
    }
}

/*
 c.ClothesClassificationId >0 ?
                c.ClothesClassificationId == classProduct.ClothesClassificationsId &&
                c.HumanClassId > 0 ?
                c.HumanClassId == classProduct.HumanClassificationsId &&
                c.AgeStageId >0 ? 
                c.AgeStageId == classProduct.AgeStagesId
 */