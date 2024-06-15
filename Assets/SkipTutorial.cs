using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTutorial : MonoBehaviour
{
    public static int Sesion;

    [SerializeField] private GameObject[] _tutor;
    [SerializeField] private GameObject[] _onCanvas;
    [SerializeField] private Texture2D _weapon;

    private void Start()
    {
        if(Sesion != 0)
        {
            foreach(var off in _tutor)
            {
                off.SetActive(false);
            }

            foreach(var on in _onCanvas)
            {
                on.SetActive(true);
            }

            Cursor.SetCursor(_weapon, new Vector2(31, 32), CursorMode.Auto);

        }

    }

    public void NextSession()
    {
        Sesion++;
    }
}
