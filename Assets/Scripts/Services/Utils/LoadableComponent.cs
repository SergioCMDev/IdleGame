using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public abstract class LoadableComponent : ScriptableObject, ILoadable
    {
        [SerializeField] private bool _isService;
        [SerializeField] private int _orderToExecute;
        [SerializeField] private List<ScriptableObject> _dependencies;

        public abstract void Execute();
    
        public List<ScriptableObject> Dependencies => _dependencies;
        public int OrderToExecute => _orderToExecute;
        public bool IsService => _isService;
    }
}