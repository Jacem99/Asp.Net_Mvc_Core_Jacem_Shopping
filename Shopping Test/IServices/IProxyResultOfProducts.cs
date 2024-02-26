namespace Shopping_Test.IServices
{
    public interface IProxyResultOfProducts
    {
        Task<classificationsOfProducts> GetResultOfProducts(ClassProduct classProduct);
    }
}
