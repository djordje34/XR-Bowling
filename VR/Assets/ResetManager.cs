using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetManager : MonoBehaviour
{
    public Transform[] pins;
    public Transform[] balls;
    public Vector3[] pinStartPositions;
    public Quaternion[] pinStartRotations;
    public Vector3[] ballStartPositions;
    public Quaternion[] ballStartRotations;
    public Button resetButton;
    public GameManager gameManager;

    void Start()
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

        resetButton.onClick.AddListener(ResetGame);
    }

    public void ResetGame()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].position = pinStartPositions[i];
            pins[i].rotation = pinStartRotations[i];
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].position = ballStartPositions[i];
            balls[i].rotation = ballStartRotations[i];
            balls[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            balls[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        gameManager.ResetScore();
    }
}
