using Services.Timer;
using UnityEngine;
using Utils;

public class TestingScript : MonoBehaviour
{
    private ITimerGenerator _timerGeneratorService;

    void Start()
    {
        _timerGeneratorService = ServiceLocator.Instance.GetService<ITimerGenerator>();
        var timer = _timerGeneratorService.GenerateTimer(2);
    }
    
}
