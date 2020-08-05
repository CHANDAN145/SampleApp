using System;
namespace Services
{
    public interface IValidationService
    {
        bool ValidateItem(object obj);
    }
}
