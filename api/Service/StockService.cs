using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.dto;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Service
{
    public class StockService
    {
        private readonly ApplicationDBContext _context;
        public StockService(ApplicationDBContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> GetStocks()
        {
            var stocks = (await _context.Stocks.ToListAsync()).Select(x => x.ToStockDto());
            return new OkObjectResult(stocks);
        }
        public async Task<IActionResult> GetStock(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                throw new Exception("Stock not found");

            }
            return new OkObjectResult(stock.ToStockDto());
        }
        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] CreateStockDto createStockDto)
        {
            var stock = createStockDto.ToStockCreateDto();
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return new CreatedAtActionResult(nameof(GetStock), null, new { id = stock.Id }, stock.ToStockDto());



        }

    }
}