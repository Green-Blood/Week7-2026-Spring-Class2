using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 10;
    }

    // Update is called once per frame
    void Update()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
