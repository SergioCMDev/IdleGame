namespace Buildings
{
    public class QueueEntrance : UpgradableObject, IProfitable
    {
        //Add something to read initial value and increment
        private int _initialValue;
        private float _increment = 0;

        public QueueEntrance()
        {
            BuildingType = BuildingType.QueueEntrance;
        }

        public float GetBenefitForMinute()
        {
            return _initialValue * LevelData.Level + _increment; //TODO Get value
        }

        public float GetBenefitForSecond()
        {
            return GetBenefitForMinute() / 60;
        }

        public float GetBenefitForMinuteAtNextLevel()
        {
            return (GetBenefitForMinute() + GetBenefitForMinute() * _increment);
        }

        protected override void IncrementEarningAfterLevelUp()
        {
            _increment += 0.1f;
        }
    }
}