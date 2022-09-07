using CleanArchMVC.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Invalid Name: name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Name: minimum 3 characters.");

            Name = name;
        }

        public void ToUpdate(string name)
        {
            ValidateDomain(name);
            Name = name;
        }
    }
}
