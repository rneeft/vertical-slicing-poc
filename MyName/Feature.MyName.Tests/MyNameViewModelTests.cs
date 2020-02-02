using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Feature.MyName.Tests
{
    [TestClass]
    public class MyNameViewModelTests
    {
        [TestMethod]
        public void OnSubmitTheNameIsMovedIntoTheNameProperty()
        {
            var sut = new MyNameViewModel(null);
            sut.Submit("Mr Test");

            Assert.AreEqual(sut.TheName, "Hello Mr Test!");
        }
    }
}
