using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialCountdownTimer : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private int startNumber = 3;
    private float updateTreshold;
    private int currentNumber;
    private bool startCounting;

    private void Awake()
    {
        Debug.Assert(condition:timerText!=null,message:"timerText not be null");
    }
    void Start()
    {
        startCounting = false;
        updateTreshold = 0;
        currentNumber = startNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCounting)
        {
            updateTreshold = 0;
            currentNumber = startNumber;
            SetTimerText(currentNumber);
        }

        if (!startCounting)
        {
            return;
        }

        updateTreshold += Time.deltaTime;
        if (updateTreshold < 1)
        {
            return;
        }

        updateTreshold = 0;
        currentNumber--;
        if (currentNumber >= 0)
        {
            SetTimerText(currentNumber);
        }
        else
        {
            SetTimerText("END");
            startCounting = false;
        }
    }

    void SetTimerText(int number)
        {
            timerText.text = number.ToString();
        }

    void SetTimerText(string text)
        {
            timerText.text = text;
        }

    public void SetStartCounting()
        {
            startCounting = true;
        }
    }

