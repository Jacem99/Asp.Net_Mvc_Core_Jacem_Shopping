
using Microsoft.Extensions.Caching.Distributed;

namespace Shopping_Test.CoreIUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IDistributedCache _distributedCache;
      
       
        public IBaseRepository<AgeStage> AgeStages { get; private set; }
        public IBaseRepository<ApplicationUser> ApplictaionUsers { get; private set; }
        public IBaseRepository<Card> Cards { get; private set; }
        public IBaseRepository<CardProduct> CardProducts { get; private set; }
        public IBaseRepository<ClothesClassification> ClothesClassifications { get; private set; }
        public IBaseRepository<HumanClass> HumanClasses { get; private set; }
        public IBaseRepository<Marka> Markas { get; private set; }
        public IBaseRepository<PaymentDetail> PaymentDetails { get; private set; }
        public IBaseRepository<Product> Products { get; private set; }
        public IBaseRepository<RevesationSystem> RevesationSystems { get; private set; }
        public IBaseRepository<UserProducts> UserProducts { get; private set; }

        public ICaching caching {get; private set;}
        public IGetListItems getListItems {get; private set;}

        public UnitOfWork(ApplicationDbContext context, IDistributedCache distributedCache)
        {
            _context = context;
            _distributedCache = distributedCache;
            getListItems = new GetListItems(_context);
            caching = new Caching(_context, _distributedCache);

            AgeStages = new BaseRepository<AgeStage>(_context);
            ApplictaionUsers = new BaseRepository<ApplicationUser>(_context);
            Cards = new BaseRepository<Card>(_context);
            CardProducts = new BaseRepository<CardProduct>(_context);
            ClothesClassifications = new BaseRepository<ClothesClassification>(_context);
            HumanClasses = new BaseRepository<HumanClass>(_context);
            Markas = new BaseRepository<Marka>(_context);
            PaymentDetails = new BaseRepository<PaymentDetail>(_context);
            Products = new BaseRepository<Product>(_context);
            RevesationSystems = new BaseRepository<RevesationSystem>(_context);
            UserProducts = new BaseRepository<UserProducts>(_context);
          
        }

        public void Dispose() { _context.Dispose(); }

        public async Task<int> Complete() => await _context.SaveChangesAsync();
      
    }
}
