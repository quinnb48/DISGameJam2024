using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntController : MonoBehaviour
{
    //public float wanderMaxR;
    public float wanderMaxL;
    //public bool goingRight;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if(transform.position.x <= wanderMaxL){
            Destroy(gameObject);
        }
        //if(goingRight){
        //    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        //    if (transform.position.x >= wanderMaxR){
        //        goingRight = false;
        //    }
        //}
        //else{
        //    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        //    if (transform.position.x <= wanderMaxL){
        //        goingRight = true;

        //    }
        //}
    }
}
