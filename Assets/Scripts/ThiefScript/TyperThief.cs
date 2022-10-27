using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TyperThief : MonoBehaviour
{
    private Dictionary<KeyCode, bool> keys = new Dictionary<KeyCode, bool>();
    //typer
    public WordBank wordBank = null;
    public Text wordOutput = null;

    private string remainingWord = string.Empty;

    private string currentWord = string.Empty;

    private LockpickAnimationController _lockpickAnimationController;

    public TimerBar timerBar;
    


    //typer
    
    //timer
    [SerializeField] private Text timerText;
    [SerializeField] private int startNumber = 10;
    private float updateTreshold;
    private int currentNumber;
    private bool startCounting;
    public GameObject lockpick;

    private bool isGameover=false;
    //timer

    //timer
    private void Awake()
    {
        Debug.Assert(condition:timerText!=null,message:"timeText not be null");
    }
    //timer
    private void Start()
    {
       
        SetCurrentWord();
        //timer
        startCounting = false;
        updateTreshold = 0;
        currentNumber = startNumber;
        SetTimerText(currentNumber);
        //timer
        timerBar.SetMaxTime(startNumber);

    }



    private void Update()
    {


        timerBar.SetTime(currentNumber);
        if (isGameover==false)
        {


            //timer
            if (GetKeyDown(KeyCode.Space))
            {
                //_lockpickAnimationController.SetActive(true);
                _lockpickAnimationController = GameObject.FindGameObjectWithTag("Lockpick").GetComponent<LockpickAnimationController>();
                startCounting = true;
                updateTreshold = 0;
                currentNumber = startNumber;
                SetTimerText(currentNumber);
            
            }
        
            CheckInput();
        
            if (!startCounting)
            {
                return;
            }

            updateTreshold += Time.deltaTime;
            if (updateTreshold<1)
            {
                return;
            }
            updateTreshold = 0;
            currentNumber--;
            if (currentNumber>0)
            {
                SetTimerText(currentNumber);
                DisableKey(KeyCode.Space);
            }
            else
            {
                SetTimerText("END");
                startCounting = false;
                EnableKey(KeyCode.Space);
            }
        }
        else
        {
            
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
    //timer

    //typer
    private void SetCurrentWord()
    {
        currentWord = wordBank.GetWord();
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }
    private void CheckInput()
    {
        if (currentNumber>0 && currentNumber!=startNumber)
        {
            if (Input.anyKeyDown)
            {
                string keysPressed = Input.inputString;
            
                if(keysPressed.Length==1)
                    EnterLetter(keysPressed);
            }
        }

    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();
            if (IsWordComplete())
            SetCurrentWord();
            _lockpickAnimationController.lockpickMove();
        }
        else
        {
            Debug.Log("false");
            _lockpickAnimationController.lockpickBroke();

        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);

    }

    private bool IsWordComplete()
    {
        return remainingWord.Length==0;
    }
    //typer
    private bool GetKeyDown(KeyCode keyCode)
    {
        if (!keys.ContainsKey(keyCode))
        {
            keys.Add( keyCode, true );
            
        }
        
        return Input.GetKeyDown(keyCode) && keys[keyCode];
    }
    
    private void DisableKey( KeyCode keyCode )
    {
        if( !keys.ContainsKey( keyCode ))
        {
            keys.Add( keyCode, false );
        }
        
        else
        {
            keys[keyCode] = false;
        }
        
    }
    
    private void EnableKey( KeyCode keyCode )
    {
        if (!keys.ContainsKey(keyCode))
        {
            keys.Add( keyCode, true );
        }

        else
        {
            keys[keyCode] = true;
        }
        
    }
}
