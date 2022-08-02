using INEED.WebAPI.Models;

namespace INEED.WebAPI.Repositories;
public interface ICustomerRepo : IRepo<Customer>
{
    Customer GetByPhoneNumber(string phoneNumber);
    void DeleteByPhoneNumber(string PhoneNumber);

}