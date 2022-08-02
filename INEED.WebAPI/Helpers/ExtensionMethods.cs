using INEED.WebAPI.Models;
using AutoMapper;

namespace INEED.WebAPI.Helpers;

public static class ExtensionMethods
{
    private static readonly IMapper _mapper = Startup.mapper;

    public static CustomerDto AsDto(this Customer customer)
    {
        return _mapper.Map<CustomerDto>(customer);
    }
    public static Customer AsNormal(this CustomerDto customerDto)
    {
        return _mapper.Map<Customer>(customerDto);
    }
    public static Unique ExtractUniques(this Customer customer)
    {
        return new Unique
        {
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
        };
    }
}
