﻿using FluentAssertions;
using NUnit.Framework;

namespace PotterKata.Tests;

[TestFixture]
public class PriceCalculatorShould
{
    [TestCase(Book.First)]
    [TestCase(Book.Second)]
    [TestCase(Book.Third)]
    [TestCase(Book.Fourth)]
    [TestCase(Book.Fith)]
    public void each_book_cost_eight(Book book)
    {
        var shoppingCart = new ShoppingCart(book);

        var price = PriceCalculator.Calcule(shoppingCart);

        price.Should().Be(8);
    }


    [Test]
    public void two_different_books_have_a_right_discount()
    {
        var shoppingCart = new ShoppingCart(Book.First, Book.Second);

        var priceWithDiscount = PriceCalculator.Calcule(shoppingCart);

        priceWithDiscount.Should().Be(15.2m);
    }
    [Test]
    public void three_different_books_have_a_right_discount()
    {
        var shoppingCart = new ShoppingCart(Book.First, Book.Second, Book.Third);

        var priceWithDiscount = PriceCalculator.Calcule(shoppingCart);

        priceWithDiscount.Should().Be(21.6m);
    }
    [Test]
    public void four_different_books_have_a_right_discount()
    {
        var shoppingCart = new ShoppingCart(Book.First, Book.Second, Book.Third, Book.Fourth);

        var priceWithDiscount = PriceCalculator.Calcule(shoppingCart);

        priceWithDiscount.Should().Be(25.6m);
    }
    [Test]
    public void five_different_books_have_a_right_discount()
    {
        var shoppingCart = new ShoppingCart(Book.First, Book.Second, Book.Third, Book.Fourth, Book.Fith);

        var priceWithDiscount = PriceCalculator.Calcule(shoppingCart);

        priceWithDiscount.Should().Be(30m);
    }

    [Test]
    public void calcule_lowest_price_for_five_different_books_and_one_repeated()
    {
        var shoppingCart = new ShoppingCart(Book.First, Book.Second, Book.Third, Book.Fourth, Book.Fith, Book.First);

        var priceWithDiscount = PriceCalculator.Calcule(shoppingCart);

        priceWithDiscount.Should().Be(38m);
    }
    [Test]
    public void two_units_of_the_same_book_has_not_discount()
    {
        var shoppingCart = new ShoppingCart(Book.First, Book.First);

        var priceWithoutDiscount = PriceCalculator.Calcule(shoppingCart);

        priceWithoutDiscount.Should().Be(16);
    }



}
