using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sound
{
    public class WordBank : MonoBehaviour
    {
        public int stage = 1;
        public bool _isSpecialWordNow = false;
        public bool _isSpecialWordUsed = false;
        [SerializeField] private Typer time;

        private List<string> originalWords = new List<string>()
        {
            "Hacker", "Spy", "Thief", "Job", "Bob"
        };

        private List<string> specialWords = new List<string>()
        {
            ".-", "-...", "-.-.", "-.."
        };

        private List<string> secondStageWords = new List<string>()
        {
            "second", "stagesecond", "secondstage"
        };

        private List<string> thirdStageWords = new List<string>()
        {
            "third", "stagethird", "thirdstage"
        };

        private List<string> fourthStageWords = new List<string>()
        {
            "fourth", "stagefourth", "fourthstage"
        };

        private List<string> workingWords = new List<string>();

        private void Awake()
        {
            workingWords.AddRange(originalWords);
            Shuffle(workingWords);
            Shuffle(specialWords);
            ConverToLower(workingWords);
        }

        private void Shuffle(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int random = Random.Range(i, list.Count);
                string temporary = list[i];

                list[i] = list[random];
                list[random] = temporary;
            }
        }

        private void ConverToLower(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
                list[i] = list[i].ToLower();
        }

        public string GetWord()
        {

            string newWord = string.Empty;

            if (workingWords.Count != 0)
            {
                if (time.currentNumber <= 15 && _isSpecialWordUsed == false)
                {
                    newWord = specialWords.Last();
                    specialWords.Remove(newWord);
                    _isSpecialWordUsed = true;
                    _isSpecialWordNow = true;
                }
                else
                {
                    _isSpecialWordNow = false;
                    newWord = workingWords.Last();
                    workingWords.Remove(newWord);
                }
            }
            else
            {
                if (stage == 1)
                {
                    workingWords.AddRange(secondStageWords);
                    Shuffle(workingWords);
                    ConverToLower(workingWords);
                    specialWords.AddRange(specialWords);
                    Shuffle(specialWords);
                    _isSpecialWordNow = false;
                    newWord = workingWords.Last();
                    workingWords.Remove(newWord);
                    time.currentNumber = 60;
                    stage++;
                }
                else if (stage == 2)
                {
                    workingWords.AddRange(thirdStageWords);
                    Shuffle(workingWords);
                    ConverToLower(workingWords);
                    specialWords.AddRange(specialWords);
                    Shuffle(specialWords);
                    _isSpecialWordNow = false;
                    newWord = workingWords.Last();
                    workingWords.Remove(newWord);
                    time.currentNumber = 60;
                    stage++;
                    time.currentNumber = 60;
                    stage++;
                }
                else if (stage == 3)
                {
                    workingWords.AddRange(fourthStageWords);
                    Shuffle(workingWords);
                    ConverToLower(workingWords);
                    specialWords.AddRange(specialWords);
                    Shuffle(specialWords);
                    _isSpecialWordNow = false;
                    newWord = workingWords.Last();
                    workingWords.Remove(newWord);
                    time.currentNumber = 60;
                    stage++;
                    time.currentNumber = 60;
                    stage++;
                }
                else
                {
                    workingWords.AddRange(fourthStageWords);
                    Shuffle(workingWords);
                    ConverToLower(workingWords);
                    specialWords.AddRange(specialWords);
                    Shuffle(specialWords);
                    _isSpecialWordNow = false;
                    newWord = workingWords.Last();
                    workingWords.Remove(newWord);
                    time.currentNumber = 60;
                    stage++;
                    time.currentNumber = 60;
                }

            }

            return newWord;
        }
    }
}
