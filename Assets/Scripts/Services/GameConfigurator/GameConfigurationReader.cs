using Services.Utils;
using UnityEngine;

namespace Services.GameConfigurator
{
    [CreateAssetMenu(fileName = "LocalGameConfig", menuName = "Loadable/Services/GameConfigurationReader")]
    public class GameConfigurationReader : LoadableComponent, IGameConfigurator
    {
        public GameConfiguration GameConfiguration => gameConfiguration;

        [SerializeField] private GameConfiguration gameConfiguration;

        public override void Execute()
        {
            Debug.Log("[GameConfigurationReader] Iniciamos inicializacion");
        }
    }
}