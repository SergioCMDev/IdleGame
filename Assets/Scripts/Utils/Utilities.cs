using Camera;
using UnityEngine;

namespace Utils
{
    public static class Utilities
    {
        public static Vector3 ClampCamera(UnityEngine.Camera camera, Vector3 targetPosition, SquareSize squareSize)
        {
            float camHeight = camera.orthographicSize;
            float camWidth = camera.orthographicSize * camera.aspect;

            float minX = -squareSize.SizeX / 2 + camHeight;
            float maxX = squareSize.SizeX / 2 - camHeight;

            float minY = -squareSize.SizeY / 2 + camWidth;
            float maxY = squareSize.SizeY / 2 - camWidth;

            float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
            float newY = Mathf.Clamp(targetPosition.y, minY, maxY);
            return new Vector3(newX, newY, targetPosition.z);
        }
        
    }
}