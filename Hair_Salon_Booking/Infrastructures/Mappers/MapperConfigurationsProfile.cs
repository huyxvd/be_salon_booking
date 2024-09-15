using Application.Commons;
using AutoMapper;

namespace Infrastructures.Mappers;
public class MapperConfigurationsProfile : Profile
{
    public MapperConfigurationsProfile()
    {
        CreateMap(typeof(Pagination<>), typeof(Pagination<>));
        CreateMap<ProductDto, Product>();
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class ProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

