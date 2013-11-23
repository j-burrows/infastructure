using System;
using InfastructureLib.Business;
using InfastructureLib.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfastructureLibTests.Data.Entities{
    [TestClass]
    public class tDPage{
        [TestMethod]
        public void DPage_IsEquivilantToItself(){
            DPage page = new DPage { key = -1};
            bool equivilant = page.Equivilant(page);
            Assert.IsTrue(equivilant);
        }

        [TestMethod]
        public void TwoDPagesWithMatchingKeys_AreEquivilant(){
            int key = -1;
            DPage first = new DPage { key = key };
            DPage second = new DPage { key = key };
            bool equivilant = first.Equivilant(second);
            Assert.IsTrue(equivilant);
        }

        [TestMethod]
        public void TwoDPagesWithUnmatchedKeys_ArentEquivilant(){
            DPage first = new DPage { key = 1 };
            DPage second = new DPage { key = 2 };
            bool equivilant = first.Equivilant(second);
            Assert.IsFalse(equivilant);
        }

        [TestMethod]
        public void DPageAndBPageWithMatchingKeys_AreNotEquivilant(){
            DPage first = new DPage { key = 1 };
            BPage second = new BPage { Page_ID = 2 };
            bool equivilant = first.Equivilant(second);
            Assert.IsFalse(equivilant);
        }
    }
}
