using System.Collections.Generic;
using System.Linq;
using Buildings;
using Persistence;
using Persistence.Strategies;
using Services.Utils;
using UnityEngine;

namespace Services.SavegameInteractorService
{
    [CreateAssetMenu(fileName = "SaveGameInteractorService", menuName = "Loadable/Services/SaveGameInteractorService")]
    public class SaveGameInteractorService : LoadableComponent
    {
        private IGameLoader _gameLoader;
        private IGameSaver _gameSaver;
        private Savegame _saveFile;

        
        public Savegame SavegameFile
        {
            get => _saveFile;
            set => _saveFile = value;
        }

        public override void Execute()
        {
            _gameLoader = new LoadFromPlayerPrefs();
            _gameSaver = new SaveToPlayerPrefs();
        }

        public void SaveGame()
        {
            _gameSaver.Save();
        }

        public void LoadGame()
        {
            _gameLoader.LoadGame();
            _gameLoader.OnSaveFileIsFilled += UpdateSaveFile;
        }

        private void UpdateSaveFile(Savegame obj)
        {
            _saveFile = obj;
        }

        public void AddQueueEntrance(BuildingData buildingData)
        {
            _saveFile.queueEntranceData.Add(buildingData);
            SaveGame();
        }

        public List<BuildingData> GetQueueEntrances()
        {
            return _saveFile.queueEntranceData;
        }
        
        public void UpdateQueueEntranceData(UpgradableObject obj)
        {
            var selectedQueueEntrance = SavegameFile.queueEntranceData.Single(x => x.id == obj.Id);
            SavegameFile.queueEntranceData.Remove(selectedQueueEntrance);
            selectedQueueEntrance.currentLevel = obj.LevelData.Level;
            selectedQueueEntrance.currentMaximumLevel = obj.LevelData.MaximumLevel;
            SavegameFile.queueEntranceData.Add(selectedQueueEntrance);
        }
        
        public void AddBuilding(UpgradableObject upgradableObject)
        {
            var buildingData = new BuildingData
            {
                currentLevel = upgradableObject.LevelData.Level,
                currentMaximumLevel = upgradableObject.LevelData.MaximumLevel,
                id =  upgradableObject.Id
            };
        
            switch (upgradableObject.BuildingType)
            {
                case BuildingType.QueueEntrance:
                    AddQueueEntrance(buildingData);
                    break;
                default:
                    break;
            }
        }
    }
}