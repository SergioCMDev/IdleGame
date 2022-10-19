using UnityEngine;

public interface ICameraMovement
{
    public void DoMovement();
    void Init(Camera camera, SquareSize squareSize, ZoomData zoomData);
}