using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public float playerScore;
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }
}
