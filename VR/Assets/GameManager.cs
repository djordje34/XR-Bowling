using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Transform[] pins;
    public Transform[] balls;
    public Text scoreText;

    private Vector3[] pinStartPositions;
    private Quaternion[] pinStartRotations;
    private Vector3[] ballStartPositions;
    private Quaternion[] ballStartRotations;

    private int score;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InitializePositions();
        ResetScore();
    }

    void InitializePositions()
    {
        pinStartPositions = new Vector3[pins.Length];
        pinStartRotations = new Quaternion[pins.Length];
        for (int i = 0; i < pins.Length; i++)
        {
            pinStartPositions[i] = pins[i].position;
            pinStartRotations[i] = pins[i].rotation;
        }

        ballStartPositions = new Vector3[balls.Length];
        ballStartRotations = new Quaternion[balls.Length];
        for (int i = 0; i < balls.Length; i++)
        {
            ballStartPositions[i] = balls[i].position;
            ballStartRotations[i] = balls[i].rotation;
        }
    }

    public void ResetGame()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].position = pinStartPositions[i];
            pins[i].rotation = pinStartRotations[i];
            Rigidbody pinRigidbody = pins[i].GetComponent<Rigidbody>();
            if (pinRigidbody != null)
            {
                pinRigidbody.velocity = Vector3.zero;
                pinRigidbody.angularVelocity = Vector3.zero;
            }
        }

        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].position = ballStartPositions[i];
            balls[i].rotation = ballStartRotations[i];
            Rigidbody ballRigidbody = balls[i].GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                ballRigidbody.velocity = Vector3.zero;
                ballRigidbody.angularVelocity = Vector3.zero;
            }
        }

        ResetScore();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
