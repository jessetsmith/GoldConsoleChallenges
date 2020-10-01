using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Repository
{
    public class Badges
    {
        public List<string> _doorNames = new List<string>();

        public int BadgeID { get; set; }
        public List<string> DoorNames 
        {
            get
            { return _doorNames; }
            set { }
        }

        public void AddDoorNames(string doors)
        {
            _doorNames.Add(doors);
            List<string> addDoors = _doorNames;
            DoorNames = addDoors;
        }

        public string NameOnBadge { get; set; }

        public Badges()
        {

        }

        public Badges(int badgeID, List<string> doorNames, string nameOnBadge)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
            NameOnBadge = nameOnBadge;
        }
    }
}
