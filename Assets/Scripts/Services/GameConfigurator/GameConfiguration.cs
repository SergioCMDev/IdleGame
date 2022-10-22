using UnityEngine;

namespace Services.GameConfigurator
{
    [CreateAssetMenu(fileName = "LocalGameConfig", menuName = "Configuration/GameConfig")]
    public class GameConfiguration : ScriptableObject
    {
        [SerializeField] private int maximumNumberOfEntrance;
        public int MaximumNumberOfEntrance => maximumNumberOfEntrance;
    }
}