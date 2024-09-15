using AutoMapper;
using Infrastructures.Mappers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMapper _mapper;

    // Inject AutoMapper thông qua constructor
    public ProductsController(IMapper mapper)
    {
        _mapper = mapper;
    }

    // POST: api/products
    [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductDto productDto)
    {
        // Sử dụng AutoMapper để map từ ProductDto sang Product
        var product = _mapper.Map<Product>(productDto);

        // Thực hiện logic lưu vào database ở đây (ví dụ chỉ là lưu vào danh sách)
        // Lưu trữ tạm thời để mô phỏng
        return Ok(product);  // Trả về product đã được map
    }
}
