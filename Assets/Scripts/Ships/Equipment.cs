﻿using Buildings;

namespace Ships
{
    public class Equipment : UpgradableEquipment
    {
        public override void Initialize(int id, LevelData levelData)
        {
        }

        protected override void ImprovementAfterLevelUp()
        {
        }
    }

    public enum EquipmentType
    {
        Speed, Storage
    }
}