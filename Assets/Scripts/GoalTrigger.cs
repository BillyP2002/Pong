using TMPro;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    private int _player2Score;
    public TextMeshProUGUI player2ScoreText;
    

    public GameObject winTextObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player2Score = 0;
        SetPlayer2ScoreText();
    }

    void SetPlayer2ScoreText()
    {
        player2ScoreText.text = "P2 Score: " + _player2Score;
        if (_player2Score >= 11)
        {
            winTextObject.SetActive(true);

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            _player2Score++;
            SetPlayer2ScoreText();
            
        }
    }
}

