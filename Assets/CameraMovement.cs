using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector2 endedPosition;
    private Vector2 currentPosition;
    private Vector3 endedMousePosition;
    private Vector3 initialMousePosition;
    [SerializeField] private Camera camera;
    [SerializeField] private float offsetZoom;
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;
    [SerializeField] private SquareSize squareSize;
    
    [Serializable]
    public struct SquareSize
    {
        public int SizeX, SizeY;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("F");
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidMovement();
        camera.transform.position = ClampCamera(camera.transform.position);

        return;
#endif

        if (Input.GetMouseButtonDown(0))
        {
            initialMousePosition = Input.mousePosition;
            initialPosition = camera.ScreenToWorldPoint(initialMousePosition);

            Debug.Log($"MOVE {initialPosition}");
        }

        if (Input.GetMouseButton(0))
        {
            var offset = initialPosition - camera.ScreenToWorldPoint(Input.mousePosition);

            camera.transform.position += offset;
        }


        var wheelMovement = Input.GetAxis("Mouse ScrollWheel");
        if (wheelMovement is < 0 or > 0)
        {
            DoZoom(wheelMovement);
        }

        camera.transform.position = ClampCamera(camera.transform.position);
    }

    void DoZoom(float wheelMovement)
    {
        float newSize = camera.orthographicSize + wheelMovement * offsetZoom;
        camera.orthographicSize = Mathf.Clamp(newSize, minSize, maxSize);
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
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

    private void AndroidMovement()
    {
        var touch = Input.GetTouch(0);
        if (Input.touches.Length < 1) return;
        switch (touch.phase)
        {
            case TouchPhase.Began:
                Debug.Log("Began");
                initialPosition = touch.position;
                break;
            case TouchPhase.Moved:
            case TouchPhase.Stationary:
                // Debug.Log("Moved");
                currentPosition = touch.position;
                Debug.Log($"Initial {initialPosition} Ended {endedPosition}");
                MoveWhileIsMoving();

                break;
            case TouchPhase.Ended:
                endedPosition = touch.position;
                // Debug.Log("Moved");
                currentPosition = touch.position;
                Debug.Log($"Initial {initialPosition} Ended {endedPosition}");
                MoveWithEndPoint();
                Debug.Log($"Initial {initialPosition} Ended {endedPosition}");
                break;
            case TouchPhase.Canceled:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void MoveWithEndPoint()
    {
        if (initialPosition.x < endedPosition.x)
        {
            transform.position += Vector3.right * ((endedPosition.x - initialPosition.x) * Time.deltaTime);

            Debug.Log($"Right");
        }
        else
        {
            transform.position -= Vector3.right * ((endedPosition.x - initialPosition.x) * Time.deltaTime);

            Debug.Log($"Left");
        }

        if (initialPosition.y < currentPosition.y)
        {
            transform.position += Vector3.up * ((endedPosition.y - initialPosition.y) * Time.deltaTime);

            Debug.Log($"UP");
        }
        else
        {
            transform.position -= Vector3.up * ((endedPosition.y - initialPosition.y) * Time.deltaTime);

            Debug.Log($"Down");
        }
    }

    private void MoveWhileIsMoving()
    {
        if (initialPosition.x < currentPosition.x)
        {
            transform.position += Vector3.right * Time.deltaTime;

            Debug.Log($"Right");
        }
        else
        {
            transform.position -= Vector3.right * Time.deltaTime;

            Debug.Log($"Left");
        }

        if (initialPosition.y < currentPosition.y)
        {
            transform.position += Vector3.up * Time.deltaTime;

            Debug.Log($"UP");
        }
        else
        {
            transform.position -= Vector3.up * Time.deltaTime;

            Debug.Log($"Down");
        }
    }
}