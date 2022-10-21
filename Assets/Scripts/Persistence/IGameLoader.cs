using System;
using Persistence.Utils;

namespace Persistence
{
    public interface IGameLoader
    {
        event Action<Savegame> OnSaveFileIsFilled;
        event Action<LoadErrorCode> OnError;
        void LoadGame();
    }
}