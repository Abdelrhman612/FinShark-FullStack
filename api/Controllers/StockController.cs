using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.dto;
using api.Models;
using FinShark.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.Controllers
{

    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly StockService _service;

        public StockController(StockService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            return await _service.GetStocks();
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStock([FromRoute] int id)
        {
            return await _service.GetStock(id);
        }
        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] CreateStockDto createStockDto)
        {
            return await _service.AddStock(createStockDto);
        }




    }
}