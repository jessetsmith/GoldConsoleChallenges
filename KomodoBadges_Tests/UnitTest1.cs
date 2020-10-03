using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoBadges_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateBadge()
        {
            List<string> doors = new List<string>
            {
                "A1",
                "A2",
                "A3"
            };

            KomodoBadges_Repository.Badges newBadge = new KomodoBadges_Repository.Badges(123, doors, "Jesse Smith");

            KomodoBadges_Repository.BadgesRepository _badgeRepo = new KomodoBadges_Repository.BadgesRepository();

            _badgeRepo.AddBadges(newBadge.BadgeID, newBadge);
        }

        [TestMethod]
        public void TestGetBadges()
        {
            List<string> doors = new List<string>
            {
                "A1",
                "A2",
                "A3"
            };

            KomodoBadges_Repository.Badges newBadge = new KomodoBadges_Repository.Badges(123, doors, "Jesse Smith");

            KomodoBadges_Repository.BadgesRepository _badgeRepo = new KomodoBadges_Repository.BadgesRepository();

            _badgeRepo.GetBadges();
        }

        [TestMethod]
        public void TestUpdateBadges()
        {
            List<string> doors = new List<string>
            {
                "A1",
                "A2",
                "A3"
            };

            List<string> newDoors = new List<string>
            {
                "A1",
                "A2",
                "A3",
                "A4"
            };

            KomodoBadges_Repository.Badges originalBadge = new KomodoBadges_Repository.Badges(123, doors, "Jesse Smith");


            KomodoBadges_Repository.Badges newBadge = new KomodoBadges_Repository.Badges(123, newDoors, "Jesse T. Smith");

            originalBadge = newBadge;

            KomodoBadges_Repository.BadgesRepository _badgeRepo = new KomodoBadges_Repository.BadgesRepository();

            _badgeRepo.UpdateBadges(originalBadge.BadgeID, originalBadge);
        }

        [TestMethod]
        public void TestRemoveDoorsFromBadge()
        {
            List<string> doors = new List<string>
            {
                "A1",
                "A2",
                "A3"
            };

            KomodoBadges_Repository.Badges newBadge = new KomodoBadges_Repository.Badges(123, doors, "Jesse Smith");

            KomodoBadges_Repository.BadgesRepository _badgeRepo = new KomodoBadges_Repository.BadgesRepository();

            _badgeRepo.RemoveDoorsFromBadge(newBadge.BadgeID, "A1");
        }

        [TestMethod]
        public void TestRemoveBadge()
        {
            List<string> doors = new List<string>
            {
                "A1",
                "A2",
                "A3"
            };

            KomodoBadges_Repository.Badges newBadge = new KomodoBadges_Repository.Badges(123, doors, "Jesse Smith");

            KomodoBadges_Repository.BadgesRepository _badgeRepo = new KomodoBadges_Repository.BadgesRepository();

            _badgeRepo.RemoveBadge(newBadge.BadgeID);
        }
    }
}
