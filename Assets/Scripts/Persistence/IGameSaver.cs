using System;
using Persistence.Utils;

namespace Persistence
{
    public interface IGameSaver
    {
        event Action<SaveStatusProcessInfo> OnError;
        event Action OnSavedSuccessfully;

        void Save();
    }
}