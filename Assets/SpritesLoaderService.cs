using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpritesLoader", menuName = "Loadable/SpritesLoader")]
public class SpritesLoaderService : LoadableComponent
{
    public List<Sprite> Sprites;
    public override void Execute()
    {
        Debug.Log("F");
        // Initialized = true;
    }
}