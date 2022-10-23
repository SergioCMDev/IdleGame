using UnityEngine;
using Utils;

namespace Buildings
{
    public class LevelData
    {
        private int _maximumLevel;

        public int Level => _currentLevel;
        public int MaximumLevel => _maximumLevel;

        private int _currentLevel;

        public LevelData(int maximumLevel)
        {
            _currentLevel = 1;
            _maximumLevel = maximumLevel;
        }

        public void Upgrade()
        {
            _currentLevel++;
            _currentLevel = Utilities.CheckValidationLevel(_currentLevel, _maximumLevel);
            Debug.Log($"Upgraded {this}");
        }

        public void Downgrade()
        {
            _currentLevel--;
            _currentLevel = Utilities.CheckValidationLevel(_currentLevel, _maximumLevel);
        }

        public void OverrideLevel(int newLevel)
        {
            _currentLevel = newLevel;
            _currentLevel = Utilities.CheckValidationLevel(Level, _maximumLevel);
        }

        public void OverrideMaximumLevel(int newLevel)
        {
            _maximumLevel = newLevel;
        }
    }
}