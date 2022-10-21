using Managers;
using UnityEngine;
using Utils;

public class PopupTesting : MonoBehaviour
{
    private PopupGenerator popupGenerator;

    void Start()
    {
        popupGenerator = ServiceLocator.Instance.GetService<PopupGenerator>();
        var generatetPopup = popupGenerator.InstantiatePopup<TestPopup>(PopupType.TestPopup);
        generatetPopup.gameObject.SetActive(true);
    }
}