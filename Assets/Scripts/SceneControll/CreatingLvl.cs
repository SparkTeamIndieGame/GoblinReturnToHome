using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class CreatingLvl : MonoBehaviour
{
    private LinksToCreating _linksToCreating;

    private float maxPlayerJump;
    private float pointStartPlatform;


    private GameObject downPlatformPrefab;
    private GameObject upPlatformPrefab;

    private Vector2 sizeMinMaxX;
    private Vector2 sizeMinMaxY;
  
    private float diatanceBetweensDownPlatform;
    private float diatanceBetweensUpPlatform;

    private float maxPosYDownPlatform;
    private float maxPosYUpPlatform;

    private int pltformCount;


    private GameObject[] downPlatforms;
    private GameObject[] upPlatform;
    
    public void TakeLinks()
    {
        _linksToCreating = this.gameObject.GetComponent<LinksToCreating>();
        maxPlayerJump = _linksToCreating.MaxPlayerJump;
        pointStartPlatform = _linksToCreating.PointStartPlatform;
        downPlatformPrefab = _linksToCreating.downPlatformPrefab;
        upPlatformPrefab = _linksToCreating.upPlatformPrefab;
        sizeMinMaxX = _linksToCreating.SizeMinMaxX;
        sizeMinMaxY = _linksToCreating.SizeMinMaxY;
        diatanceBetweensDownPlatform = _linksToCreating.DiatanceBetweensDownPlatform;
        diatanceBetweensUpPlatform = _linksToCreating.DiatanceBetweensUpPlatform ;
        pltformCount = _linksToCreating.PlatformCount;
    }
    public void CreateSize()
    {
        downPlatforms = new GameObject[pltformCount];
        upPlatform = new GameObject[pltformCount];

        
    }
    private void AutoCreateSize(GameObject prefab)
    {
        prefab.transform.localScale = new Vector3(Random.Range(sizeMinMaxX.x, sizeMinMaxX.y), Random.Range(sizeMinMaxY.x, sizeMinMaxY.y), 1.0f);

    }
    public void CreateDownPlatform()
    {
        float scaleLastplatform = 0.0f;
        
        float zeroPoint = -1;
        maxPosYDownPlatform = zeroPoint + maxPlayerJump;
        float currentPosX = pointStartPlatform;
        for (int i = 0; i < downPlatforms.Length; i++) 
        {
            downPlatforms[i] = newOlatform;
            GameObject newOlatform = Instantiate(downPlatforms[i], new Vector3(currentPosX + (downPlatforms[i].transform.localScale.x / 2), Random.Range(zeroPoint, maxPlayerJump), 0.0f), Quaternion.identity);
           
            currentPosX += downPlatforms[i].transform.localScale.x + diatanceBetweensDownPlatform;

            downPlatforms[i] = newOlatform;
            





        }
    }
    public void CreateUpPlatform()
    {
        float scaleLastplatform = 0.0f;
        float zeroPoint = -1;
        //pointStartPlatform.x += diatanceBetweensDownPlatform / 2;
        maxPosYUpPlatform = zeroPoint + (maxPlayerJump * 2);

        for (int i = 0; i < upPlatform.Length; i++)
        {
            //Instantiate(upPlatform[i], new Vector3(pointStartPlatform.x + scaleLastplatform + diatanceBetweensUpPlatform, Random.Range(maxPosYDownPlatform + 1.0f, maxPosYUpPlatform), 0.0f), Quaternion.identity);
            if (i == 0)
            {
                scaleLastplatform = 0.0f;
            }
            else
            {
                scaleLastplatform = downPlatforms[i - 1].transform.localScale.x / 2.0f;
            }
        }
    }

}
