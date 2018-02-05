using Even3.Pratical.Test.Business.Interfaces.Dtos.Savers;
using Even3.Pratical.Test.Domain;
using Even3.Pratical.Test.Persistence.Interfaces;
using FluentValidation;
using System;

namespace Even3.Pratical.Test.Business.Confections
{
    internal class CollaboratorConfectionService : ReadConfectionService<Collaborator, long, ICollaboratorSaveDto>
    {
        public CollaboratorConfectionService(IDaoContext context) : base(context)
        {
        }

        protected override IValidator<ICollaboratorSaveDto> Validator
        {
            get
            {
                var validator = new InlineValidator<ICollaboratorSaveDto>();
                validator.RuleFor(e => e.Name).MinimumLength(5).MaximumLength(50).NotEmpty();
                validator.RuleFor(e => e.Email).MinimumLength(5).MaximumLength(50).EmailAddress().NotEmpty();
                validator.RuleFor(e => e.Registration).MinimumLength(5).MaximumLength(10).NotEmpty();
                return validator;
            }
        }

        protected override void EntityFromDto(Collaborator entity, ICollaboratorSaveDto dto, bool isNew)
        {
            entity.Name = dto.Name;
            entity.Email = dto.Email;
            entity.Registration = dto.Registration;
        }

        protected override void EntityToDto(ICollaboratorSaveDto dto, Collaborator entity)
        {
            dto.Name = entity.Name;
            dto.Email = entity.Email;
            dto.Registration = entity.Registration;
        }

        protected override Func<Collaborator, bool> FindOne(long key) => e => e.Id == key;
    }
}