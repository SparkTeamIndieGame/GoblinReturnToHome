using UnityEngine;
using UnityEngine.UI;
using YG;

public class ChangeBackgroundMainForLanguage : MonoBehaviour
{
    [SerializeField] private Sprite[] _backGroundMain; //0-ru; 1-en; 2-tr;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    void Start()
    {
        Localisation();
    }

    private void Localisation()
    {
        switch (YandexGame.EnvironmentData.language)
        {

            case ("ru"):
                {
                    image.sprite = _backGroundMain[0];
                    break;
                }

            case ("en"):
                {
                    image.sprite = _backGroundMain[1];

                    break;
                }

            case ("tr"):
                {
                    image.sprite = _backGroundMain[2];

                    break;
                }
            default:
                break;
        }
    }
}
