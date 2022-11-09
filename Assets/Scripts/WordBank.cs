using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WordBank : MonoBehaviour
{
    public int stage = 1;
    public bool _isSpecialWordNow=false;
    public bool _isSpecialWordUsed=false;
    [SerializeField] private Typer time;
    private List<string> originalWords = new List<string>()
    {
        "Suspect" ,"Clue" ,"Alibi"   ,"Murder"  ,"Killer","Secret","Police" ,"Plan"  ,"Bullet"
        ,"Clash" , "Assets" ,"Trace"  ,"Stalk"  ,"Mask" ,"Wire" 
    };

    private List<string> specialWords = new List<string>()
    {
        ".-","-...","-.-.","-.."
    };

    private List<string> secondStageWords = new List<string>()
    {
        "Suspect" ,"Clue" ,"Alibi"   ,"Murder"  ,"Killer","Secret","Police" ,"Plan"  ,"Bullet" 
        ,"Clash" , "Assets" ,"Trace"  ,"Stalk"  ,"Mask" ,"Wire" ,"Sneak" ,"Death"  ,"Hidden","Felony" ,"Mission"
    };
    private List<string> thirdStageWords = new List<string>()
    {
         "Victim" ,"Suspect"  ,"Witness" ,"Culprit" ,"Clue" ,"Alibi" ,"Murder" ,"Killer"  
        ,"Secret","Police" ,"Suspect" ,"Plan"  ,"Bullet" ,"Hiding","Clash" , "Assets" ,"Dispute" 
        ,"Trace" ,"Witness" ,"Stalk"  ,"Lawsuit" ,"Mask" ,"Wire" ,"Sneak" ,"Death"  ,"Culprit"  
        ,"Trigger" ,"Hidden","Felony" ,"Mission" 
    };
    private List<string> fourthStageWords = new List<string>()
    {
         "Investigation", "Victim" ,"Criminal" ,"Suspect" ,"Accomplice" ,"Witness" ,"Culprit"
        ,"Clue" ,"Evidence" ,"Alibi" ,"Detective" ,"Suicide" ,"Murder" ,"Slaughter" ,"Perpetrator"
        ,"Killer" ,"Criminology" ,"Secret" ,"Conspirator" ,"Police" ,"Suspect" ,"Accusation"
        ,"Villain" ,"Plan" ,"Gunpoint" ,"Disguise" ,"Bullet" ,"Suspicious" ,"Hideaway" ,"Hiding"
        ,"Equipment" ,"Clash" ,"Threatening", "Assets" ,"Investigator" ,"Dispute" ,"Trace" ,"Sentence"
        ,"Assault" ,"Witness" ,"Stalk" ,"Condolence" ,"Prosecute" ,"Disguise" ,"Lawsuit" ,"Fingerprint"
        ,"Mask" ,"Wire" ,"Sneak" ,"Death" ,"Motivation" ,"Culprit" ,"Collusion" ,"Trigger" ,"Hidden"
        ,"Remuneration" ,"Felony" ,"Mission" ,"Disguise" ,"Fratricide"
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
            if (time.currentNumber<=15 && _isSpecialWordUsed==false)
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
            if (stage==1)
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
            else if (stage==2)
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
            else if (stage==3)
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
