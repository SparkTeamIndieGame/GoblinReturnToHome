using UnityEngine;
using UnityEngine.SceneManagement;

public class CusrorChange : MonoBehaviour
{
    public Texture2D cursorTexture;
    private Vector2 _hotSpot;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            _hotSpot = new Vector2(60, 60);
        }
        else
        {
            _hotSpot = Vector2.zero;
        }

        Cursor.SetCursor(cursorTexture, _hotSpot, CursorMode.Auto);
        Cursor.visible = true;
    }
}
