
namespace Shopping_Test.IServices
{
    public interface IConditionClassification
    {
        IQueryable<Product> Condition(ClassProduct classProduct);
    }
}
