using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class iteming : MonoBehaviour
{
    ItemCounter itemCounter;
    
    private void Start()
    {
       itemCounter = gameObject.GetComponentInParent<ItemCounter>();
        

    }



    void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "Player")
        { 
            Debug.Log("TriggeredWith: " + gameObject.name);
            itemCounter.items += 1;
            Debug.Log("Increased Items");
            itemCounter.ItemText.GetComponent<Text>().text="ITEMS "+itemCounter.items+"/5";
            Destroy(gameObject);
            }
        }


}
