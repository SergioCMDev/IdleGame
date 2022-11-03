using Buildings;

public class Equipment : UpgradableEquipment
{
    private float currentValue;
public void 
    public void Improve(float improveValue)
    {
        
    }

    public override void Initialize(int id, LevelData levelData)
    {
        throw new System.NotImplementedException();
    }

    protected override void ImprovementAfterLevelUp()
    {
        throw new System.NotImplementedException();
    }
}

public enum EquipmentType
{
    Speed, Storage
}