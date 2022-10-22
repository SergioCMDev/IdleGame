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
        private Savegame _savegameFile;

        public Savegame SavegameFile
        {
            get => _savegameFile;
            set => _savegameFile = value;
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
            _gameLoader.OnSaveFileIsFilled += UpdateSavegame;
        }

        private void UpdateSavegame(Savegame obj)
        {
            _savegameFile = obj;
        }
    }
}