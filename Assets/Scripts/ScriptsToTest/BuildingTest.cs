using Buildings;
using Services.BuildingEarningCalculatorService;
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

        private void Start()
        {
            _profitCalculatorService = ServiceLocator.Instance.GetService<IProfitCalculatorService>();
            entrance.Init();
            _queueEntrance = entrance.GetQueue(0).GetComponent<ILeveable>();
            _queueEntranceProfitable = entrance.GetQueue(0).GetComponent<IProfitable>();
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