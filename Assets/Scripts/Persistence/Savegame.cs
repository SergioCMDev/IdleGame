using System;

namespace Persistence
{
    [Serializable]
    public class Savegame
    {
        public DateTime LastTimeOpened
        {
            get => new (lastTimeOpenedLong);
            set => lastTimeOpenedLong = value.Ticks;
        }

        public long lastTimeOpenedLong;

        public Savegame()
        {
            LastTimeOpened = DateTime.MinValue;
        }
    }
}