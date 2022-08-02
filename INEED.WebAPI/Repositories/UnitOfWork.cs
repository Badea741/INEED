using INEED.WebAPI.Models;

namespace INEED.WebAPI.Repositories;
public class UnitOfWork : IDisposable
{
    private readonly IneedContext db;
    public ICustomerRepo CustomerRepo;
    public UnitOfWork(IneedContext context, ICustomerRepo customerRepo)
    {
        db = context;
        CustomerRepo = customerRepo;
    }
    public bool Save()
    {
        try
        {
            db.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public void Dispose()
    {
        db.Dispose();
    }
}