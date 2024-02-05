using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public float startY;
    public float endY;
    public float moveSpeed;
    public float waitTime;
    public bool goingDown;
    public bool waiting;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        goingDown = true;
        waiting = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (waiting == false){
            if(goingDown){
                transform.position += Vector3.down * moveSpeed * Time.deltaTime;
                if (transform.position.y <= endY){
                    goingDown = false;
                    waiting = true;
                }
            }
            else{
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;
                if (transform.position.y >= startY){
                    goingDown = true;
                    waiting = true;
                }
            }
        }
        timer += Time.deltaTime;
        if(timer >= waitTime){
            waiting = false;
            timer = 0;
        }


    }
}
