using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRef : MonoBehaviour
{
    [SerializeField] Text text;

    private void Start()
    {
        text.text = "Your Score is: " + PlayerScore.playerScore;
    }
}
