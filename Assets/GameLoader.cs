using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private List<ScriptableObject> loadablesSO;
    private Dictionary<ILoadable, bool> loadableStatus;

    private void Start()
    {
        loadableStatus = new Dictionary<ILoadable, bool>();
        ExecuteComponents(loadablesSO);
    }

    private void ExecuteComponents(List<ScriptableObject> list)
    {
        List<ILoadable> loadables = new();
        foreach (var loadable in list)
        {
            var component = (ILoadable)loadable;
            if (component.Dependencies.Contains(loadable))
            {
                RemoveInnerSelfComponent(component, loadable);
            }

            loadables.Add(component);
        }

        foreach (var loadable in loadables)
        {
            if (loadableStatus.ContainsKey(loadable) && loadableStatus[loadable]) continue;
            if (loadable.Dependencies is { Count: > 0 })
            {
                ExecuteComponents(loadable.Dependencies);
            }

            loadable.Execute();

            loadableStatus.Add(loadable, true);
            if (!loadable.IsService) continue;
            var objectType = loadable.GetType();
            if (objectType.GetInterfaces().Any(x => x != typeof(ILoadable)))
            {
                var interfaz = objectType.GetInterfaces().Single(x => x != typeof(ILoadable));
                ServiceLocator.Instance.RegisterService(interfaz, loadable);
                continue;
            }
            ServiceLocator.Instance.RegisterService(objectType, loadable);
        }
    }

    private static void RemoveInnerSelfComponent(ILoadable component, ScriptableObject loadable)
    {
        var itselfComponent = component.Dependencies.FindAll(x => x == loadable);
        foreach (var sameComponent in itselfComponent)
        {
            component.Dependencies.Remove(sameComponent);
        }
    }
}