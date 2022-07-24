using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Handler : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject menu;

    [Header("Component in main menu")]
    [SerializeField] InputField inputDigitA;
    [SerializeField] InputField inputDigitB;
    [SerializeField] InputField inputTotalQuestion;

    [Header("QnA")]
    [SerializeField] Text soal;
    [SerializeField] InputField jawaban;

    [Header("Information after game over")]
    [SerializeField] GameObject gameOver; // game over panel
    [SerializeField] Text correct;
    [SerializeField] Text wrong;
    [SerializeField] Text timeInfo;


    int totalQuestions;
    int correctAnswer;

    int a, b, x = 0;
    int digitA, digitB;
    string operation;
    int time;

    private void Awake()
    {
        main.SetActive(false);
        menu.SetActive(true);
        gameOver.SetActive(false);
    }

    public void Play()
    {
        MakeQuestion();
        StartCoroutine(Timer());
    }

    public void Correction()
    {
        if (int.Parse(jawaban.text) == x)
        {
            correctAnswer++;
            jawaban.text = "";
        }

        MakeQuestion();
    }

    public void MakeQuestion()
    {
        if (totalQuestions > 1)
        {

            a = Random.Range(0, Pow(10, digitA));
            b = Random.Range(0, Pow(10, digitB));

            switch (operation)
            {
                case " + ":
                    x = a + b;
                    break;
                case " - ":
                    x = a - b;
                    break;
                case " x ":
                    x = a * b;
                    break;
            }

            soal.text = a.ToString() + operation + b.ToString();
            totalQuestions -= 1;
        }
        else
        {
            GameOver();
        }
    }

    public void ChangeOperation(string _operation)
    {
        operation = _operation;
    }

    public void ChangeDigits()
    {
        digitA = inputDigitA.text == string.Empty ? 1 : int.Parse(inputDigitA.text);
        digitB = inputDigitB.text == string.Empty ? 1 : int.Parse(inputDigitB.text);
    }

    public void ChangeTotalQuestion()
    {
        totalQuestions = inputTotalQuestion.text == "" ? 10 : int.Parse(inputTotalQuestion.text);
    }   

    void GameOver()
    {
        gameOver.SetActive(true);
        correct.text ="Correct Answer : " + correctAnswer.ToString();
        wrong.text = "Incorrect Answer : " + (totalQuestions - correctAnswer).ToString();
        timeInfo.text = "Time : " + time.ToString() + "s";
    }

    IEnumerator Timer()
    {
        if (!gameOver.activeInHierarchy)
        {
            yield return new WaitForSecondsRealtime(1f);

            time++;
            StartCoroutine(Timer());
        }
    }

    int Pow(int a, int n) 
    {
        for (int i = 1; i < n; i++)
        {
            a *= 10; 
        }

        return a;
    }
}
