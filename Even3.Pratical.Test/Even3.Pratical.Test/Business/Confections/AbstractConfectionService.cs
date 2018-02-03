using Even3.Pratical.Test.Business.Interfaces;
using Even3.Pratical.Test.Persistence.Interfaces;
using Even3.Pratical.Test.Properties;
using FluentValidation;
using System;
using System.Text;

namespace Even3.Pratical.Test.Business.Confections
{
    internal abstract class AbstractConfectionService<T, TDto> : IConfectionService<TDto>
        where T : class
    {
        protected IDaoContext Context { get; private set; }
        protected IDao<T> Dao { get; private set; }
        protected IValidator<TDto> Validator { get; private set; }

        public AbstractConfectionService(IDaoContext context, IValidator<TDto> validator = null)
        {
            Context = context;
            Dao = context.CreateDao<T>();
            Validator = validator;
        }

        public virtual void Create(TDto dto)
        {
            Validate(dto);

            var entity = Dao.Create();

            EntityFromDto(entity, dto, true);

            Dao.Add(entity);

            Context.SaveChanges();
        }

        protected void Validate(TDto dto)
        {
            if (Validator != null)
            {
                var validationResult = Validator.Validate(dto);

                if (!validationResult.IsValid)
                {
                    var stringBuilder = new StringBuilder();
                    stringBuilder.AppendFormat("{0}:", Resource.Validation);

                    foreach (var error in validationResult.Errors)
                    {
                        stringBuilder.AppendFormat("\r\n -- {0}", error.ErrorMessage);
                    }

                    throw new Exception(stringBuilder.ToString());
                }
            }
        }

        protected abstract void EntityFromDto(T entity, TDto dto, bool isNew);
    }
}