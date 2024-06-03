using UnityEngine;
[ExecuteInEditMode]
public class TextureTiling : MonoBehaviour
{
    private Transform _scalePlatform;
    private SpriteRenderer _spriteRenderer;

    void Awake ()
    {
        _scalePlatform = transform.GetChild(0);
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _scalePlatform.localScale = new Vector3(_spriteRenderer.size.x, _spriteRenderer.size.y, _scalePlatform.localScale.z);
    }
}
