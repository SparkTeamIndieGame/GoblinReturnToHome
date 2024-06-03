using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class CreatingLvl : MonoBehaviour
{
    private LinksToCreating _linksToCreating;
    //need Links
    private float pointStartPlatformX;

    private float maxPlayerJump;
    private float maxJupmXdiatance;

    private GameObject[] downPlatformPrefabs;
    private GameObject[] upPlatformPrefabs;

    private float diatanceBetweensDownPlatform;
    private int pltformCount;
    float zeroPointDownPlatform;

    private Vector2 sizeMinMaxX;
    private Vector2 sizeMinMaxY;
  
    //private in Class
    private float maxPosYDownPlatform;
    private float maxPosYUpPlatform;

    private GameObject[] downPlatforms;
    private GameObject[] upPlatforms;

    private void TakeLinks()
    {
        _linksToCreating = this.gameObject.GetComponent<LinksToCreating>();

        pointStartPlatformX = _linksToCreating.PointStartPlatformX;
        maxPlayerJump = _linksToCreating.MaxPlayerJump;
        maxJupmXdiatance = _linksToCreating.MaxJupmXdiatance;

        downPlatformPrefabs = _linksToCreating.downPlatformPrefabs;
        upPlatformPrefabs = _linksToCreating.upPlatformPrefabs;

        diatanceBetweensDownPlatform = _linksToCreating.DiatanceBetweensDownPlatform;
        pltformCount = _linksToCreating.PlatformCount;
        zeroPointDownPlatform = _linksToCreating.ZeroPointDownPlatform;

        sizeMinMaxX = _linksToCreating.SizeMinMaxX;
        sizeMinMaxY = _linksToCreating.SizeMinMaxY;
    }
   
    private void AutoCreateSize(GameObject gameObject)
    {
        gameObject.transform.localScale = new Vector3(Random.Range(sizeMinMaxX.x, sizeMinMaxX.y), Random.Range(sizeMinMaxY.x, sizeMinMaxY.y), 1.0f);

    }
    private void CreateDownPlatform()
    {
        downPlatforms = new GameObject[pltformCount];
        
        maxPosYDownPlatform = maxPlayerJump + 0.5f;
        float currentPosXdownPlatform = pointStartPlatformX;

        for (int i = 0; i < downPlatforms.Length; i++) 
        {
            downPlatforms[i] = downPlatformPrefabs[0]; //поменять!
            AutoCreateSize(downPlatforms[i]);
            if (i == 0)
            {
                currentPosXdownPlatform = pointStartPlatformX;
            }
            else
            {
                currentPosXdownPlatform += (downPlatforms[i-1].transform.localScale.x / 2) + diatanceBetweensDownPlatform;
            }
            GameObject newDownPlatform = Instantiate(downPlatforms[i], new Vector3(currentPosXdownPlatform, Random.Range(zeroPointDownPlatform, maxPosYDownPlatform /*maxPlayerJump*/), 0.0f), Quaternion.identity);
            downPlatforms[i] = newDownPlatform;
        }
    }
    private void CreateUpPlatform()
    {
        float currentPosXupPlatform; 
        float currentPosYupPlatform;

        upPlatforms = new GameObject[pltformCount];

        for (int i = 0; i < upPlatforms.Length; i++)
        {
            upPlatforms[i] = upPlatformPrefabs[0]; //поменять!!
            AutoCreateSize(upPlatforms[i]);
            currentPosXupPlatform = downPlatforms[i].transform.position.x + (downPlatforms[i].transform.localScale.x / 2) + maxJupmXdiatance;

            maxPosYUpPlatform = downPlatforms[i].transform.position.y + maxPlayerJump + 0.5f;
            currentPosYupPlatform = downPlatforms[i].transform.position.y + (maxPlayerJump / 2);
            GameObject newUpPlatform = Instantiate(upPlatforms[i], new Vector3(currentPosXupPlatform, Random.Range(currentPosYupPlatform, maxPosYUpPlatform), 0.0f), Quaternion.identity);
            upPlatforms[i] = newUpPlatform;
        }
    }
    public void CreateFullLvlAutomatycly()
    {
        TakeLinks();
        CreateDownPlatform();
        CreateUpPlatform();
    }

    public void DestroyAll()
    {
        for (int i = 0; i < pltformCount; i++)
        {
            DestroyImmediate(upPlatforms[i]);
            DestroyImmediate(downPlatforms[i]);
        }
    }
}
