namespace Buildings
{
    public interface ILeveable
    {
        public LevelData LevelData { get; }
        public int Id  { get; }
        public void OverrideLevel(int newLevel);
        void OverrideMaximumLevel(int newLevel);
        public void Upgrade();
        public void Downgrade();
    }
}