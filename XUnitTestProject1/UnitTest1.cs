using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using ServiceProject.Models;
using ServiceProject.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void FilterOrdersToTop5Products_MultipleOrders_FilteredTo5Products()
        {
            //act
            var orders = new List<OrderModel>
            {
                new OrderModel{Lines = new List<Line>{ new Line { Gtin = "10", Quantity = 10 } } },
                new OrderModel{Lines = new List<Line>{ new Line { Gtin = "12", Quantity = 12 } } },
                new OrderModel{Lines = new List<Line>{ new Line { Gtin = "5", Quantity = 5 } } },
                new OrderModel{Lines = new List<Line>{ new Line { Gtin = "11", Quantity = 11 } } },
                new OrderModel{Lines = new List<Line>{ new Line { Gtin = "9", Quantity = 9 } } },
                new OrderModel{Lines = new List<Line>{ new Line { Gtin = "8", Quantity = 8 } } },
            };

            var orderFilterer = new OrderFilter();

            //assert
            var products = orderFilterer.FilterOrdersToTop5Products(orders);

            //arrange
            Assert.True(products.Count == 5);
        }

        [Fact]
        public void FilterOrdersToTop5Products_MultipleOrders_CombineProducts()
        {
            //act
            var orders = new List<OrderModel>
            {
                new OrderModel{Lines = new List<Line>{ new Line { Gtin = "10", Quantity = 10 } } },
                new OrderModel{Lines = new List<Line>{ new Line { Gtin = "12", Quantity = 12 } } },
                new OrderModel{Lines = new List<Line>{ new Line { Gtin = "5", Quantity = 5 } } },
                new OrderModel{Lines = new List<Line>{ new Line { Gtin = "5", Quantity = 5 } } },
                new OrderModel{Lines = new List<Line>{ new Line { Gtin = "11", Quantity = 11 } } },
                new OrderModel{Lines = new List<Line>{ new Line { Gtin = "9", Quantity = 9 } } },
            };

            var orderFilterer = new OrderFilter();

            //assert
            var products = orderFilterer.FilterOrdersToTop5Products(orders);

            //arrange
            Assert.True(products.Count == 5);
            Assert.True(products.Single(x => x.Gtin == "5").Stock == 10); 
        }
    }
}
