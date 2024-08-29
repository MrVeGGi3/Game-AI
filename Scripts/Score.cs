using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] private TextMeshProGUI _currentScoreText;
    [SerializeField] private TextMeshProGUI _highScoreText;

    private int _score;

    private void Awake()
    {
        _currentScoreText.text = _score.ToString();
        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore
    {
        if(_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _highScoreTex.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score ++;
        _currentScoreText.text = _score.ToString();
        UpdateHighScore();

    }


}