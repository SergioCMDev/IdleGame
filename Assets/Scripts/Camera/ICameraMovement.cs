namespace Camera
{
    public interface ICameraMovement
    {
        public void DoMovement();
        public void Init(UnityEngine.Camera camera, SquareSize squareSize, ZoomData zoomData);

        public void DoZoom(float wheelMovement);
    }
}