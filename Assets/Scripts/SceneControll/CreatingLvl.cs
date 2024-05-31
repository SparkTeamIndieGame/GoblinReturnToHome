using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingLvl : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 startPlatfopm;
    public float distance;
    public int count;
    private LinksToCreating _linksToCreating;

    private Vector3 current_pos;
    public void Create()
    {
       
        
        Vector2 offsetY = FindAnyObjectByType<TextureTiling>().GetComponent<SpriteRenderer>().size;
        float zeroCordinatos = FindAnyObjectByType<TextureTiling>().gameObject.transform.position.y;
        float maxJump = 4.0f;
        
        prefab = Resources.Load<GameObject>("Platform (4)");
        GameObject children = prefab.GetComponentInChildren<BoxCollider>().gameObject;
        current_pos = new Vector3(-160.0f,3.0f,0.0f);
        //1st lvl
        for (int i = 0; i <= 17; i++)
        {
            
            Instantiate(prefab, new Vector3(current_pos.x + (children.transform.localScale.x / 2), Random.Range(offsetY.y/2 + zeroCordinatos, offsetY.y/2 + zeroCordinatos + maxJump)), Quaternion.identity );
            current_pos.x += (35.0f + children.transform.localScale.x);
            //current_pos.x += 35.0f;

        }
        //secondlvl
        current_pos = new Vector3(-160.0f, 3.0f, 0.0f);
        for (int i = 0; i <= 17; i++)
        {
            
            Instantiate(prefab, new Vector3(current_pos.x + (children.transform.localScale.x / 2) + 17.5f, Random.Range(maxJump + 1, maxJump * 2)), Quaternion.identity);
            current_pos.x += (52.5f + children.transform.localScale.x);
        }
       
    }
    public void TestLink()
    {
        _linksToCreating = this.gameObject.GetComponent<LinksToCreating>();
        
        Debug.Log(_linksToCreating.speed);
    }
}
