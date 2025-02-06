using TMPro;
using UnityEngine;

public class Goal2Trigger : MonoBehaviour
{
    private int _player1Score;
    public TextMeshProUGUI player1ScoreText;

    public GameObject winTextObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player1Score = 0;
        SetPlayer1ScoreText();
    }
    

    void SetPlayer1ScoreText()
    {
        player1ScoreText.text = "P1 Score: " + _player1Score;
        if (_player1Score >= 11)
        {
            winTextObject.SetActive(true);

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            _player1Score++;
            SetPlayer1ScoreText();
            
        }
    }
}