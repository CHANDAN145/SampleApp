using System;
namespace Services
{
    public class ValidationService : IValidationService
    {
        public bool ValidateItem(object obj)
        {
            return obj == null;
        }
    }
}
