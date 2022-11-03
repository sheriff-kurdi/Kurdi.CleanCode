using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Kurdi.CleanCode.Core.Contracts;
using Kurdi.CleanCode.Core.Entities.StockAggregate;

namespace Kurdi.CleanCode.Services;

public class StockItemService
{
    private readonly IStockItemsRepo _stockItemsRepo;

    public StockItemService(IStockItemsRepo stockItemsRepo)
    {
        _stockItemsRepo = stockItemsRepo;
    }

    public List<StockItem> FindAll()
    {
        var s = _stockItemsRepo.FindAll().ToList();
        return s;
    }
}