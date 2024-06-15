using UnityEngine;

public class Coursorechanged : MonoBehaviour
{
    [SerializeField] private Texture2D _cursoreWeapon;
    [SerializeField] private Texture2D _cursoreMain;
    private void Start()
    {
        //UseMainCursore();
    }
    public void UseWeaponCursore()
    {
        Cursor.SetCursor(_cursoreWeapon, new Vector2(31.0f, 32.0f), CursorMode.Auto);
    }
    public void UseMainCursore()
    {
        Cursor.SetCursor(_cursoreMain, Vector2.zero, CursorMode.Auto);
    }
    public void LoseCursore(bool value)
    {
        Cursor.visible = value;
    }
}
