
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Term : MonoBehaviour
{
    // Start is called before the first frame update
    public string question { get; set; }
    public string answer;
    private void Start()
    {
        question = "";
        answer = "";

    }
    public void SetQuestion(string question)
    {
        this.question = question;
    }
    public void SetAns(string answer)
    {
        this.answer = answer;
    }
}
