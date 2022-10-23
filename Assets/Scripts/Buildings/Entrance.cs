using System.Collections.Generic;
using Services.GameConfigurator;
using UnityEngine;
using Utils;

namespace Buildings
{
    public class Entrance : MonoBehaviour
    {
        // private List<ILeveable> _queueEntrances = new();
        private List<QueueEntrance> _queueEntrancesEnabled = new();
        [SerializeField] private QueueEntrance entrancePrefab; //TODO DO PREFAB GETTER

        public void Init()
        {
            var gameConfiguration = ServiceLocator.Instance.GetService<IGameConfigurator>().GameConfiguration;
            for (int i = 0; i < gameConfiguration.MaximumNumberOfEntrance; i++)
            {
               var queueEntranceInstance = Instantiate(entrancePrefab);
               var leveable = queueEntranceInstance.GetComponent<ILeveable>();
               var profitable = queueEntranceInstance.GetComponent<IProfitable>();
                // IProfitable queueEntranceProfitable = new QueueEntrance();
                queueEntranceInstance.Init(i, gameConfiguration.MaximumNumberOfEntrance);
                _queueEntrancesEnabled.Add(queueEntranceInstance);
            }
        }

        public QueueEntrance GetQueue(int id)
        {
            return _queueEntrancesEnabled[id];
        }
    }
}