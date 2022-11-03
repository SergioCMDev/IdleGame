using System;
using Buildings;
using UnityEngine;

public abstract class UpgradableEquipment :  ILeveable
{
    public LevelData LevelData => levelData;
    public Action<UpgradableEquipment> OnObjectUpdated;
    public EquipmentType EquipmentType { get; internal set; }
    public int Id => objectId;
    protected int objectId;
    protected LevelData levelData;

    public abstract void Initialize(int id, LevelData levelData);
    protected abstract void  ImprovementAfterLevelUp();

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
        ImprovementAfterLevelUp();
        OnObjectUpdated?.Invoke(this);
    }

    public void Downgrade()
    {
        levelData.Downgrade();
        Debug.Log($"Downgraded {this} {objectId}");
    }
}