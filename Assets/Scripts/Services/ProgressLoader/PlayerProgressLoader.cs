using UnityEngine;

namespace Services.ProgressLoader
{
    [CreateAssetMenu(fileName ="PlayerProgressLoader", menuName = "Loadable/PlayerProgressLoader")]
    public class PlayerProgressLoader : LoadableComponent
    {
        public override void Execute()
        {
            Debug.Log("[PlayerProgressLoader] Iniciamos inicializacion");
        }
    }
}