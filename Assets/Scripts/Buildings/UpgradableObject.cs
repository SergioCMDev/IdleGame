using UnityEngine;

namespace Buildings
{
    public abstract class UpgradableObject : MonoBehaviour, ILeveable
    {
        public LevelData LevelData => _levelData;

        public BuildingType BuildingType { get; internal set; }
        protected int objectId;
        private LevelData _levelData;

        public void Init(int id, int maximumLevel)
        {
            objectId = id;
            _levelData = new LevelData(maximumLevel);
        }

        public void OverrideLevel(int newLevel)
        {
            _levelData.OverrideLevel(newLevel);
        }
        
        public void OverrideMaximumLevel(int newLevel)
        {
            _levelData.OverrideMaximumLevel(newLevel);
        }

        public void Upgrade()
        {
            _levelData.Upgrade();
            IncrementEarningAfterLevelUp();
            Debug.Log($"Upgraded {this}");
        }

        protected abstract void  IncrementEarningAfterLevelUp();

        public void Downgrade()
        {
            _levelData.Downgrade();
            Debug.Log($"Downgraded {this} {objectId}");
        }
    }
}