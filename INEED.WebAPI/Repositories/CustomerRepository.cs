using INEED.WebAPI.Helpers;
using INEED.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace INEED.WebAPI.Repositories;
public class CustomerRepo : ICustomerRepo, IDisposable
{
    private readonly IneedContext db;
    public CustomerRepo(IneedContext context)
    {
        this.db = context;
    }

    public void Add(Customer customer)
    {
        db.Uniques.Add(customer.ExtractUniques());
        db.Customers.Add(customer);
    }

    public Customer GetByPhoneNumber(string phoneNumber)
    {
        return db.Customers.FirstOrDefault(c => c.PhoneNumber == phoneNumber)!;
    }
    public IQueryable<Customer> GetAll()
    {
        return db.Customers;
    }

    public void Delete(Customer customer)
    {
        db.Customers.Remove(customer);
    }

    public void DeleteByPhoneNumber(string PhoneNumber)
    {
        db.Customers.Remove(db.Customers.FirstOrDefault(c => c.PhoneNumber == PhoneNumber)!);
    }
    public void Update(Customer customer)
    {
        db.Customers.Update(customer);
    }

    public void Dispose()
    {
        db.Dispose();
    }

}