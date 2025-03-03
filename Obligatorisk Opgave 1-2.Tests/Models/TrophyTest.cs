using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorisk_Opgave_1_2.Models;

namespace Obligatorisk_Opgave_1_2.Tests.Models;

[TestClass]
[TestSubject(typeof(Trophy))]
public class TrophyTest
{
    
    [TestMethod]
    public void TrophyCompetitionTest()
    {
        Trophy trophy = new Trophy();
        trophy.Competition = "test";
        Assert.AreEqual("test", trophy.Competition);
        Assert.ThrowsException<ArgumentException>(() => trophy.Competition = "te");
        Assert.ThrowsException<ArgumentException>(() => trophy.Competition = null);
    }
    
    [TestMethod]
    public void TrophyYearTest()
    {
        Trophy trophy = new Trophy();
        trophy.Year = 1975;
        Assert.AreEqual(trophy.Year, 1975);
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Year = 1800);
    }
    
    [TestMethod]
    public void ToStringTest()
    {
        Trophy trophy = new Trophy();
        trophy.Id = 1;
        trophy.Competition = "test";
        trophy.Year = 1975;
        Assert.AreEqual("Trophy: Id 1, Competition test, Year 1975", trophy.ToString());
    }
}