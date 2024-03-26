using Services.Factories;
using Models;
using Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
namespace TestModels
{
    [TestClass]
    public class TestInventory
    {

        [TestMethod]
        public void Test_Instantiate()
        {
            Inventory inventory = new Inventory();
            Assert.AreEqual(0, inventory.Items.Count);
        }
        [TestMethod]
        public void Test_AddItem()
        {
            Inventory inventory = new Inventory();
            Inventory inventory1 = inventory.AddItem(ItemFactory.CreateGameItem(3001));
            Assert.AreEqual(1, inventory1.Items.Count);
        }
        [TestMethod]
        public void Test_AddItems()
        {
            Inventory inventory = new Inventory();
            List<GameItem> itemsToAdd = new List<GameItem>();
            itemsToAdd.Add(ItemFactory.CreateGameItem(3001));
            itemsToAdd.Add(ItemFactory.CreateGameItem(3002));
            Inventory inventory1 =
                inventory.AddItems(itemsToAdd);
            Assert.AreEqual(2, inventory1.Items.Count);
            // Notice the used of chained AddItemFromFactory() calls
            Inventory inventory2 =
                inventory1
                    .AddItem(ItemFactory.CreateGameItem(3001))
                    .AddItem(ItemFactory.CreateGameItem(3002));
            Assert.AreEqual(4, inventory2.Items.Count);
        }
        [TestMethod]
        public void Test_AddItemQuantities()
        {
/*            Inventory inventory = new Inventory();
            Inventory inventory1 =
                inventory.AddItems(new List<ItemQuantity> { new ItemQuantity(ItemFactory.CreateGameItem(1001), 3) });
            Assert.AreEqual(3, inventory1.Items.Count(i => i.ItemTypeID == 1001));
            Inventory inventory2 =
                inventory1.AddItem(ItemFactory.CreateGameItem(1001));
            Assert.AreEqual(4, inventory2.Items.Count(i => i.ItemTypeID == 1001));
            Inventory inventory3 =
                inventory2.AddItems(new List<ItemQuantity> { new ItemQuantity(ItemFactory.CreateGameItem(1002), 1) });
            Assert.AreEqual(4, inventory3.Items.Count(i => i.ItemTypeID == 1001));
            Assert.AreEqual(1, inventory3.Items.Count(i => i.ItemTypeID == 1002));*/
        }
        [TestMethod]
        public void Test_RemoveItem()
        {
            Inventory inventory = new Inventory();
            GameItem item1 = ItemFactory.CreateGameItem(3001);
            GameItem item2 = ItemFactory.CreateGameItem(3002);
            Inventory inventory1 =
                inventory.AddItems(new List<GameItem> { item1, item2 });
            Inventory inventory2 =
                inventory1.RemoveItem(item1);
            Assert.AreEqual(1, inventory2.Items.Count);
        }
        [TestMethod]
        public void Test_RemoveItems()
        {
            Inventory inventory = new Inventory();
            GameItem item1 = ItemFactory.CreateGameItem(3001);
            GameItem item2 = ItemFactory.CreateGameItem(3002);
            GameItem item3 = ItemFactory.CreateGameItem(3002);
            Inventory inventory1 =
                inventory.AddItems(new List<GameItem> { item1, item2, item3 });
            Inventory inventory2 =
                inventory1.RemoveItems(new List<GameItem> { item2, item3 });
            Assert.AreEqual(1, inventory2.Items.Count);
        }
        [TestMethod]
        public void Test_CategorizedItemProperties()
        {
            // Initial empty inventory
            Inventory inventory = new Inventory();
            Assert.AreEqual(0, inventory.Weapons.Count);
            Assert.AreEqual(0, inventory.Consumables.Count);
            // Add a pointy stick (weapon)
            Inventory inventory1 = inventory.AddItem(ItemFactory.CreateGameItem(1001));
            Assert.AreEqual(1, inventory1.Weapons.Count);
            Assert.AreEqual(0, inventory1.Consumables.Count);
            // Add oats (NOT a consumable)
            Inventory inventory2 = inventory1.AddItem(ItemFactory.CreateGameItem(3001));
            Assert.AreEqual(1, inventory2.Weapons.Count);
            Assert.AreEqual(0, inventory2.Consumables.Count);
            // Add a rusty sword (weapon)
            Inventory inventory3 = inventory2.AddItem(ItemFactory.CreateGameItem(1002));
            Assert.AreEqual(2, inventory3.Weapons.Count);
            Assert.AreEqual(0, inventory3.Consumables.Count);
            // Add a granola bar (IS a consumable)
            Inventory inventory4 = inventory3.AddItem(ItemFactory.CreateGameItem(2001));
            Assert.AreEqual(2, inventory4.Weapons.Count);
            Assert.AreEqual(1, inventory4.Consumables.Count);
        }
        [TestMethod]
        public void Test_RemoveItemQuantities()
        {
            // Initial empty inventory
            Inventory inventory = new Inventory();
            Assert.AreEqual(0, inventory.Weapons.Count);
            Assert.AreEqual(0, inventory.Consumables.Count);
            Inventory inventory2 =
                inventory
                    .AddItem(ItemFactory.CreateGameItem(1001))
                    .AddItem(ItemFactory.CreateGameItem(1002))
                    .AddItem(ItemFactory.CreateGameItem(1002))
                    .AddItem(ItemFactory.CreateGameItem(1002))
                    .AddItem(ItemFactory.CreateGameItem(1002))
                    .AddItem(ItemFactory.CreateGameItem(3001))
                    .AddItem(ItemFactory.CreateGameItem(3001));
            Assert.AreEqual(1, inventory2.Items.Count(i => i.ItemTypeID == 1001));
            Assert.AreEqual(4, inventory2.Items.Count(i => i.ItemTypeID == 1002));
            Assert.AreEqual(2, inventory2.Items.Count(i => i.ItemTypeID == 3001));
            Inventory inventory3 =
                inventory2
                    .RemoveItems(new List<ItemQuantity> { new ItemQuantity(ItemFactory.CreateGameItem(1002), 2) });
            Assert.AreEqual(1, inventory3.Items.Count(i => i.ItemTypeID == 1001));
            Assert.AreEqual(2, inventory3.Items.Count(i => i.ItemTypeID == 1002));
            Assert.AreEqual(2, inventory3.Items.Count(i => i.ItemTypeID == 3001));
            Inventory inventory4 =
                inventory3
                    .RemoveItems(new List<ItemQuantity> { new ItemQuantity(ItemFactory.CreateGameItem(1002), 1) });
            Assert.AreEqual(1, inventory4.Items.Count(i => i.ItemTypeID == 1001));
            Assert.AreEqual(1, inventory4.Items.Count(i => i.ItemTypeID == 1002));
            Assert.AreEqual(2, inventory4.Items.Count(i => i.ItemTypeID == 3001));
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_RemoveItemQuantities_RemoveTooMany()
        {
            // Initial empty inventory
            Inventory inventory = new Inventory();
            Assert.AreEqual(0, inventory.Weapons.Count);
            Assert.AreEqual(0, inventory.Consumables.Count);
            Inventory inventory2 =
                inventory
                    .AddItem(ItemFactory.CreateGameItem(1001))
                    .AddItem(ItemFactory.CreateGameItem(1002))
                    .AddItem(ItemFactory.CreateGameItem(1002))
                    .AddItem(ItemFactory.CreateGameItem(1002))
                    .AddItem(ItemFactory.CreateGameItem(1002))
                    .AddItem(ItemFactory.CreateGameItem(3001))
                    .AddItem(ItemFactory.CreateGameItem(3001));
            Assert.AreEqual(1, inventory2.Items.Count(i => i.ItemTypeID == 1001));
            Assert.AreEqual(4, inventory2.Items.Count(i => i.ItemTypeID == 1002));
            Assert.AreEqual(2, inventory2.Items.Count(i => i.ItemTypeID == 3001));
            // Should throw an exception,
            // since we are trying to remove more items than exist in the inventory.
            Inventory inventory3 =
                inventory2
                    .RemoveItems(new List<ItemQuantity> { new ItemQuantity(ItemFactory.CreateGameItem(1002), 999) });
        }
    }
}