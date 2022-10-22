using Buildings;
using Services.BuildingEarningCalculatorService;
using UnityEngine;

namespace ScriptsToTest
{
    public class BuildingTest : MonoBehaviour
    {
        //generic info del edificio
        //Conjunto de atributos leveables
        [SerializeField] private Entrance entrance;
        private ILeveable _queueEntrance;

        private IBuildingsEarningsCalculatorService _buildingsEarningsCalculatorService;

        private void Start()
        {
            entrance.Init();
            _queueEntrance = entrance.GetQueue(0);
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Upgrade"))
            {
                _queueEntrance.Upgrade();
                var newEarnings = _buildingsEarningsCalculatorService.GetCurrentEarnings(_queueEntrance);
                Debug.Log("Upgrade");
            }

            if (GUILayout.Button("Downgrade"))
            {
                _queueEntrance.Downgrade();
                Debug.Log("Downgrade");
            }

            if (GUILayout.Button("Get Level"))
                Debug.Log(_queueEntrance.Level);
        }
    }
}