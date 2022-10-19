namespace Camera
{
    public interface ICameraMovement
    {
        public void DoMovement();
        void Init(UnityEngine.Camera camera, SquareSize squareSize, ZoomData zoomData);
    }
}