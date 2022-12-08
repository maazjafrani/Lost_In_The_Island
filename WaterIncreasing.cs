using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterIncreasing : MonoBehaviour

{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 200), transform.position.z);
        //transform.position = new Vector3(transform.position.x, transform.position .y + Time.time * speed, transform.position.z);   
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed, transform.position.z);
    }


   
}

