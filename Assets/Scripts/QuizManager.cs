using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public GameObject correctText;
    public GameObject wrongText;

    public GameObject questionOneCanvas;
    public GameObject questionTwoCanvas;
    public GameObject gameSceneCanvas;

    public bool isCorrectAnswer;
    public bool isWrongAnswer;

    public static int score;
    public TMP_Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        correctText.SetActive(false);
        wrongText.SetActive(false);
        questionOneCanvas.SetActive(true);
        gameSceneCanvas.SetActive(true);
        scoreText.text = "Score: " + 0;
    }

    public void OnCorrectAnswerOne()
    {
        if(isWrongAnswer == true)
        {
            return;
        }
        scoreText.text = "Score: " + 50;
        isCorrectAnswer = true;

        questionOneCanvas.SetActive(false);
        questionTwoCanvas.SetActive(true);
    }

    public void OnCorrectAnswerTwo()
    {
        if (isWrongAnswer == true)
        {
            return;
        }
        correctText.SetActive(true);
        scoreText.text = "Score: " + 100;
    }

    public void OnWrongAnswer()
    {
        if(isCorrectAnswer == true)
        {
            return;
        }
        wrongText.SetActive(true);
        isWrongAnswer = true;
    }

    public void OnButtonPressedBack()
    {
        SceneManager.LoadScene(1);
    }

}
