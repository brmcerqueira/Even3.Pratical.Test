using System;
using Even3.Pratical.Test.Business.Interfaces.Dtos.Savers;
using Even3.Pratical.Test.Domain;
using Even3.Pratical.Test.Persistence.Interfaces;
using FluentValidation;

namespace Even3.Pratical.Test.Business.Confections
{
    internal class ShiftConfectionService : ReadConfectionService<Shift, int, IShiftSaveDto>
    {
        public ShiftConfectionService(IDaoContext context) : base(context)
        {
        }

        protected override IValidator<IShiftSaveDto> Validator
        {
            get
            {
                var validator = new InlineValidator<IShiftSaveDto>();
                validator.RuleFor(e => e.DayOfWeek).NotEmpty();
                validator.RuleFor(e => e.Input).NotEmpty();
                validator.RuleFor(e => e.Output).NotEmpty();
                validator.RuleFor(e => e.Interval).NotEmpty();
                return validator;
            }
        }

        protected override void EntityFromDto(Shift entity, IShiftSaveDto dto, bool isNew)
        {
            entity.DayOfWeek = dto.DayOfWeek;
            entity.Input = dto.Input;
            entity.Output = dto.Output;
            entity.Interval = dto.Interval;
        }

        protected override void EntityToDto(IShiftSaveDto dto, Shift entity)
        {
            dto.DayOfWeek = entity.DayOfWeek;
            dto.Input = entity.Input;
            dto.Output = entity.Output;
            dto.Interval = entity.Interval;
        }

        protected override Func<Shift, bool> FindOne(int key) => e => e.Id == key;

        protected override void SetupDelete(dynamic data, int key)
        {
            data.Id = key;
        }
    }
}