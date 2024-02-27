using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI txtScore;
    [SerializeField] TextMeshProUGUI txtTime;

    [Header("\n--------End game ---------\n")]
    [SerializeField] GameObject goMenuEnd;
    [SerializeField] TextMeshProUGUI txtScoreEnd;


    // Start is called before the first frame update
    private void Start()
    {
        goMenuEnd.SetActive(false);
    }
    public void UpdateScore(int score)
    {
        txtScore.text = "Score: " + score.ToString();
    }
    public void UpdateTime(float time) {
        txtTime.text = string.Format("Time: {0:0.00}", time);
    }
    public void EndGame(int score)
    {
        goMenuEnd.SetActive(true);
        txtScoreEnd.text = "Your Score: " + score.ToString();
    }
}
