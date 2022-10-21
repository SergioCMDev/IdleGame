﻿using System.Linq;
using UnityEngine;

namespace Utils
{
    public class Installer : MonoBehaviour
    {
        // [SerializeField] private GameObject _readInputPlayerPrefab;
        // [SerializeField] private GameObject _sceneChangerPrefab;
        // [SerializeField] private GameObject _soundManagerPrefab;
        // [SerializeField] private GameObject _timeManagerPrefab;
        // [SerializeField] private GameObject _collectibleManagerPrefab;
        [SerializeField] private GameObject _coroutineExecutionerPrefab;

        private GameObject _readInputPlayerInstance,
            _sceneChangerInstance,
            _soundManagerInstance,
            _timeManagerInstance,
            _collectibleManagerInstance,
            _coroutineExecutionerInstance,
            _levelControllerInstance;

        private bool _initialized;

        private bool Initialized => _initialized;

        private void Awake()
        {
            var installersObject = FindObjectsOfType<Installer>(true);
            if (installersObject.Any(x => x.Initialized)) return;

            // _readInputPlayerInstance = Instantiate(_readInputPlayerPrefab);
            // _sceneChangerInstance = Instantiate(_sceneChangerPrefab);
            // _soundManagerInstance = Instantiate(_soundManagerPrefab);
            // _timeManagerInstance = Instantiate(_timeManagerPrefab);
            // _collectibleManagerInstance = Instantiate(_collectibleManagerPrefab);
            _coroutineExecutionerInstance = Instantiate(_coroutineExecutionerPrefab);


            //TODO HACERLO PARA N OBJETOS NO SOLO 1
            // ServiceLocator.Instance.RegisterService<IAndroidNotificationService>(new AndroidNotificationGeneratorService());
            // ServiceLocator.Instance.RegisterService<IJsonator>(new JsonUtililyTransformer());
           
            // ServiceLocator.Instance.RegisterService<SoundDataService>(new SoundDataService());
            // ServiceLocator.Instance.RegisterService<SoundDataService>(new SoundDataService());

            // ServiceLocator.Instance.RegisterService<SoundManager>(_soundManagerInstance.GetComponent<SoundManager>());
            // ServiceLocator.Instance.RegisterService<ReadInputPlayer>(
            //     _readInputPlayerInstance.GetComponent<ReadInputPlayer>());
            ServiceLocator.Instance.RegisterService(_coroutineExecutionerInstance.GetComponent<CoroutineExecutioner>());
            // ServiceLocator.Instance.RegisterService<TimeManager>(_timeManagerInstance.GetComponent<TimeManager>());
            // ServiceLocator.Instance.RegisterService<CollectibleManager>(_collectibleManagerInstance
            //     .GetComponent<CollectibleManager>());
            // ServiceLocator.Instance.RegisterModel<IPlayerModel>(new PlayerModel());
            // ServiceLocator.Instance.RegisterModel<ISceneModel>(new SceneModel());
            //
            // ServiceLocator.Instance.RegisterService<CheckpointUpdaterService>(new CheckpointUpdaterService());
            // DontDestroyOnLoad(this);
            DontDestroyOnLoad(this);
            // DontDestroyOnLoad(_sceneChangerInstance);
            // DontDestroyOnLoad(_readInputPlayerInstance);
            // DontDestroyOnLoad(_soundManagerInstance);
            // DontDestroyOnLoad(_timeManagerInstance);
            // DontDestroyOnLoad(_collectibleManagerInstance);
            DontDestroyOnLoad(_coroutineExecutionerInstance);
            _initialized = true;
        }

        private void OnDestroy()
        {
            // ServiceLocator.Instance.RegisterService<SoundManager>(_soundManagerInstance.GetComponent<SoundManager>());
            // ServiceLocator.Instance.UnregisterService<ReadInputPlayer>();
            // ServiceLocator.Instance.UnregisterService<SceneChanger>();
            // ServiceLocator.Instance.UnregisterService<TimeManager>();
            // ServiceLocator.Instance.UnregisterService<CollectibleManager>();
            // DontDestroyOnLoad(this);
        }
    }
}