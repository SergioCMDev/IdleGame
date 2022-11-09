using Services.SavegameInteractorService;
using Services.ShipThrower;
using SpaceShips;
using UnityEngine;
using Utils;

public class ShipThrowerTest : MonoBehaviour
{
    private ShipThrowerService _throwerService;
    // [SerializeField] private ShipModel _shipModelPrefab;
    [SerializeField] private float travelDuration;
    [SerializeField] private bool throwShip;
    private ShipModel _shipModelPrefabInstance;
    private SaveGameInteractorService _savegameInteractorService;

    // Start is called before the first frame update
    void Start()
    {
        _throwerService = ServiceLocator.Instance.GetService<ShipThrowerService>();
        _shipModelPrefabInstance = new ShipModel();
        if (throwShip)
        {
            _throwerService.SendShipToDirection(_shipModelPrefabInstance, Direction.East, travelDuration);
            return;
        }

        var ships = _throwerService.GetShipsFlying();
        foreach (var ship in ships)
        {
            if (_throwerService.HasShipEndedJourney(ship))
            {
                Debug.Log($"Ship {ship} has ended");
            }
        }
    }
}