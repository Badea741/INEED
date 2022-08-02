using INEED.WebAPI.Helpers;
using INEED.WebAPI.Repositories;
using INEED.WebAPI.Validators;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    public CustomerController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public IActionResult Get([FromQuery] string phoneNumber)
    {
        return Ok(_unitOfWork.CustomerRepo.GetByPhoneNumber(phoneNumber).AsDto());
    }
    [HttpPost]
    public IActionResult Add([FromBody] CustomerDto customer)
    {
        var validator = new CustomerValidator();
        var results = validator.Validate(customer.AsNormal());
        if (results.IsValid)
        {
            _unitOfWork.CustomerRepo.Add(customer.AsNormal());
            return Ok(_unitOfWork.Save());
        }
        return BadRequest(results.Errors);
    }
}