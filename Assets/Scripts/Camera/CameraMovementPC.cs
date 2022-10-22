using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

namespace Camera
{
    public class CameraMovementPC : ICameraMovement
    {
        private Vector3 _initialPosition;
        private Vector2 _endedPosition;
        private Vector2 _currentPosition;
        private Vector3 _initialMousePosition;
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
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                _initialMousePosition = Input.mousePosition;
                _initialPosition = _camera.ScreenToWorldPoint(_initialMousePosition);

                // Debug.Log($"MOVE {_initialPosition}");
            }

            if (Input.GetMouseButton(0))
            {
                var offset = _initialPosition - _camera.ScreenToWorldPoint(Input.mousePosition);

                _camera.transform.position += offset;
            }

            if (_zoomEnabled)
            {
                var wheelMovement = Input.GetAxis("Mouse ScrollWheel");
                if (wheelMovement is < 0 or > 0)
                {
                    DoZoom(wheelMovement);
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