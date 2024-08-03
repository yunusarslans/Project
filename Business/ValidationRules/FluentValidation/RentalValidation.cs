using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidation : AbstractValidator<Rental>
    {
        public RentalValidation()
        {
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.ReturnDate).NotEmpty();
            RuleFor(c => c.ReturnDate).NotEmpty();
        }
    }
}
