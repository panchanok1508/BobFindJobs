using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sound
{
    public class Typer : MonoBehaviour

    {
        private bool clearVar = false;
        private int wordScore = 0;
        public int allWordInStage;
        [SerializeField] private Text allWordInStageText;
        private int wordLeft=-1;
        private int bonusTime = 3; //BonusTime When Type SpecialWord Correct In time
        public int remainingTime; //TimeLeft For TimerBar
        public int currentSpecialTime = 3; //Set SpecialWordTime
        private Dictionary<KeyCode, bool> keys = new Dictionary<KeyCode, bool>();

        public WordBank wordBank = null;
        public Text wordOutput = null; //WordText

        private string remainingWord = string.Empty;

        private string currentWord = string.Empty;

        private Shake shake; //BombAnimationShakeWhenFalse

        private SpyAnimationContoller _spyAnimationContoller;

        public TimerBar timerBar;
        [SerializeField] private Text wordLeftText;
        [SerializeField] private Text timerText;
        [SerializeField] private Text wordScoreText;
        [SerializeField] private Text scoreText;


        [SerializeField] private int startNumber; //Set Default Time
        private float updateTreshold;
        public int currentNumber; //Time to Text
        private bool startCounting;
        public GameObject bomb;
        //public GameObject dropBg;
        public GameObject fakeUI;
        public GameObject spyImage;
        public GameObject spyImage1;
        public GameObject bombPopup;
        public GameObject gameOver;
        public GameObject specialTimeUI;


        private void Awake()
        {
            Debug.Assert(condition: timerText != null, message: "timeText not be null");
            fakeUI.SetActive(false);
            //dropBg.SetActive(false);
            bombPopup.SetActive(false);
            gameOver.SetActive(false);

        }

        private void Start()
        {
            SetCurrentWord();
            bomb.SetActive(true);
            //shake = GameObject.FindGameObjectWithTag("BombShake").GetComponent<Shake>();
            _spyAnimationContoller = GameObject.FindGameObjectWithTag("Spy").GetComponent<SpyAnimationContoller>();
            _spyAnimationContoller.spyMove();

        }

        private void Update()
        {
            SetAllWordInStage(allWordInStage);
            timerBar.SetTime(remainingTime);

            //StartGame
            if (GetKeyDown(KeyCode.Space) && _spyAnimationContoller.spyAnim.GetCurrentAnimatorStateInfo(0).IsName("Move") == false)
            {
                fakeUI.SetActive(true);
                //dropBg.SetActive(true);
                spyImage.SetActive(false);
                spyImage1.SetActive(true);
                bombPopup.SetActive(true);
                shake = GameObject.FindGameObjectWithTag("BombShake").GetComponent<Shake>();
                DisableKey(KeyCode.Space);
                startCounting = true;
                updateTreshold = 0;
                currentNumber = startNumber;
                SetTimerText(currentNumber);
            }
            
            WordScore(wordScore);
            AllScore(wordScore);
            Wordleft(wordLeft);
            CheckInput();


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
            if (wordBank._isSpecialWordNow)
            {
                if (currentSpecialTime <= 3 && currentSpecialTime > 0) 
                {
                    SetTimerText(currentSpecialTime);
                    currentSpecialTime--;
                    Debug.Log(currentSpecialTime);

                }
                else
                {
                    wordBank._isSpecialWordNow = false;
                    Debug.Log("Work Here Already");
                    currentNumber = remainingTime;
                    SetCurrentWord();
                }
            }
            else
            {
               // specialTimeUI.SetActive(false);
               currentNumber--;
                remainingTime = currentNumber;

            }

            if (currentNumber > 0)
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
                Debug.Log($"word score : {wordScore}");
                SetTimerText("END");
                startCounting = false;
                //EnableKey(KeyCode.Space);
                gameOver.SetActive(true);
                SoundEffectManager.instace.Play(SoundEffectManager.SoundName.EndGameEffect);
            }


            if (gameOver.activeInHierarchy == true)
            {
                DisableKey(KeyCode.Space);
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
            wordLeft++;
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

            if (currentNumber > 0 &&
                _spyAnimationContoller.spyAnim.GetCurrentAnimatorStateInfo(0).IsName("Move") == false)



            {
                if (currentNumber > 0 &&
                    _spyAnimationContoller.spyAnim.GetCurrentAnimatorStateInfo(0).IsName("Move") == false)
                {
                    if (Input.anyKeyDown)
                    {
                        string keysPressed = Input.inputString;

                        if (keysPressed.Length == 1)
                            EnterLetter(keysPressed);
                    }
                }


            }
        }

        private void EnterLetter(string typedLetter)
            {
                if (IsCorrectLetter(typedLetter))
                {
                    //TypeCorrect
                    RemoveLetter();
                    SoundEffectManager.instace.Play(SoundEffectManager.SoundName.CurrectEffect);
                    if (IsWordComplete())
                    {
                        if (wordBank._isSpecialWordNow)
                        {
                            remainingTime = remainingTime + bonusTime;
                            currentNumber = remainingTime;
                        }

                        SetCurrentWord();


                        SoundEffectManager.instace.Play(SoundEffectManager.SoundName.CompletEffect);

                    }

                }
                else
                {
                    //TypeFalse
                    SoundEffectManager.instace.Play(SoundEffectManager.SoundName.Warning);
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
                return remainingWord.Length == 0;
            }

            private bool GetKeyDown(KeyCode keyCode)
            {
                if (!keys.ContainsKey(keyCode))
                {
                    keys.Add(keyCode, true);

                }

                return Input.GetKeyDown(keyCode) && keys[keyCode];
            }

            private void DisableKey(KeyCode keyCode)
            {
                if (!keys.ContainsKey(keyCode))
                {
                    keys.Add(keyCode, false);
                }

                else
                {
                    keys[keyCode] = false;
                }

            }

            private void EnableKey(KeyCode keyCode)
            {
                if (!keys.ContainsKey(keyCode))
                {
                    keys.Add(keyCode, true);
                }

                else
                {
                    keys[keyCode] = true;
                }

            }

            private void Wordleft(int wordleft )
            {
                wordLeftText.text = ("Word Left : "+ wordleft.ToString()+" / " + AllWord(allWordInStage));
            }
            
            private void WordScore(int wordScore)
            {
                wordScoreText.text = ("Score : "+ wordScore.ToString());
            }

            private void AllScore(int wordScore)
            {
                scoreText.text = ("Score : "+ wordScore.ToString());

            }

            public void SetAllWordInStage(int allword)
            {
                switch (wordBank.stage)
                {
                    case 1:
                        allWordInStage = 15;
                        wordScore = wordLeft;
                        break;
                    case 2:
                        allWordInStage = 20;
                        if (clearVar==false)
                        {
                            wordLeft = 0;
                            clearVar = true;
                        }
                        wordScore = 15+wordLeft;
                        break;
                    case 3:
                        allWordInStage = 30;
                        if (clearVar==true)
                        {
                            wordLeft = 0;
                            clearVar = false;
                        }
                        wordScore = 35+wordLeft;
                        break;
                    case 4:
                        allWordInStage = 60;
                        if (clearVar==false)
                        {
                            wordLeft = 0;
                            wordScore = 65;
                            clearVar = true;
                        }
                        wordScore = wordLeft+wordScore;
                        break;
                }
                //allWordInStageText.text = allWordInStage.ToString();
                AllWord(allWordInStage);
            }
            
            private int AllWord(int allWordInStage )
            {
                allWordInStageText.text = allWordInStage.ToString();

                return (allWordInStage);
            }
        }
    }
