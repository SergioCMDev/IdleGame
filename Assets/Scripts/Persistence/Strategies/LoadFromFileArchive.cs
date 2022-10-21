using System;
using System.IO;
using Persistence.Utils;
using UnityEngine;

namespace Persistence.Strategies
{
    public class LoadFromFileArchive : IGameLoader
    {
        public event Action<Savegame> OnSaveFileIsFilled;
        public event Action<LoadErrorCode> OnError;

        public void LoadGame()
        {
            if (!File.Exists("Path"))
            {
                Debug.Log("File no Exists");
                OnError?.Invoke(LoadErrorCode.FileNotFound);
                return;
            }
        
            var fileContent = File.ReadAllText("Path");
            if (string.IsNullOrEmpty(fileContent))
            {
                Debug.Log("File IsNullOrEmpty");

                OnError?.Invoke(LoadErrorCode.EmptyFile);
                return;
            }


            var savegame = JsonUtility.FromJson<Savegame>(fileContent);
            OnSaveFileIsFilled?.Invoke(savegame);
        }
    }
}