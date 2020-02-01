using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyScoreboard.DataModels {
    public class Task {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointValue { get; set; }

    }

    public class TaskValidator : AbstractValidator<Task> {
        public TaskValidator() {
            RuleFor(_ => _.Name)
                .NotNull()
                .Length(3, 25);
            RuleFor(_ => _.Description)
                .NotNull()
                .Length(10, 255);
            RuleFor(_ => _.PointValue)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
