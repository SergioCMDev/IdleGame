using System;
using Persistence.Utils;
using UnityEngine;

namespace Persistence.Strategies
{
    public class SaveToPlayerPrefs : IGameSaver
    {
        public event Action<SaveStatusProcessInfo> OnError;
        public event Action OnSavedSuccessfully;

        public void Save()
        {
            var savegameJSON = JsonUtility.ToJson("data");
            PlayerPrefs.SetString("key", savegameJSON);
            PlayerPrefs.Save();
            OnSavedSuccessfully?.Invoke();
        }

        public void DeleteSaveGame()
        {
            PlayerPrefs.DeleteKey("key");
            PlayerPrefs.Save();
        }

        public void SaveNewGameStatus(bool statusToSave)
        {
            PlayerPrefs.SetInt("HasSavedGame", statusToSave ? 1 : 0);
        }
    }
}