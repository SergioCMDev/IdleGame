using System;
using Buildings;
using Services.BuildingEarningCalculatorService;
using Services.SavegameInteractorService;
using UnityEngine;
using Utils;

namespace ScriptsToTest
{
    public class BuildingTest : MonoBehaviour
    {
        //generic info del edificio
        //Conjunto de atributos leveables
        [SerializeField] private Entrance entrance;
        private ILeveable _queueEntrance;
        private IProfitable _queueEntranceProfitable;

        private IProfitCalculatorService _profitCalculatorService;
        private SaveGameInteractorService _saveGameInteractorService;

        private void Start()
        {
            _profitCalculatorService = ServiceLocator.Instance.GetService<IProfitCalculatorService>();
            _saveGameInteractorService = ServiceLocator.Instance.GetService<SaveGameInteractorService>();
            entrance.Init();
            // entrance.DeleteQueueEntrances();
            var buildingData = _saveGameInteractorService.GetQueueEntrances();
            if (buildingData.Count > 0)
            {
                entrance.LoadQueueEntrances(buildingData);
            }
            else
            {
                entrance.CreateQueueEntrances(5);
            }

            _queueEntrance = entrance.GetQueue(0);
            _queueEntranceProfitable = entrance.GetQueue(0).ProfitModel;
        }

        private void Update()
        {
           var profits =_profitCalculatorService.GetCurrentEarningsForSecond(_queueEntranceProfitable);
           var profitsForAll =_profitCalculatorService.GetCurrentEarningsForSecondAllBuildings();
           // Debug.Log($"profits {_queueEntranceProfitable} -> {profits}");
           Debug.Log($"profits For All{profitsForAll}");
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Upgrade"))
            {
                _queueEntrance.Upgrade();
                var newEarnings = _profitCalculatorService.GetCurrentEarningsForSecond(_queueEntranceProfitable);
                Debug.Log($"Upgrade {newEarnings}");
            }

            if (GUILayout.Button("Downgrade"))
            {
                _queueEntrance.Downgrade();
                Debug.Log("Downgrade");
            }

            if (GUILayout.Button("Get Level"))
                Debug.Log(_queueEntrance.LevelData.Level);

            if (GUILayout.Button("Get Earning"))
                Debug.Log(_queueEntranceProfitable.GetBenefitForMinute());
        }
    }
}