using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Métier;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMaitreHotel()
        {
            Restaurant r = new Restaurant();
            r.GrpClientArrive();
            Assert.AreEqual(r.WaitingLine.Count, 0);
        }

        [TestMethod]
        public void TestChefRangPlacement()
        {
            Restaurant r = new Restaurant();
            r.GrpClientArrive();
            Table Table = null;
            foreach (var carre in r.ListCarres)
            {
                foreach (var rang in carre.Rangs)
                {
                    foreach (var table in rang.tables)
                    {
                        if (!table.IsFree)
                        {
                            Table = table;
                        }
                    }
                }
            }
            Assert.IsNotNull(Table);
        }

        [TestMethod]
        public void TestGiveMenu()
        {
            Restaurant r = new Restaurant();
            r.GrpClientArrive();
            Assert.IsNotNull(r.ListChefsRang[0].ClientWithMenu[0]);
            Assert.AreEqual(true, r.ListChefsRang[0].ClientWithMenu[0].HaveMenu); 
            
        }
    }
}
