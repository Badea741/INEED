using FluentValidation;
using INEED.WebAPI.Models;

namespace INEED.WebAPI.Validators;
public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Name).NotEmpty().WithMessage("Please provide your name");
        RuleFor(customer => customer.Email).NotEmpty().Length(1, 100).EmailAddress().WithMessage("Invalid Email Address");
        RuleFor(customer => customer.PhoneNumber).NotEmpty().MaximumLength(13).Must(BePhoneNumber).WithMessage("Invalid Phone number");
    }
    private bool BePhoneNumber(string phoneNumber)
    {
        bool valid = true;
        phoneNumber.ToCharArray().ToList().ForEach(c =>
        {
            int item = c - '0';
            if (item < 0 || item > 9)
                valid = false;
        });
        return valid;
    }
}