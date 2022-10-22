using System.Collections.Generic;
using Services.Interfaces;
using UnityEngine;

namespace Services.Utils
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