using System;
using System.IO;
using Persistence.Utils;

namespace Persistence.Strategies
{
    public class SaveToFileArchive : IGameSaver
    {
        const string fileName = "ProgressInfo";
    
        // string filePath = Application.persistentDataPath + $"/{fileName}.pso";

        public event Action<SaveStatusProcessInfo> OnError;
        public event Action OnSavedSuccessfully;

        public void Save()
        {
            try
            {
                // var dataToSaveJson = JsonUtility.ToJson(SavegameManager.Instance.Savegame);
                // using (var writer = File.CreateText(filePath))
                // {
                //     writer.Write(dataToSaveJson);
                // }
                OnSavedSuccessfully?.Invoke();
            }
            catch (IOException exception)
            {
                // OnError?.Invoke(new SaveGameProcessInfo()
                // {
                //     Exception = exception,
                //     SaveErrorCode = SaveErrorCode.Exception
                // });
            }
        }

        public void DeleteSaveGame()
        {
        }

        public void SaveNewGameStatus(bool statusToSave)
        {
        }
    }
}