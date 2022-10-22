using System.Collections.Generic;
using Services.Utils;
using UnityEngine;

namespace Services.SpritesLoader
{
    [CreateAssetMenu(fileName = "SpritesLoader", menuName = "Loadable/SpritesLoader")]
    public class SpritesLoaderService : LoadableComponent
    {
        public List<Sprite> Sprites;
        public override void Execute()
        {
            Debug.Log("[SpritesLoaderService] Iniciamos inicializacion");
        }
    }
}