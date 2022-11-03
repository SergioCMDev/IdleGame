// using System.Collections.Generic;
// using Persistence;
// using Services.GameConfigurator;
// using Services.SavegameInteractorService;
// using UnityEngine;
// using Utils;
//
// namespace Buildings
// {
//     public class Entrance : MonoBehaviour
//     {
//         private List<QueueEntrance> _queueEntrancesEnabled = new();
//         [SerializeField] private QueueEntranceInteractable entrancePrefab; //TODO DO PREFAB GETTER
//         private SaveGameBuildingInteractorService _saveGameBuildingInteractorService;
//         private GameConfiguration gameConfiguration;
//
//         public void Init()
//         {
//             gameConfiguration = ServiceLocator.Instance.GetService<IGameConfigurator>().GameConfiguration;
//             _saveGameBuildingInteractorService = ServiceLocator.Instance.GetService<SaveGameBuildingInteractorService>();
//         }
//
//         public void CreateQueueEntrances(int numberOfEntrances)
//         {
//             for (int i = 0; i < numberOfEntrances; i++)
//             {
//                 var queueEntrance = InstantiateQueueEntrance(i);
//
//                 InitializeQueueEntrance(i, queueEntrance, new LevelData());
//                 
//                 _saveGameBuildingInteractorService.AddBuilding(queueEntrance);
//             }
//         }
//
//         public void LoadQueueEntrances(List<BuildingData> buildingData)
//         {
//             foreach (var loadedEntrance in buildingData)
//             {
//                 var queueEntrance = InstantiateQueueEntrance(loadedEntrance.id);
//                 InitializeQueueEntrance(loadedEntrance.id, queueEntrance, new LevelData(loadedEntrance.currentLevel, loadedEntrance.currentMaximumLevel));
//
//                 queueEntrance.OnObjectUpdated = OnQueueEntranceUpdated;
//             }
//         }
//         
//         private void InitializeQueueEntrance(int id, QueueEntrance queueEntrance, LevelData levelData)
//         {
//             queueEntrance.Initialize(id, levelData);
//             _queueEntrancesEnabled.Add(queueEntrance);
//             queueEntrance.OnObjectUpdated = OnQueueEntranceUpdated;
//         }
//         
//         private QueueEntrance InstantiateQueueEntrance (int id)
//         {
//             var queueEntranceInstance = Instantiate(entrancePrefab, transform);
//             var queueEntrance = new QueueEntrance();
//             queueEntranceInstance.name = $"Entrance {id}";
//             queueEntranceInstance.Init(queueEntrance);
//             return queueEntrance;
//         }
//
//         private void OnQueueEntranceUpdated(UpgradableBuildingObject obj)
//         {
//             _saveGameBuildingInteractorService.UpdateQueueEntranceData(obj);
//         }
//
//         public QueueEntrance GetQueue(int id)
//         {
//             return _queueEntrancesEnabled[id];
//         }
//
//         public void DeleteQueueEntrances()
//         {
//             _saveGameBuildingInteractorService.GetQueueEntrances().Clear();
//             _saveGameBuildingInteractorService.SaveGame();
//         }
//     }
// }