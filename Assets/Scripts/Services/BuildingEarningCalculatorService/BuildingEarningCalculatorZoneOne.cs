using Buildings;
using Services.SavegameInteractorService;
using Services.Utils;
using UnityEngine;
using Utils;

namespace Services.BuildingEarningCalculatorService
{
    [CreateAssetMenu(fileName = "BuildingEarningCalculatorZoneOne",
        menuName = "Loadable/Services/BuildingEarningCalculatorZoneOne")]
    public class BuildingEarningCalculatorZoneOne : LoadableComponent, IProfitCalculatorService
    {
        private SaveGameBuildingInteractorService _saveGameBuildingInteractorService;

        public float GetCurrentEarningsForSecond(IProfitable queueEntrance)
        {
            return queueEntrance.GetBenefitForSecond();
        }
        public float GetCurrentEarningsForMinute(IProfitable queueEntrance)
        {
            return queueEntrance.GetBenefitForMinute();
        }

        public float GetCurrentEarningsForSecondAllBuildings()
        {
            var quantity = 0.0f;
            foreach (var building in  _saveGameBuildingInteractorService.GetQueueEntrances())
            {
                ProfitModel queueEntrance = new ProfitModel(building.currentLevel, 1 ,new LevelData(building.currentMaximumLevel));
                quantity += queueEntrance.GetBenefitForSecond();
            }
           
            return quantity;
        }
        
        public float GetCurrentEarningsForMinuteAllBuildings()
        {
            return GetCurrentEarningsForSecondAllBuildings() * 60;
        }
        
        public override void Execute()
        {
            Debug.Log("[BuildingEarningCalculatorZoneOne] Init");
            _saveGameBuildingInteractorService = ServiceLocator.Instance.GetService<SaveGameBuildingInteractorService>();

        }
    }
}