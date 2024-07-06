using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LinkButtonStore: MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] private Animator _canvasMenu;

    private void Start()
    {
        var language = YandexGame.EnvironmentData.language;

      
        switch (language)
        {
            case "ru":
                url = "https://yandex.ru/games/developer?name=WebGameMaster";
                break;


            case "en":
                url = "https://yandex.com/games/developer?name=WebGameMaster";
                break;


            case "tr":
                url = "https://yandex.com/games/developer?name=WebGameMaster";
                break;
        }


    }

    public void Link ()
    {
        Application.OpenURL(url);
    }

}
