using System;
using Persistence.Utils;
using UnityEngine;

namespace Persistence.Strategies
{
    public class LoadFromPlayerPrefs : IGameLoader
    {
        public event Action<Savegame> OnSaveFileIsFilled;
        public event Action<LoadErrorCode> OnError;

        public void LoadGame()
        {
            var dataToFromJson = PlayerPrefs.GetString("Key");

            if (string.IsNullOrEmpty(dataToFromJson))
            {
                OnError?.Invoke(LoadErrorCode.EmptyFile);
                return;
            }

            var savegame = JsonUtility.FromJson<Savegame>(dataToFromJson);
            OnSaveFileIsFilled?.Invoke(savegame);
        }
    }
}