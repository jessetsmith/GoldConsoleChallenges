using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Repository
{
    public class BadgesRepository
    {   


        public Dictionary<int, Badges> badgeDictionary = new Dictionary<int, Badges>();

        //Create
        public void AddBadges(int badgeID, Badges badges)
        {
            badgeDictionary.Add(badgeID, badges);
        }

        //Read
        public Dictionary<int, Badges> GetBadges()
        {
            return badgeDictionary;
        }

        //Update
        public bool UpdateBadges(int oldBadgeID, Badges newBadge)
        {
            var badges = badgeDictionary;
            Badges oldBadge;
            bool containsKey;

            //Find 
            if (badges.ContainsKey(oldBadgeID))
            {
                containsKey = true;
                badges.TryGetValue(oldBadgeID, out oldBadge);

                //Update
                if (containsKey == true)
                {
                    oldBadge.DoorNames = newBadge.DoorNames;
                    oldBadge.NameOnBadge = newBadge.NameOnBadge;
                    badges[oldBadgeID] = newBadge;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                containsKey = false;
                Console.WriteLine("There was no badge with that ID.");
                return false;
            }

        }


        //Remove doors from badge
        public bool RemoveDoorsFromBadge(int badgeID, string doors)
        {
            var badges = badgeDictionary;
            Badges doorsToRemove;
            bool containsKey;

            //Find 
            if (badges.ContainsKey(badgeID))
            {
                containsKey = true;
                badges.TryGetValue(badgeID, out doorsToRemove);

                //Remove doors from badge
                if (containsKey == true)
                {
                    doorsToRemove.DoorNames.Remove(doors);
                    //badges[badgeID] = doorsToRemove;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                containsKey = false;
                Console.WriteLine("There was no badge with that ID.");
                return false;
            }
        }

        //Remove badge
        public bool RemoveBadge(int badgeID)
        {
            var badges = badgeDictionary;
            Badges badgeToRemove;
            bool containsKey;

            //Find 
            if (badges.ContainsKey(badgeID))
            {
                containsKey = true;
                badges.TryGetValue(badgeID, out badgeToRemove);

                //Remove badge
                if (containsKey == true)
                {
                    badges.Remove(badgeID);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                containsKey = false;
                Console.WriteLine("There was no badge with that ID.");
                return false;
            }
        }


    }
}
