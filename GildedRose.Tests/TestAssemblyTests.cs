using System.Collections.Generic;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {

        private readonly Inn _app;

        public TestAssemblyTests()
        {
            var app = new Inn{
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
                    new Item {Name = "Spoiled Milk", SellIn = 0, Quality = 8}
                }
            };
            _app = app;
        }

        [Fact]
        public void UpdateQuality_Given_Sulfuras_Quality_Unchanged()
        {
            //Act
            _app.UpdateQuality();
            var actual = _app.Items[3].Quality;
            var expected = 80;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UpdateQuality_Given_Expired_Item_Decrease_Quality_By_2()
        {
            //Arrange
            _app.UpdateQuality();

            //Act
            var actual = _app.Items[6].Quality;
            var expected = 6;

            //Assert
            Assert.Equal(expected, actual);
            
        }
    }
}