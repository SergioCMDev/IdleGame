using System.Collections.Generic;
using UnityEngine;

public interface ILoadable
{
    public void Execute();
    public List<ScriptableObject> Dependencies { get; }
    public int OrderToExecute { get;  }
    bool IsService { get; }
}