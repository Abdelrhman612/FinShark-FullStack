using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dto;
using api.dto.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMapper
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Sympol = stockModel.Sympol,
                CompanyName = stockModel.CompanyName,
                Price = stockModel.Price,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap

            };
        }
        public static Stock ToStockCreateDto(this CreateStockDto createStockDto)
        {
            return new Stock
            {
                Sympol = createStockDto.Sympol,
                CompanyName = createStockDto.CompanyName,
                Price = createStockDto.Price,
                LastDiv = createStockDto.LastDiv,
                Industry = createStockDto.Industry,
                MarketCap = createStockDto.MarketCap
            };
        }

    }
}