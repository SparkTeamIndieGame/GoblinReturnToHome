using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingLvl : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 startPlatfopm;
    public float distance;
    public int count;


    private Vector3 current_pos;
    public void Create()
    {
        Vector2 offsetY = FindAnyObjectByType<TextureTiling>().GetComponent<SpriteRenderer>().size;
        float zeroCordinatos = FindAnyObjectByType<TextureTiling>().gameObject.transform.position.y;
        float maxJump = 4.0f;
        
        prefab = Resources.Load<GameObject>("Platform (4)");
        current_pos = new Vector3(-160.0f,3.0f,0.0f);
        for (int i = 0; i <= 17; i++)
        {
            Instantiate(prefab, new Vector3(current_pos.x, Random.Range(offsetY.y/2 + zeroCordinatos, offsetY.y/2 + zeroCordinatos + maxJump)), Quaternion.identity );
            current_pos.x += 35.0f;
        }
        Debug.Log(offsetY/2);
    }
}
