using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        [HttpPost]
        public async Task Add()
        {
            Order order = await _orderReadRepository.GetByIdAsync("3a3d7227-68ec-4a56-9cc6-fbb5cfbdc92b");
            order.Address = "İstanbul";
           await _orderWriteRepository.SaveAsync();
        }

        [HttpGet]
        public IActionResult GetProduts()
        {
            var product = _productReadRepository.GetAll();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduts(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);

        }

    }
}
