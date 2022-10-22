using System;
using Buildings;

namespace Services.BuildingEarningCalculatorService
{
    public class BuildingEarningCalculatorZoneOne : IBuildingsEarningsCalculatorService
    {
        public int GetCurrentEarnings(ILeveable queueEntrance)
        {
            switch (queueEntrance.BuildingType)
            {
                case BuildingType.QueueEntrance:
                    //
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        
            throw new System.NotImplementedException();
        }
    }
}