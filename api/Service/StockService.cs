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

        public async Task<IActionResult> AddStock(CreateStockDto createStockDto)
        {
            var stock = createStockDto.ToStockCreateDto();
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return new CreatedAtActionResult(nameof(GetStock), null, new { id = stock.Id }, stock.ToStockDto());

        }
        public async Task<IActionResult> UpdateStock(int id, UpdateStockDto updateStockDto)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stock == null)
            {
                throw new Exception("Stock not found");
            }
            stock.Sympol = updateStockDto.Sympol;
            stock.CompanyName = updateStockDto.CompanyName;
            stock.Price = updateStockDto.Price;
            stock.LastDiv = updateStockDto.LastDiv;
            stock.Industry = updateStockDto.Industry;
            stock.MarketCap = updateStockDto.MarketCap;
            await _context.SaveChangesAsync();
            return new OkObjectResult(stock.ToStockDto());
        }
        public async Task<ActionResult> DeleteStock(int id)
        {

            var stock = await _context.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);

            if (stock == null)
            {
                return new NotFoundResult();
            }

            if (stock.Comments.Any())
            {
                _context.Comments.RemoveRange(stock.Comments);
            }
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

    }

}