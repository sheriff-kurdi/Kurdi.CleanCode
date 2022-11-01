using Kurdi.CleanCode.Core.Contracts;
using Kurdi.CleanCode.Infrastructure.Data;
using Kurdi.CleanCode.Core.Entities.StockAggregate;

namespace Kurdi.CleanCode.Infrastructure.DataAccess
{
    public class StockItemsRepo : RepoBase<StockItem> , IStockItemsRepo
    {
        public StockItemsRepo(AppDbContext db) : base(db)
        {

        }
    }
}
