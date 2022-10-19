using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

namespace Camera
{
    public class CameraMovementAndroid : ICameraMovement
    {
        private Vector3 initialPosition;
        private Vector2 endedPosition;
        private Vector2 currentPosition;
        private Vector3 initialTouchPosition;
        private UnityEngine.Camera _camera;
        private SquareSize _squareSize;
        private float _offsetZoom;
        private float _minSize;
        private float _maxSize;

        public void Init(UnityEngine.Camera camera, SquareSize squareSize, ZoomData zoomData)
        {
            _camera = camera;
            _squareSize = squareSize;
            _offsetZoom = zoomData.offsetZoom;
            _minSize = zoomData.minSize;
            _maxSize = zoomData.maxSize;
        }

        public void DoMovement()
        {
            if (EventSystem.current.IsPointerOverGameObject() || Input.touchCount < 1)
            {
                return;
            }

            var touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    initialTouchPosition = touch.position;
                    initialPosition = _camera.ScreenToWorldPoint(initialTouchPosition);
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Stationary:
                case TouchPhase.Moved:
                {
                    var offset = initialPosition - _camera.ScreenToWorldPoint(Input.mousePosition);
                    _camera.transform.position += offset;
                    break;
                }
            }

            _camera.transform.position = Utilities.ClampCamera(_camera, _camera.transform.position, _squareSize);
        }
    }
}