using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Métier;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class TestMaitreHotel 
    {
        [TestMethod]
        public void TestMethod1()
        {
            Restaurant r = new Restaurant();

            GroupeClient gc = new GroupeClient();
            r.GrpClientArrive(gc);
            

        }
    }
}
