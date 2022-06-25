using Bogus;
using FluentAssertions;
using MercadoLivre.Clone.Business.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MercadoLivre.Clone.Bussiness.Test;

public class ProductEntityTest
{
    [Theory(DisplayName = "Lança exception quando nome do produto não existe")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void test(string name)
    {
        var action = () => new ProductBuild()
            .WithRandomAvailableQuantity()
            .WithRandomDescription()
            .WithRandomCategory()
            .WithRandomFeatures()
            .WithRandomPrice()
            .WithName(name)
            .Build();

        action.Should().Throw<Exception>();
    }

    [Theory(DisplayName = "Lança exception quando preço é menor do que zero")]
    [InlineData(0)]
    [InlineData(-1)]
    public void tests(decimal price)
    {
        var action = () => new ProductBuild()
            .WithRandomAvailableQuantity()
            .WithRandomDescription()
            .WithRandomCategory()
            .WithRandomFeatures()
            .WithRandomName()
            .WithPrice(price)
            .Build();

        action.Should().Throw<Exception>();
    }

    public class ProductBuild
    {
        private Faker Faker = new Faker("pt_BR");

        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public List<string>? Features { get; set; }
        public string? Description { get; set; }
        public CategoryEntity Category { get; set; }

        public ProductEntity Build()
        {
            return new ProductEntity(Name, Price, AvailableQuantity, Features, Description, Category);
        }

        public ProductBuild WithRandomName()
        {
            Name = Faker.Commerce.ProductName();
            return this;
        }

        public ProductBuild WithName(string name)
        {
            Name = name;
            return this;
        }

        public ProductBuild WithRandomPrice()
        {
            Price = decimal.Parse(Faker.Commerce.Price(1));
            return this;
        }

        public ProductBuild WithPrice(decimal price)
        {
            Price = price;
            return this;
        }

        public ProductBuild WithRandomAvailableQuantity()
        {
            AvailableQuantity = Faker.Random.Number(int.MaxValue);
            return this;
        }

        public ProductBuild WithAvailableQuantity(int quantity)
        {
            AvailableQuantity = quantity;
            return this;
        }

        public ProductBuild WithRandomFeatures()
        {
            Features = Faker.Random.WordsArray(3, 10).ToList();
            return this;
        }

        public ProductBuild WithFeatures(List<string> features)
        {
            Features = features;
            return this;
        }

        public ProductBuild WithRandomDescription()
        {
            Description = Faker.Commerce.ProductDescription();
            return this;
        }

        public ProductBuild WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public ProductBuild WithRandomCategory()
        {
            var categoryName = Faker.Commerce.Categories(1).FirstOrDefault();
            Category = new CategoryEntity(categoryName);
            return this;
        }

        public ProductBuild WithCategory(string categoryName)
        {
            Category = new CategoryEntity(categoryName);
            return this;
        }

    }
}
