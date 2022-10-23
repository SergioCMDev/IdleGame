using System;
using UnityEngine;

namespace Buildings
{
    public abstract class UpgradableObject :  ILeveable
    {
        public LevelData LevelData => levelData;
        public Action<UpgradableObject> OnObjectUpdated;
        public BuildingType BuildingType { get; internal set; }
        public int Id => objectId;
        protected int objectId;
        protected LevelData levelData;

        public abstract void Initialize(int id, LevelData levelData);
        protected abstract void  IncrementEarningAfterLevelUp();

        public void OverrideLevel(int newLevel)
        {
            levelData.OverrideLevel(newLevel);
        }
        
        public void OverrideMaximumLevel(int newLevel)
        {
            levelData.OverrideMaximumLevel(newLevel);
        }

        public void Upgrade()
        {
            levelData.Upgrade();
            IncrementEarningAfterLevelUp();
            OnObjectUpdated?.Invoke(this);
        }


        public void Downgrade()
        {
            levelData.Downgrade();
            Debug.Log($"Downgraded {this} {objectId}");
        }
    }
}