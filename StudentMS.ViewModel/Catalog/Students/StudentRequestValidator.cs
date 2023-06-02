using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.ViewModel.Catalog.Students
{
    public class StudentRequestValidator : AbstractValidator<StudentRequest>
    {
        public StudentRequestValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("The maximum length of a student's name is 100 characters.");
            RuleFor(x => x.Sex).MaximumLength(10).WithMessage("The maximum length of sex is 10 characters.");
            RuleFor(x => x.Address).MaximumLength(150).WithMessage("The maximum length of address is 150 characters.");
        }
    }
}
