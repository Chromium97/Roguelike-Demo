using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{


    [SerializeField]
    public static int totalScore = 0;
    Text scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue.text = "Score: " + totalScore;
    }
}
