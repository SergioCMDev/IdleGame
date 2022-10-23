using System;
using UnityEngine;

namespace Buildings
{
    public abstract class UpgradableObject : MonoBehaviour, ILeveable
    {
        public LevelData LevelData => _levelData;
        public Action<UpgradableObject> OnObjectUpdated;
        public BuildingType BuildingType { get; internal set; }
        public int Id => objectId;
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
            OnObjectUpdated?.Invoke(this);
            Debug.Log($"Upgraded {this.gameObject.name}");
        }

        protected abstract void  IncrementEarningAfterLevelUp();

        public void Downgrade()
        {
            _levelData.Downgrade();
            Debug.Log($"Downgraded {this} {objectId}");
        }
    }
}