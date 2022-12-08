using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Success : MonoBehaviour
{
    [SerializeField] float collisionTolerance = 3f;
    ItemCounter itemCounter;
    Vector3 position;
    Vector3 playerPosition;
    GameObject player;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        itemCounter = GameObject.FindGameObjectWithTag("Tornados").GetComponent<ItemCounter>();
    }

    /*
    private void OnCollisionEnter(Collision other)
    {
        itemCounter = GameObject.FindGameObjectWithTag("Tornados").GetComponent<ItemCounter>();
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Cem"+ itemCounter.items);
            if(itemCounter.items == 5)
            {
                SceneManager.LoadScene("Success");
            }
            
        }
    }*/

    private void FixedUpdate()
    {
        
        if (itemCounter.items >= 5)
        {
            if(isCollided())
            {
                SceneManager.LoadScene("Success");
            }
                
        }

    }

    private bool isCollided()
    {
        position = transform.position;
        playerPosition = player.transform.position;
        if (Vector3.Distance(position, playerPosition) < collisionTolerance)
        {
            return true;
        }
        return false;
    }
}
