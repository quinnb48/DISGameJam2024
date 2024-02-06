using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZoneScript : MonoBehaviour
{

    public GameObject endSpot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            col.gameObject.transform.position = endSpot.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.position = endSpot.transform.position;
        }
    }
}
