using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public class Timer
    {
        private float _remainingTime;
        private bool _repeatable;
        public Action ActionToDo { get; set; }

        private readonly CoroutineExecutioner _coroutineExecutioner;

        public Timer()
        {
            _coroutineExecutioner = ServiceLocator.Instance.GetService<CoroutineExecutioner>();
        }

        private IEnumerator CountTime()
        {
            yield return new WaitForSeconds(_remainingTime);
            ActionToDo?.Invoke();
            if (!_repeatable) yield return null;
            Start();
        }

        public void Init(float timeToWait, bool repeatable)
        {
            _remainingTime = timeToWait;
            _repeatable = repeatable;
        }

        public void Start()
        {
            _coroutineExecutioner.StartChildCoroutine(CountTime());
        }
    }
}