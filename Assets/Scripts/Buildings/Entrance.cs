using System.Collections.Generic;
using Persistence;
using Services.GameConfigurator;
using Services.SavegameInteractorService;
using UnityEngine;
using Utils;

namespace Buildings
{
    public class Entrance : MonoBehaviour
    {
        private List<QueueEntrance> _queueEntrancesEnabled = new();
        [SerializeField] private QueueEntrance entrancePrefab; //TODO DO PREFAB GETTER
        private SaveGameInteractorService _saveGameInteractorService;
        private GameConfiguration gameConfiguration;

        public void Init()
        {
            gameConfiguration = ServiceLocator.Instance.GetService<IGameConfigurator>().GameConfiguration;
            _saveGameInteractorService = ServiceLocator.Instance.GetService<SaveGameInteractorService>();
        }

        public void CreateQueueEntrances()
        {
            for (int i = 0; i < gameConfiguration.MaximumNumberOfEntrance; i++)
            {
                var queueEntranceInstance = Instantiate(entrancePrefab);
                queueEntranceInstance.name = $"Entrance {i}";
                queueEntranceInstance.Init(i, gameConfiguration.MaximumNumberOfEntrance);
                _queueEntrancesEnabled.Add(queueEntranceInstance);
                _saveGameInteractorService.AddBuilding(queueEntranceInstance);
                queueEntranceInstance.OnObjectUpdated = OnQueueEntranceUpdated;
            }
        }

        private void OnQueueEntranceUpdated(UpgradableObject obj)
        {
            _saveGameInteractorService.UpdateQueueEntranceData(obj);
        }

        public QueueEntrance GetQueue(int id)
        {
            return _queueEntrancesEnabled[id];
        }

        public void LoadQueueEntrances(List<BuildingData> buildingData)
        {
            foreach (var VARIABLE in buildingData)
            {
                var queueEntranceInstance = Instantiate(entrancePrefab);
                queueEntranceInstance.Init(VARIABLE.id, VARIABLE.currentMaximumLevel);

                queueEntranceInstance.OverrideLevel(VARIABLE.currentLevel);
                _queueEntrancesEnabled.Add(queueEntranceInstance);
                queueEntranceInstance.OnObjectUpdated = OnQueueEntranceUpdated;
            }
        }

        public void DeleteQueueEntrances()
        {
            _saveGameInteractorService.GetQueueEntrances().Clear();
            _saveGameInteractorService.SaveGame();
        }
    }
}