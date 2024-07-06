using UnityEngine;
using UnityEngine.UI;
using YG;

public class TutorialChangeImages : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _imageScene;
    [SerializeField] private Sprite[] _imageRU, _imageEN, _imageTR;

    private void Start()
    {
        var localisation = YandexGame.EnvironmentData.language;

        Localisation(localisation);
    }

    // Update is called once per frame
    private void Localisation(string localisation)
    {
        switch (localisation)
        {

            case ("ru"):
                {
                    for(int i =0; i<_imageScene.Length; i++)
                    {
                        _imageScene[i].sprite = _imageRU[i];
                    }
                    break;
                }

            case ("en"):
                {
                    for (int i = 0; i < _imageScene.Length; i++)
                    {
                        _imageScene[i].sprite = _imageEN[i];
                    }
                    break;
                }

            case ("tr"):
                {
                    for (int i = 0; i < _imageScene.Length; i++)
                    {
                        _imageScene[i].sprite = _imageTR[i];
                    }
                    break;
                }
            default:
                break;
        }
    }
}
