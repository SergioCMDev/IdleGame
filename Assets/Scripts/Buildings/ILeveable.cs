namespace Buildings
{
    public interface ILeveable
    {
        public LevelData LevelData { get; }
        public BuildingType BuildingType { get; }
        public int Id  { get; }
        public void OverrideLevel(int newLevel);
        void OverrideMaximumLevel(int newLevel);
        public void Init(int id, int maximumLevel);
        public void Upgrade();
        public void Downgrade();
    }
}