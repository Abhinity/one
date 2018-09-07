using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    private int score;
    public Text scoreText;

    public void Start()
    {
        scoreText = GetComponent<Text>();

    }

   


}
