using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextCreator : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _timeBetween;
    [SerializeField] private GameObject _button;
    [TextArea]
    [SerializeField] private string _userText;
    private string defaultText = "Ура! Вы нашли первый бонус! \r\nСоберайте бонусы, расположеные на уровне." +
                                "\r\nСреди них Вы найдете Пополнение здоровья, новое оружие, боеприпасы!\t";

    private void Start()
    {
        if (_userText != string.Empty)
        {
            defaultText = _userText;
        }
        StartCoroutine(TextAnim());
    }
    private IEnumerator TextAnim()
    {
        for (int i = 0; i < defaultText.Length; i++)
        {
            _text.text += defaultText[i].ToString();
            yield return new WaitForSeconds(_timeBetween);
        }
        _button.SetActive(true);
    }
}
