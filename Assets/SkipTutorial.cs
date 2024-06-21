using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTutorial : MonoBehaviour
{

    [SerializeField] private GameObject[] _onCanvas;
    [SerializeField] private Texture2D _weapon;

    private void Start()
    {

        foreach(var on in _onCanvas)
        {
            on.SetActive(true);
        }

        //Cursor.SetCursor(_weapon, new Vector2(31, 32), CursorMode.Auto);

    }
}
