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
        private bool _zoomEnabled;

        public void Init(UnityEngine.Camera camera, SquareSize squareSize, ZoomData zoomData)
        {
            _camera = camera;
            _squareSize = squareSize;
            _offsetZoom = zoomData.offsetZoom;
            _minSize = zoomData.minSize;
            _maxSize = zoomData.maxSize;
            _zoomEnabled = zoomData.zoomEnabled;
        }

        public void DoMovement()
        {
            if (EventSystem.current.IsPointerOverGameObject() || Input.touchCount < 1)
            {
                return;
            }

            if (Input.touchCount == 1)
            {
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
                        var offset = initialPosition - _camera.ScreenToWorldPoint(touch.position);
                        _camera.transform.position += offset;
                        break;
                    }
                }
            }

            if (Input.touchCount == 2 && _zoomEnabled)
            {
                var touch1 = _camera.ScreenToWorldPoint(Input.touches[0].position);
                var touch2 = _camera.ScreenToWorldPoint(Input.touches[1].position);

                var touch1Offset =
                    _camera.ScreenToWorldPoint(Input.touches[0].position - Input.touches[0].deltaPosition);
                var touch2Offset =
                    _camera.ScreenToWorldPoint(Input.touches[1].position - Input.touches[1].deltaPosition);

                var zoom = Vector3.Distance(touch1, touch2) - Vector3.Distance(touch1Offset, touch2Offset);

                if (zoom != 0 && zoom < 10)
                {
                    DoZoom(zoom);
                }
            }

            _camera.transform.position = Utilities.ClampCamera(_camera, _camera.transform.position, _squareSize);
        }

        public void DoZoom(float wheelMovement)
        {
            var newSize = _camera.orthographicSize + wheelMovement * _offsetZoom;
            _camera.orthographicSize = Mathf.Clamp(newSize, _minSize, _maxSize);
        }
    }
}