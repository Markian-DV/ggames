using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static string nickname = "Player"+ Random.Range(1,999);
    public static bool isPlayerWhite = false;
    public static bool isPlayerBlack = false;
    public static int Score = 800;
}
