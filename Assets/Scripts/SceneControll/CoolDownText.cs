using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownText : MonoBehaviour
{
    [SerializeField] private Text _cooldownText;
    [SerializeField] private float _coooldownTime;
    [SerializeField] private int _cooldownCount;
    [SerializeField] private GameObject _buttonStGame;

    private void Start()
    {
        StartCoroutine(TextCreator());
    }
    private IEnumerator TextCreator()
    {
        for (int i = _cooldownCount; i >= 0; i--)
        {
            _cooldownText.text = $"{i.ToString()} ...";
            yield return new WaitForSeconds(_coooldownTime);
        }
        _buttonStGame.SetActive(true);
    }

}
