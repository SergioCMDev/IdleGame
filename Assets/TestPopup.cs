using System;
using UnityEngine;

public class TestPopup : MonoBehaviour, ICloseablePopup
{
    public Action<GameObject> HasToClosePopup { get; set; }
    public Action PopupHasBeenClosed { get; set; }
}
