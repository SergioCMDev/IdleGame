using System;
using Services.PopupManager;
using UnityEngine;

namespace ScriptsToTest
{
    public class TestPopup : MonoBehaviour, ICloseablePopup
    {
        public Action<GameObject> HasToClosePopup { get; set; }
        public Action PopupHasBeenClosed { get; set; }
    }
}
