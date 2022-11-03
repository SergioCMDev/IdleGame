using Services.SavegameInteractorService;
using Services.Utils;
using UnityEngine;
using Utils;

namespace Services.ProgressLoader
{
    [CreateAssetMenu(fileName ="PlayerProgressLoader", menuName = "Loadable/PlayerProgressLoader")]
    public class PlayerProgressLoader : LoadableComponent
    {
        private SaveGameBuildingInteractorService _savegameBuildingInteractorService;

        public override void Execute()
        {
            Debug.Log("[PlayerProgressLoader] Iniciamos inicializacion");
            _savegameBuildingInteractorService = ServiceLocator.Instance.GetService<SaveGameBuildingInteractorService>();

        }
    }
}