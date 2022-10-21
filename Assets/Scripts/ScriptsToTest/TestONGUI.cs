using UnityEngine;

namespace ScriptsToTest
{
    public class TestONGUI : MonoBehaviour
    {
        void OnGUI()
        {
            if (GUILayout.Button("Start Bike"))
                Debug.Log("EDD");
            // _bikeController.StartBike();
            if (GUILayout.Button("Turn Left"))
                Debug.Log("EDD111");
            // _bikeController.Turn(Direction.Left);
            if (GUILayout.Button("Turn Right"))
                Debug.Log("EDD111222");
            // _bikeController.Turn(Direction.Right);
            if (GUILayout.Button("Stop Bike"))
                Debug.Log("EDD111222555");
            // _bikeController.StopBike();
        }

    }
}
