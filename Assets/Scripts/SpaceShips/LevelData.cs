using UnityEngine;
using Utils;

namespace Buildings
{
    public class LevelData
    {
        private int _maximumLevel;
        private int _currentLevel;

        public int Level => _currentLevel;
        public int MaximumLevel => _maximumLevel;

        public LevelData(int currentLevel = 1, int maximumLevel = 10)
        {
            _currentLevel = currentLevel;
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