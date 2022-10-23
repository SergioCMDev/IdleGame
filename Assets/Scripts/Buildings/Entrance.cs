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
        [SerializeField] private QueueEntranceInteractable entrancePrefab; //TODO DO PREFAB GETTER
        private SaveGameInteractorService _saveGameInteractorService;
        private GameConfiguration gameConfiguration;

        public void Init()
        {
            gameConfiguration = ServiceLocator.Instance.GetService<IGameConfigurator>().GameConfiguration;
            _saveGameInteractorService = ServiceLocator.Instance.GetService<SaveGameInteractorService>();
        }

        public void CreateQueueEntrances(int numberOfEntrances)
        {
            for (int i = 0; i < numberOfEntrances; i++)
            {
                var queueEntranceInstance = Instantiate(entrancePrefab);
                var queueEntrance = new QueueEntrance();
                queueEntranceInstance.Init(queueEntrance);

                queueEntranceInstance.name = $"Entrance {i}";
                queueEntrance.Initialize(i, new LevelData());
                _queueEntrancesEnabled.Add(queueEntrance);
                _saveGameInteractorService.AddBuilding(queueEntrance);
                queueEntrance.OnObjectUpdated = OnQueueEntranceUpdated;
            }
        }
        
        public void LoadQueueEntrances(List<BuildingData> buildingData)
        {
            foreach (var loadedEntrance in buildingData)
            {
                var queueEntrance = new QueueEntrance();
                var queueEntranceInstance = Instantiate(entrancePrefab);
                queueEntranceInstance.name = $"Entrance {loadedEntrance.id}";

                queueEntranceInstance.Init(queueEntrance);
                queueEntrance.Initialize(loadedEntrance.id, new LevelData(loadedEntrance.currentLevel, loadedEntrance.currentMaximumLevel));
                _queueEntrancesEnabled.Add(queueEntrance);
                queueEntrance.OnObjectUpdated = OnQueueEntranceUpdated;
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

        public void DeleteQueueEntrances()
        {
            _saveGameInteractorService.GetQueueEntrances().Clear();
            _saveGameInteractorService.SaveGame();
        }
    }
}