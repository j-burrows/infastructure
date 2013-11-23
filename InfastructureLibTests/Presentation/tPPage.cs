using System;
using InfastructureLib.Presentation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfastructureLibTests.Presentation{
    [TestClass]
    public class tPPage{
        [TestMethod]
        public void PPageWithNullName_WhenFormatted_BecomesEmpty(){
            PPage formatting = new PPage { 
                Name = null
            };
            formatting.Format();
            Assert.AreEqual(formatting.Name, string.Empty);
        }
        
        [TestMethod]
        public void PPageWithNullTitle_WhenFormatted_BecomesEmpty(){
            PPage formatting = new PPage { 
                Title = null
            };
            formatting.Format();
            Assert.AreEqual(formatting.Title, string.Empty);
        }
        
        [TestMethod]
        public void PPageWithNullUrl_WhenFormatted_BecomesEmpty(){
            PPage formatting = new PPage { 
                Url = null
            };
            formatting.Format();
            Assert.AreEqual(formatting.Url, string.Empty);
        }
        
        [TestMethod]
        public void PPageWithNullIconUrl_WhenFormatted_BecomesEmpty(){
            PPage formatting = new PPage { 
                Icon_Url = null
            };
            formatting.Format();
            Assert.AreEqual(formatting.Icon_Url, string.Empty);
        }
    }
}
