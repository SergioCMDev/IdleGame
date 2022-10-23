namespace Buildings
{
    public class ProfitModel : IProfitable
    {
        private float _initialValue;
        private float _increment;
        private LevelData _levelData;

        public ProfitModel(float initialValue, float increment, LevelData levelData)
        {
            _initialValue = initialValue;
            _increment = increment;
            _levelData = levelData;
        }
        public float GetBenefitForMinute()
        {
            return _initialValue * _levelData.Level + _increment; //TODO Get value
        }

        public float GetBenefitForSecond()
        {
            return GetBenefitForMinute() / 60;
        }

        public float GetBenefitForMinuteAtNextLevel()
        {
            return (GetBenefitForMinute() + GetBenefitForMinute() * _increment);
        }
        public void IncrementEarningAfterLevelUp()
        {
            _increment += 0.1f;
        }

    }
}