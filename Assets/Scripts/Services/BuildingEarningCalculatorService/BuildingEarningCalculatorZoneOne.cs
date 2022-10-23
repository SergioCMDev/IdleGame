using Buildings;
using Services.Utils;
using UnityEngine;

namespace Services.BuildingEarningCalculatorService
{
    [CreateAssetMenu(fileName = "BuildingEarningCalculatorZoneOne",
        menuName = "Loadable/Services/BuildingEarningCalculatorZoneOne")]
    public class BuildingEarningCalculatorZoneOne : LoadableComponent, IProfitCalculatorService
    {
        public float GetCurrentEarningsForSecond(IProfitable queueEntrance)
        {
            return queueEntrance.GetBenefitForSecond();
        }
        public float GetCurrentEarningsForMinute(IProfitable queueEntrance)
        {
            return queueEntrance.GetBenefitForMinute();
        }

        public override void Execute()
        {
            Debug.Log("[BuildingEarningCalculatorZoneOne] Init");

        }
    }
}