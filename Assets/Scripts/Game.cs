using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player player;
    bool isPlaying;
    List<Term> termlist = new List<Term>();
    int correctQuestions;
    float finalscore;
    long startTime;
    long elapsed;


    void Start()
    {
        elapsed = 0;
        startTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            elapsed = (DateTime.Now.Ticks - startTime) / 10000;
        }
    }
    public void RestartTime()
    {
        startTime = DateTime.Now.Ticks;
        elapsed = 0;
    }
    public void ReadInput(string s)
    { //seperate this 
        string question = "";
        question = s;
        string answer = "";
        answer = s;
    }
}
