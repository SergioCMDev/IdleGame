using System.Collections.Generic;
using Services.GameConfigurator;
using UnityEngine;
using Utils;

namespace Buildings
{
    public class Entrance : MonoBehaviour
    {
        private List<ILeveable> _queueEntrances = new();
        private List<ILeveable> _queueEntrancesEnabled = new();

        public void Init()
        {
            var gameConfiguration = ServiceLocator.Instance.GetService<IGameConfigurator>().GameConfiguration;
            for (int i = 0; i < gameConfiguration.MaximumNumberOfEntrance; i++)
            {
                ILeveable queueEntrance = new QueueEntrance();
                queueEntrance.Init(i, gameConfiguration.MaximumNumberOfEntrance);
                _queueEntrancesEnabled.Add(queueEntrance);
            }
        }

        public ILeveable GetQueue(int id)
        {
            return _queueEntrancesEnabled[id];
        }
    }
}