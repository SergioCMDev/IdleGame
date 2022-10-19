using System;
using UnityEngine;

namespace Camera
{
    [Serializable]
    public struct SquareSize
    {
        public int SizeX, SizeY;
    }

    [Serializable]
    public struct ZoomData
    {
        public int offsetZoom, minSize, maxSize;
        public bool zoomEnabled;
        
    }

    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera camera;
        [SerializeField] private ZoomData zoomData;
        [SerializeField] private SquareSize squareSize;
        private Vector3 _initialPosition;
        private Vector2 _endedPosition;
        private Vector2 _currentPosition;
        private Vector3 _initialMousePosition;
        private ICameraMovement _cameraMovement;
    

        private void Awake()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
        Debug.Log("CAMERA ANDROID");
            _cameraMovement = new CameraMovementAndroid();
#elif UNITY_EDITOR
            Debug.Log("CAMERA PC");
            _cameraMovement = new CameraMovementPC();
#endif
            _cameraMovement.Init(camera, squareSize, zoomData);
        }

        void Update()
        {
            _cameraMovement.DoMovement();
        }
     
        private void OnDrawGizmos()
        {
            var middlePointRight = Vector3.zero + Vector3.right * squareSize.SizeX / 2;
            var middlePointLeft = Vector3.zero - Vector3.right * squareSize.SizeX / 2;
            var middlePointUp = Vector3.zero + Vector3.up * squareSize.SizeY / 2;
            var middlePointDown = Vector3.zero - Vector3.up * squareSize.SizeY / 2;

            var rightUpSquarePoint = middlePointRight + Vector3.up * squareSize.SizeY / 2;
            var leftUpSquarePoint = middlePointLeft + Vector3.up * squareSize.SizeY / 2;

            var rightDownSquarePoint = middlePointRight - Vector3.up * squareSize.SizeY / 2;
            var leftDownSquarePoint = middlePointLeft - Vector3.up * squareSize.SizeY / 2;

            // Debug.DrawLine(Vector3.zero, middlePointRight, Color.green);
            // Debug.DrawLine(Vector3.zero, middlePointLeft, Color.green);
            // Debug.DrawLine(Vector3.zero, middlePointUp, Color.green);
            // Debug.DrawLine(Vector3.zero, middlePointDown, Color.green);

            Debug.DrawLine(middlePointRight, rightUpSquarePoint, Color.green);
            Debug.DrawLine(middlePointLeft, leftUpSquarePoint, Color.green);
            Debug.DrawLine(middlePointRight, rightDownSquarePoint, Color.green);
            Debug.DrawLine(middlePointLeft, leftDownSquarePoint, Color.green);

            Debug.DrawLine(rightUpSquarePoint, middlePointUp, Color.green);
            Debug.DrawLine(leftUpSquarePoint, middlePointUp, Color.green);
            Debug.DrawLine(rightDownSquarePoint, middlePointDown, Color.green);
            Debug.DrawLine(leftDownSquarePoint, middlePointDown, Color.green);
        }
    }
}