using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player player;
    bool isBattling;
    bool isAnswering;
    bool runTimer;
    bool showQuestion;

    List<Term> termlist = new List<Term>();
    List<Term> displayList = new List<Term>();
    List<Enemy> enemies = new List<Enemy>();

    //[SerializeField] Text question;

    [SerializeField] Camera camera;

    //[SerializeField] GameObject buttonA;
    //[SerializeField] GameObject buttonB;
    //[SerializeField] GameObject buttonC;
    //[SerializeField] GameObject buttonD;

    Term actualAnswer;
    string answerAText;
    string answerBText;
    string answerCText;
    string answerDText;
    string questionText;


    int numberOfEnemies;
    float finalscore;
    long startTime;
    long elapsed;

    int correctQuestions;
    Scene activeScene;

    void Start()
    {
        DontDestroyOnLoad(this);
     //   SceneManager.LoadScene("Title");
        elapsed = 0;
        startTime = 0;
        answerAText = "";
        answerBText = "";
        answerCText = "";
        answerDText = "";
        questionText = "";
        runTimer = false;

    }

    // Update is called once per frame
    void Update()
    {
        activeScene = SceneManager.GetActiveScene();

        if (player.health == 0)
        {
            isAnswering = false;
            isBattling = false;
            //scene switched, you lose!!!
        }
        
        if(activeScene.Equals("Title"))
        {
            button = GameObject.Find("Play").GetComponent<Button>();
            if (button.isPressed)
                InputState();
        }
        
        if (isAnswering)
        { //timer Answer Question
            if (elapsed <= 20000 && showQuestion)
            { // 20 Seconds?
                showQuestion = false;
                RandomizeQuestion();
                displayList.Clear();
             /*   buttonA.GetComponentInChildren<Text>().text = answerAText;
                buttonB.GetComponentInChildren<Text>().text = answerBText;
                buttonC.GetComponentInChildren<Text>().text = answerCText;
                buttonD.GetComponentInChildren<Text>().text = answerDText;
             */
            }
            else
            {
                runTimer = false;
                elapsed = 0;
                isBattling = true;
                StartCoroutine(DelayedTransition());
            }
        }
        if (runTimer)
        {
            elapsed = (DateTime.Now.Ticks - startTime) / 10000;
        }
        if (isBattling)
        {

            if (GameObject.FindGameObjectsWithTag("Enemy").Length < 2) // #Slimes <2 SWITCH TO ANSWERING PHASE
            {
                isBattling = false;
                isAnswering = true;
            }
            //show health and stats

        }

    }


    public void RandomizeQuestion()
    {
        List<Term> tempList = termlist;

        for (int i = 0; i < 3; i++)
        { //select 4 random answers
            int randomIndex = UnityEngine.Random.Range(0, termlist.Count);
            displayList.Add(termlist[randomIndex]);
            tempList.Remove(termlist[randomIndex]);
        }
        actualAnswer = displayList[UnityEngine.Random.Range(0, 4)];
        questionText = actualAnswer.question;
        answerAText = displayList[0].answer;
        answerBText = displayList[1].answer;
        answerCText = displayList[2].answer;
        answerDText = displayList[3].answer;
        //randomize the placement of questions


    }
    public void Clicked() 
    {
        Text buttonText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>();
        if (buttonText.Equals(actualAnswer.ToString()))
        {
            showQuestion = true;
        }
        else
        {
            EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().color = Color.red;
        }

    }
    public void BattleState() //Next Button Hit
    {
        SceneManager.LoadScene("Battle");

        isAnswering = true;
        runTimer = true;
        startTime = DateTime.Now.Ticks;
        showQuestion = true;
    }
    public void InputState() //PLAY Button Hit
    {
        isAnswering = true;
        runTimer = true;
        startTime = DateTime.Now.Ticks;
        showQuestion = true;
    }
    public void StartBattle() //EXECUTES ONCE
    {
        numberOfEnemies += 3;
        for (int i = 0; i < numberOfEnemies; i++) //EnemySpawn
        {
            Vector2 randomPosition = Vector2.zero;
            Enemy e = new Enemy();
            int randomSideSpawn = (int)UnityEngine.Random.Range(0, 2);
            if (randomSideSpawn == 0) //LEFT SPAWN
            {
                randomPosition = new Vector2(UnityEngine.Random.Range(-5, -3), UnityEngine.Random.Range(0, 5)); // CHANGE THIS

            }
            else if (randomSideSpawn == 1) //RIGHT SPAWN
            {
                randomPosition = new Vector2(UnityEngine.Random.Range(3, 5), UnityEngine.Random.Range(0, 5)); // CHANGE THIS

            }

            Instantiate(e);
            e.transform.position = randomPosition;
        }
    }
    IEnumerator DelayedTransition()
    {
        //CAMERA MOVES UP
        isAnswering = false;
        yield return new WaitForSeconds(2f);
        isBattling = true;

    }
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Game").Length > 1)
            Destroy(GameObject.FindGameObjectsWithTag("Game")[1]);

    }
}
