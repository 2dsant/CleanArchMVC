using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMVC.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValideState()
        {
            Action action = () => new Category(1, "Category 1");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category 1");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name: minimum 3 characters.");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name: name is required.");
        }

        [Fact]
        public void CreateCategory_WithNullName_ValidObject()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}
