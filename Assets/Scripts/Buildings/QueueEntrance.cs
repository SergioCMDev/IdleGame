using UnityEngine;
using Utils;

namespace Buildings
{
    public class QueueEntrance : ILeveable
    {
        public int Level { private set; get; }
        public BuildingType BuildingType { get; private set; }
        private int _id;
        private int _maximumLevel;

        public QueueEntrance()
        {
            BuildingType = BuildingType.QueueEntrance;
        }
        public void OverrideLevel(int newLevel)
        {
            Level = newLevel;
            Level = Utilities.CheckValidationLevel(Level, _maximumLevel);
        }

        public void Init(int id, int maximumLevel)
        {
            Level = 1;
            _id = id;
            _maximumLevel = maximumLevel;
        }

        public void Upgrade()
        {
            Level++;
            Debug.Log($"Upgraded {this}");
        }

        public void Downgrade()
        {
            Level--;
            Level = Utilities.CheckValidationLevel(Level, _maximumLevel);
            Debug.Log($"Downgraded {this} {_id}");
        }
    }
}