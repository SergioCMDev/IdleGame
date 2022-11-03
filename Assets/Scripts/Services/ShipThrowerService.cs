public class ShipThrowerService
{
    public void SendShipToDirection(Ship ship, Direction direction)
    {
        ship.IsTravelling = true;
        ship.Direction = direction;
        //
    }
}