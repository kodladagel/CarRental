using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.RentDate).NotEmpty().LessThanOrEqualTo(DateTime.Now).WithMessage("Kiralama tarihi bugünden sonraki bir tarih olamaz.");
            RuleFor(r => r.ReturnDate).GreaterThanOrEqualTo(r => r.RentDate).WithMessage("Aracın teslim tarihi kiralama tarihinden önce olamaz.");
            RuleFor(r => r.ReturnDate).NotEmpty();
        }
    }
}
