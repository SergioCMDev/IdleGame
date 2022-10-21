using System;
using UnityEngine;

namespace Services.PopupManager
{
    [Serializable]
    public struct PopupGetter
    {
        public PopupType PopupType;
        public GameObject Prefab;
    }

    public enum PopupType
    {
        Empty, TestPopup
    }

    [CreateAssetMenu(fileName = "PopupGenerator", menuName = "Loadable/Services/PopupGenerator")]
    public class PopupGenerator : LoadableComponent
    {
        [SerializeField] private PopupList popupList;
        private GameObject _currentOpenedPopup;
        private PopupType _currentlyOpenedType;
        private UnityEngine.Camera _camera;
        private int _currentSortingOrder;
        private Transform _positionWhereSpawn;

        // public void InstantiatePopup(InstantiatePopupEvent instantiatePopupEvent)
        // {
        //     InstantiatePopup(instantiatePopupEvent.popupType);
        // }

        public T InstantiatePopup<T>(PopupType popupType)
        {
            _currentOpenedPopup = InstantiatePopup(popupType);
            return _currentOpenedPopup.GetComponent<T>();
        }

        private GameObject InstantiatePopup(PopupType popupType)
        {
            GameObject prefab = popupList.GetPrefabByType(popupType);

            _currentOpenedPopup = Instantiate(prefab, _positionWhereSpawn, false);
            var closeablePopup = _currentOpenedPopup.GetComponent<ICloseablePopup>();
            closeablePopup.HasToClosePopup += ClosePopup;
            _currentOpenedPopup.gameObject.SetActive(false);
            var canvas = _currentOpenedPopup.GetComponentInChildren<Canvas>();
            if (canvas.sortingOrder <= _currentSortingOrder)
            {
                canvas.sortingOrder = _currentSortingOrder + 1;
            }

            canvas.worldCamera = _camera;
            _currentSortingOrder = canvas.sortingOrder;
            _currentlyOpenedType = popupType;
            return _currentOpenedPopup;
        }

        private void ClosePopup(GameObject popup)
        {
            popup.SetActive(false);
            _currentlyOpenedType = PopupType.Empty;
            var closeablePopup = popup.GetComponent<ICloseablePopup>();
            closeablePopup.PopupHasBeenClosed?.Invoke();
            _currentSortingOrder--;

            Destroy(popup);
        }

        public void CloseCurrentOpenedPopup()
        {
            ClosePopup(_currentOpenedPopup);
        }

        public bool IsCurrentlyOpened(PopupType popupType)
        {
            return _currentOpenedPopup != null && _currentlyOpenedType == popupType;
        }

        public override void Execute()
        {
            _camera = UnityEngine.Camera.main;
            _positionWhereSpawn = new GameObject().transform;
        }
    }
}