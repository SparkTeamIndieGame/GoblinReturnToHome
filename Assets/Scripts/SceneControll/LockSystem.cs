using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LockSystem : MonoBehaviour
{
    public static bool[] UnlockLevel;
    [SerializeField] private GameObject[] _lock;


    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    // Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

    private void Awake()
    {
        // Проверяем запустился ли плагин
        if (YandexGame.SDKEnabled == true)
        {
            // Если запустился, то запускаем Ваш метод
            GetData();

            // Если плагин еще не прогрузился, то метод не запуститься в методе Start,
            // но он запустится при вызове события GetDataEvent, после прогрузки плагина
        }
    }

    void Start()
    {
       for(int i =0; i <UnlockLevel.Length; i++)
        {
            if (UnlockLevel[i])
            {
                _lock[i].SetActive(false);
            }
        }
    }

    // Ваш метод, который будет запускаться в старте
    public void GetData()
    {
        UnlockLevel = YandexGame.savesData.Levels;
    }

    public static void Save()
    {
        YandexGame.savesData.Levels = UnlockLevel;
        YandexGame.SaveProgress();
    }
}
