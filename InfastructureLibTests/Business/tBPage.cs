using System;
using InfastructureLib.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfastructureLibTests.Business{
    [TestClass]
    public class tBPage{
        [TestMethod]
        public void BPageWithValidMembers_IsCreateValid(){
            BPage valid = new BPage { 
                Name = "Valid",
                Title = "Valid",
                Icon_Url = "Valid",
                Url = "Valid"
            };
            Assert.IsTrue(valid.CreateValid());
        }

        [TestMethod]
        public void BPageWithInvalidName_IsNotCreateValid() { 
            BPage invalid = new BPage { 
                Name = null,
                Title = "Valid",
                Icon_Url = "Valid",
                Url = "Valid"
            };
            Assert.IsFalse(invalid.CreateValid());
        }

        [TestMethod]
        public void BPageWithInvalidTitle_IsNotCreateValid() { 
            BPage invalid = new BPage { 
                Name = "Valid",
                Title = "1234567890123456789012345678901234567890",
                Icon_Url = "Valid",
                Url = "Valid"
            };
            Assert.IsFalse(invalid.CreateValid());
        }
        
        [TestMethod]
        public void BPageWithInvalidIconUrl_IsNotCreateValid() { 
            //Title is made 1100 characters long (over 1024 max).
            BPage invalid = new BPage { 
                Name = "Valid",
                Title = @"1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890",
                Icon_Url = "Valid",
                Url = "Valid"
            };
            Assert.IsFalse(invalid.CreateValid());
        }

        [TestMethod]
        public void BPageWithInvalidUrl_IsNotCreateValid() { 
            BPage invalid = new BPage { 
                Name = "Valid",
                Title = "Valid",
                Icon_Url = "Valid",
                Url = null
            };
            Assert.IsFalse(invalid.CreateValid());
        }

        [TestMethod]
        public void BPageWithNullMembers_IsUpdateValid() {
            BPage valid = new BPage { 
                Name = null,
                Title = null,
                Icon_Url = null,
                Url = null
            };
            Assert.IsTrue(valid.UpdateValid());
        }

        [TestMethod]
        public void BPageWithValidMembers_IsUpdateValid() {
            BPage valid = new BPage { 
                Name = "Valid",
                Title = "Valid",
                Icon_Url = "Valid",
                Url = "Valid"
            };
            Assert.IsTrue(valid.UpdateValid());
        }

        [TestMethod]
        public void BPageWithInvalidName_IsNotUpdateValid() {
            //Name is assigned a string of length 17
            BPage valid = new BPage { 
                Name = "12345678901234567",
                Title = "Valid",
                Icon_Url = "Valid",
                Url = "Valid"
            };
            Assert.IsFalse(valid.UpdateValid());
        }

        [TestMethod]
        public void BPageWithInvalidTitle_IsNotUpdateValid() {
            //Title is assigned a string of length 33
            BPage valid = new BPage { 
                Name = "Valid",
                Title = "123456789012345678901234567890123",
                Icon_Url = "Valid",
                Url = "Valid"
            };
            Assert.IsFalse(valid.UpdateValid());
        }

        [TestMethod]
        public void BPageWithInvalidIconUrl_IsNotUpdateValid() {
            //Icon Url is assigned a string of length 1100
            BPage valid = new BPage { 
                Name = "Valid",
                Title = "Valid",
                Icon_Url = @"1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890",
                Url = "Valid"
            };
            Assert.IsFalse(valid.UpdateValid());
        }

        [TestMethod]
        public void BPageWithInvalidUrl_IsNotUpdateValid() {
            //Icon Url is assigned a string of length 1100
            BPage valid = new BPage { 
                Name = "Valid",
                Title = "Valid",
                Icon_Url = "Valid",
                Url = @"1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
                          1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
            };
            Assert.IsFalse(valid.UpdateValid());
        }

        
    }
}
