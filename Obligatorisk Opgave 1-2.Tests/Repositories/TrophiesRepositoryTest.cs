using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorisk_Opgave_1_2.Repositories;

namespace Obligatorisk_Opgave_1_2.Tests.Repositories;

[TestClass]
[TestSubject(typeof(TrophiesRepository))]
public class TrophiesRepositoryTest
{
    [TestMethod]
    public void TrophiesRepositoryGetTest()
    {
        TrophiesRepository trophiesRepository = new TrophiesRepository();
        var trophies = trophiesRepository.Get();
        Assert.AreEqual(5, trophies.Count);
    }
    
    [TestMethod]
    public void TrophiesRepositoryGetSortByTest()
    {
        TrophiesRepository trophiesRepository = new TrophiesRepository();
        var trophies = trophiesRepository.Get(sortBy: "year");
        Assert.AreEqual(5, trophies.Count);
        Assert.AreEqual(2000, trophies[0].Year);
    }
    
    [TestMethod]
    public void TrophiesRepositoryUpdateTest()
    {
        TrophiesRepository trophiesRepository = new TrophiesRepository();
        var trophies = trophiesRepository.Get();
        var trophy = trophies[0];
        trophy.Competition = "NewCompetition";
        trophy.Year = 2021;
        trophiesRepository.Update(0, trophy);
        var updatedTrophy = trophiesRepository.GetById(trophy.Id);
        Assert.AreEqual("NewCompetition", updatedTrophy.Competition);
    }
}