using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float verticalDistance = 193;

    private void Update()
    {
        if(Mathf.Abs( player.position.y - transform.position.y) < verticalDistance)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
