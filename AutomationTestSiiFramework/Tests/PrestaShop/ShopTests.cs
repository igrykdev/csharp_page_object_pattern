﻿using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Tests.PrestaShop.Pages;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.PrestaShop
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    internal class ShopTests : BaseTest
    {
        [Test]
        public void Shop_AddToCartDefineProduct_CheckThatInDetailsIsTheSameContentAsWeExpected()
        {
            var driver = Container.GetInstance<IWebDriver>();
            var homeShopPage = new HomeShopPage(driver);
            var product = homeShopPage.Go("http://5.196.7.235/").ChooseProductByName("HUMMINGBIRD TSHIRT").GetProduct();
            product.PriceOnlyValue.Should().Be(19.12);
            product.Price.Should().Be("$19.12");
            product.Name.Should().Be("HUMMINGBIRD TSHIRT");
        }

        [Test]
        public void Shop_AddToCartProductAndFillAWholeForm_CheckValidationAfterAddedOrder()
        {
            var driver = Container.GetInstance<IWebDriver>();
            var homeShopPage = new HomeShopPage(driver);
            var orderConfirmationPage = homeShopPage.Go("http://5.196.7.235/")
                .ChooseProductByName("HUMMINGBIRD TSHIRT")
                .SetSize("L")
                .SetQuantity(10).AddToCart().ClickOnProceedToCheckout().ConfirmProceedToCheckout()
                .FillPersonalInformation("name", "lastName", "kontakt+qa@testingplus.me", "Mrs.")
                .FillAddresses("fake address", "New York", "United States", "New York", "10100")
                .FillShippingMethod()
                .FillPaymentMethod("Pay by Check")
                .AcceptTermsOfService()
                .OrderWithObligationToPay();
            orderConfirmationPage.OrderSubtotal.Should().Be("$191.20");
        }
    }
}