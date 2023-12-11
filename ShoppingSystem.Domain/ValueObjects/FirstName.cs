using ShoppingSystem.Domain.Errors;
using ShoppingSystem.Domain.Primitives;
using ShoppingSystem.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Domain.ValueObjects
{
    public sealed class FirstName : ValueObject
    {
        public const int MaxLength = 50;

        private FirstName(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<FirstName> Create(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                return Result.Failure<FirstName>(DomainErrors.FirstName.Empty);
            }

            if (firstName.Length > MaxLength)
            {
                return Result.Failure<FirstName>(DomainErrors.FirstName.TooLong);
            }

            return new FirstName(firstName);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
