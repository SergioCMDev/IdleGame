using System;
using System.Collections.Generic;
using Services.SavegameInteractorService;
using Services.Utils;
using SpaceShips;
using UnityEngine;
using Utils;

namespace Services.ShipThrower
{
    [CreateAssetMenu(fileName = "ShipThrowerService",
        menuName = "Loadable/Services/ShipThrowerService")]
    public class ShipThrowerService : LoadableComponent
    {    
        private SaveGameInteractorService _savegameInteractorService;

        public void SendShipToDirection(ShipModel shipModel, Direction direction, float durationInMinutes)
        {
            shipModel.IsTravelling = true;
            shipModel.Direction = direction;
            shipModel.blockedTime = durationInMinutes;
            shipModel.DateToRelease = DateTime.UtcNow + TimeSpan.FromMinutes(durationInMinutes);
            
            _savegameInteractorService.SavegameFile.ShipModelFlyingStatus = shipModel;
            _savegameInteractorService.SaveGame();
        }

        public List<ShipModel> GetShipsFlying()
        {
            return new List<ShipModel>() { _savegameInteractorService.SavegameFile.ShipModelFlyingStatus };
        }

        public bool HasShipEndedJourney(ShipModel shipModel)
        {
            return shipModel.DateToRelease >= DateTime.UtcNow;
        }
        public override void Execute()
        {
            Debug.Log("[ShipThrowerService] Init");
            _savegameInteractorService = ServiceLocator.Instance.GetService<SaveGameInteractorService>();

        }
    }
}