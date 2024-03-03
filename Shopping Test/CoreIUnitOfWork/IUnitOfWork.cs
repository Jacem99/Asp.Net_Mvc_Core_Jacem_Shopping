

namespace Shopping_Test.CoreIUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<AgeStage> AgeStages { get; }
        IBaseRepository<ApplicationUser> ApplictaionUsers { get; }
        IBaseRepository<Card> Cards { get; }
        IBaseRepository<CardProduct> CardProducts { get; }
        IBaseRepository<ClothesClassification> ClothesClassifications { get; }
        IBaseRepository<HumanClass> HumanClasses { get; }
        IBaseRepository<Marka> Markas { get; }
        IBaseRepository<PaymentDetail> PaymentDetails { get; }
        IBaseRepository<Product> Products { get; }
        IBaseRepository<RevesationSystem> RevesationSystems { get; }
        IBaseRepository<UserProducts> UserProducts { get; }
        Task<int> Complete();

    }
}
