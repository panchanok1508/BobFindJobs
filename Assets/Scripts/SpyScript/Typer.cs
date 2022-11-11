using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    private int bonusTime = 3; //BonusTime When Type SpecialWord Correct In time
    [SerializeField] private int remainingTime; //TimeLeft For TimerBar
    private int currentSpecialTime=3; //Set SpecialWordTime
    private Dictionary<KeyCode, bool> keys = new Dictionary<KeyCode, bool>();
    
    public WordBank wordBank = null;
    public Text wordOutput = null; //WordText

    private string remainingWord = string.Empty;

    private string currentWord = string.Empty; 

    private Shake shake; //BombAnimationShakeWhenFalse

    private SpyAnimationContoller _spyAnimationContoller;

    public TimerBar timerBar;
    
    [SerializeField] private Text timerText;
    [SerializeField] private int startNumber; //Set Default Time
    private float updateTreshold;
    public int currentNumber; //Time to Text
    private bool startCounting;
    public GameObject bomb;
    public GameObject dropBg;
    public GameObject fakeUI;
    public GameObject spyImage;
    public GameObject spyImage1;

    
    private void Awake()
    {
        Debug.Assert(condition:timerText!=null,message:"timeText not be null");
        fakeUI.SetActive(false);
        dropBg.SetActive(false);
    }
    
    private void Start()
    {
       
        SetCurrentWord();

        timerBar.SetMaxTime(startNumber);

        bomb.SetActive(true);
        shake = GameObject.FindGameObjectWithTag("BombShake").GetComponent<Shake>();
        _spyAnimationContoller = GameObject.FindGameObjectWithTag("Spy").GetComponent<SpyAnimationContoller>();
        _spyAnimationContoller.spyMove();
        


    }



    private void Update()
    {

        timerBar.SetTime(remainingTime);
        
        //StartGame
        if (GetKeyDown(KeyCode.Space)&&_spyAnimationContoller.spyAnim.GetCurrentAnimatorStateInfo(0).IsName("Move")==false)
        {
            fakeUI.SetActive(true);
            dropBg.SetActive(true);
            spyImage.SetActive(false);
            spyImage1.SetActive(true);
            DisableKey(KeyCode.Space);
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
            if (wordBank._isSpecialWordNow)
            {
                if (currentSpecialTime<=3 && currentSpecialTime>0)
                {
                    SetTimerText(currentSpecialTime);
                    currentSpecialTime--;
                    
                }
                else
                {
                    wordBank._isSpecialWordNow = false;
                    currentNumber = remainingTime;
                }
            }
            else
            {
                currentNumber--;
                remainingTime = currentNumber;
                
            }
            
            if (currentNumber>0)
            {
                if (wordBank._isSpecialWordNow)
                {
                    DisableKey(KeyCode.Space);
                }
                else
                {
                    SetTimerText(currentNumber);
                    DisableKey(KeyCode.Space);
                }
                
                
            }
            else
            {
                
                SetTimerText("END");
                startCounting = false;
                EnableKey(KeyCode.Space);
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
        if (currentNumber>0 &&_spyAnimationContoller.spyAnim.GetCurrentAnimatorStateInfo(0).IsName("Move")==false)
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
            //TypeCorrect
            RemoveLetter();
            if (IsWordComplete())
            {
                if (wordBank._isSpecialWordNow)
                {
                    remainingTime = remainingTime + bonusTime;
                    currentNumber = remainingTime;
                }
                SetCurrentWord();
            }
            
        }
        else
        {
            //TypeFalse
            shake.BombShake();
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
