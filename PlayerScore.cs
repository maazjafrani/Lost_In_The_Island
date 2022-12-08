using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] Timer timer;
    public static float playerScore;
  
    private void Update()
    {
        playerScore = health.currentHealth * TimeEvaluater(timer.timePast);
        
    }

    private float TimeEvaluater(float time)
    {
        if(time < 400)
        {
            return 200;
        }
        else if(time < 450)
        {
            return 150;
        }
        else if(time < 500)
        {
            return 100;
        }
        else if(time < 550)
        {
            return 75;
        }
        else if(time < 600)
        {
            return 50;
        }
        else
        {
            return 10;
        }
    }
}
