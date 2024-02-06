using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZoneScript : MonoBehaviour
{
    public string nextSceneName;
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
