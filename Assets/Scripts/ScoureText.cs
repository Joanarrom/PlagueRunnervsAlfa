using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoureText : MonoBehaviour
{

    public Transform player;
    public Text scoreText;
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            scoreText.text = player.position.z.ToString("0");
        }
      
        highScore.text = PlayerPrefs.GetInt("highScore", 0).ToString("0");
    }
}
