using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JSManager : MonoBehaviour
{
    public void GetNickname(string nickname) 
    {
        DataManager.nickname = nickname;
        SceneManager.LoadScene(1);
    }
}
