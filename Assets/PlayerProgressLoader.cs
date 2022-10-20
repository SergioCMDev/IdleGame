using UnityEngine;

[CreateAssetMenu(fileName ="PlayerProgressLoader", menuName = "Loadable/PlayerProgressLoader")]
public class PlayerProgressLoader : LoadableComponent
{
    public override void Execute()
    {
        Debug.Log("F11");
        // Initialized = true;
    }
}