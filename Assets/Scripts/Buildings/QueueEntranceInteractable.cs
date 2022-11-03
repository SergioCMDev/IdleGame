using UnityEngine;


namespace Buildings
{
    internal class QueueEntranceInteractable : MonoBehaviour
    {
        private QueueEntrance _queueEntrance;
        public void Init(QueueEntrance queueEntrance)
        {
            _queueEntrance = queueEntrance;
        }

        private void OnMouseDown()
        {
            Upgrade();
        }

        public void Upgrade()
        {
            Debug.Log($"Upgraded {this.gameObject.name}");

            _queueEntrance.Upgrade();
        }
    }
}