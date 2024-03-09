﻿using Engine.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEngine.ViewModels
{
    [TestClass]
    public class TestGameSession
    {
        [TestMethod]
        public void TestCreateGameSession()
        {
            var gameSession = new GameSession();
            Assert.IsNotNull(gameSession.CurrentPlayer);
            Assert.AreEqual("Town Square", gameSession.CurrentLocation.Name);
        }
        [TestMethod]
        public void TestPlayerMovesHomeAndIsCopmletelyHealenOnKilled()
        {
            var gameSession = new GameSession();
            gameSession.CurrentPlayer.TakeDamage(999);
            Assert.AreEqual("Home", gameSession.CurrentLocation.Name);
            Assert.AreEqual(gameSession.CurrentPlayer.Level * 10, gameSession.CurrentPlayer.CurrentHitPoints);
        }
    }
}
