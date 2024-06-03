using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinksToCreating : MonoBehaviour
{
    [Header("Start point(X)")]
    public float PointStartPlatformX;
    [Space(10)]

    [Header("Player character")]
    public float MaxPlayerJump;
    public int MaxJupmXdiatance;
    [Space(10)]

    [Header("Platforms")]
    public GameObject[] downPlatformPrefabs;
    public GameObject[] upPlatformPrefabs;
    [Header("Size Platforms")]
    public Vector2 SizeMinMaxX;
    public Vector2 SizeMinMaxY;
    [Header("Platform install")]
    public float DiatanceBetweensDownPlatform;
    public int PlatformCount;
    public float ZeroPointDownPlatform;

}
