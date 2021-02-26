using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.ValidationRules.FluentValidation
{
    class BrandValidator:AbstractValidator<Brand>
    {

        public BrandValidator()
        {
            RuleFor(b => b.BrandName).NotEmpty();
        }
    }
}
