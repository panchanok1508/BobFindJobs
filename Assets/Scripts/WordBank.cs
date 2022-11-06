using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WordBank : MonoBehaviour
{
    public bool _isSpecialWordNow=false;
    public bool _isSpecialWordUsed=false;
    [SerializeField] private Typer time;
    private List<string> originalWords = new List<string>()
    {
        "Hacker","Spy","Thief", "Job", "Bob"
    };

    private List<string> specialWords = new List<string>()
    {
        ".-","-...","-.-.","-.."
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

        if (workingWords.Count!=0)
        {
            if (time.currentNumber<=5 && _isSpecialWordUsed==false)
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
        return newWord;
    }
}
