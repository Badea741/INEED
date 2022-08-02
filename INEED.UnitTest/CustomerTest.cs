using INEED.WebAPI.Models;
namespace INEED.UnitTest;
public class CustomerTest
{
    [Fact]
    public async void ADD_CUSTOMERSHOULDBEADDED_CHECKIFCUSTOMEREXIST()
    {
        for (int i = 0; i < 10; i++)
        {
            var customer = new Customer
            {
                PhoneNumber = "123434asd53345",
                Email = "Email33452asdfs5@gm4ail.com",
                Name = "Badea"
            };
            await Customer.Add(customer);
            await Customer.Remove(customer);
        }
    }
}