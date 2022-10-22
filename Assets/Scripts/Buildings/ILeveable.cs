namespace Buildings
{
    public interface ILeveable
    {
        public int Level { get; }
        BuildingType BuildingType { get; }
        public void OverrideLevel(int newLevel);
        void Init(int id, int maximumLevel);
        void Upgrade();
        void Downgrade();
    }
}