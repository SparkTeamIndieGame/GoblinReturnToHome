using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextCreator : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _timeBetween;
    [SerializeField] private GameObject _button;
    private string titulText = "Ура! Вы нашли первый бонус! \r\nСоберайте бонусы, расположеные на уровне." +
                                "\r\nСреди них Вы найдете Пополнение здоровья, новое оружие, боеприпасы!\t";

    private void Start()
    {
        StartCoroutine(TextAnim());
    }
    private IEnumerator TextAnim()
    {
        for (int i = 0; i < titulText.Length; i++)
        {
            _text.text += titulText[i].ToString();
            yield return new WaitForSeconds(_timeBetween);
        }
        _button.SetActive(true);
    }
}
