using FluentValidation;
using System;
using System.Collections.Generic;

namespace FamilyScoreboard.DataModels {
    public class FamilyMember {
        public int Id { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }

    }

    public class FamilyMemeberValidator : AbstractValidator<FamilyMember> {
        public FamilyMemeberValidator() {
            RuleFor(_ => _.FirstName)
                .NotNull()
                .Length(2, 25);
            RuleFor(_ => _.LastName)
                .NotNull()
                .Length(2, 25);
            RuleFor(_ => _.PreferredName)
                .NotNull()
                .Length(2, 25);
            RuleFor(_ => _.DateOfBirth)
                .NotNull()
                .GreaterThan(new DateTimeOffset(1900, 1, 1, 1, 1, 1, new TimeSpan(0)));
        }
    }
}
