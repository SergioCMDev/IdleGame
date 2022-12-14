using System;
using System.Collections.Generic;
using SpaceShips;

namespace Persistence
{
    [Serializable]
    public class Savegame
    {
        // public List<BuildingData> queueEntranceData;
        
        public DateTime LastTimeOpened
        {
            get => new (lastTimeOpenedLong);
            set => lastTimeOpenedLong = value.Ticks;
        }

        public ShipModel ShipModelFlyingStatus;

        public long lastTimeOpenedLong;

        public Savegame()
        {
            LastTimeOpened = DateTime.MinValue;
        }
    }
    
    [Serializable]
    public struct BuildingData
    {
        public int id;
        public int currentLevel;
        public int currentMaximumLevel;
    }
}