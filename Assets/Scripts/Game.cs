using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

   public  List<Term> termlist = new List<Term>();
    public List<Term> displayList = new List<Term>();
    List<Enemy> enemies = new List<Enemy>();

    //[SerializeField] Text question;

    [SerializeField] GameObject camera;

    public  GameObject buttonA;
    public GameObject buttonB;
    public GameObject buttonC;
    public GameObject buttonD;

    Term actualAnswer;
    string answerAText;
    string answerBText;
    string answerCText;
    string answerDText;
    string questionText;
    Button button;

    int numberOfEnemies;
    float finalscore;
    long startTime;
    long elapsed;

    int correctQuestions;
    Scene activeScene;
    Text list;

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
        list = GameObject.Find("List").GetComponent<Text>();
        runTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        activeScene = SceneManager.GetActiveScene();
        if (activeScene.name.Equals("Battle"))
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            camera = GameObject.Find("Main Camera"); 
            camera = GameObject.FindWithTag("MainCamera");


            CheckButtons();
           /*
            *  if (player.health == 0)
            {
                isAnswering = false;
                isBattling = false;
                //scene switched, you lose!!!
            }*/

           
        }

        if(activeScene.Equals("Title"))
        {
            button = GameObject.Find("Play").GetComponent<Button>();
            if (button.isPressed)
                InputState();
        }

        if (isAnswering)
        { //timer Answer Question
            runTimer = true;
           // camera.GetComponent<CameraFollow>().enabled = false;
          //  camera.transform.position = new Vector3(0f, -25.6900005f, -10f);
            if (elapsed <= 20000 && showQuestion)
            { // 20 Seconds?
                showQuestion = false;
              //  RandomizeQuestion();
                buttonA.GetComponentInChildren<Text>().text = answerAText;
                buttonB.GetComponentInChildren<Text>().text = answerBText;
                buttonC.GetComponentInChildren<Text>().text = answerCText;
                buttonD.GetComponentInChildren<Text>().text = answerDText;
                displayList.Clear();

            }
            else if(elapsed >= 20000)
            {
                Debug.Log("DOne");
                runTimer = false;
                elapsed = 0;
                isAnswering= false;
                isBattling = true;
            }
        }
        if (runTimer)
        {
            elapsed = (DateTime.Now.Ticks - startTime) / 10000;
        }
        if (isBattling && !isAnswering)
        {
            //camera.GetComponent<CameraFollow>().enabled = true;

           // camera.transform.position = new Vector3(0, 0, -10);

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
        for (int i = 0; i < 4; i++)
        { //select 4 random answers
            int randomIndex = UnityEngine.Random.Range(0, tempList.Count);
           displayList.Add(termlist[randomIndex]);
           tempList.Remove(termlist[randomIndex]);
            Debug.Log(termlist[i].answer);
        }
        // actualAnswer = displayList[UnityEngine.Random.Range(0, 4)];

        //questionText = actualAnswer.question;
      
        answerAText = displayList[0].answer;
        answerBText = displayList[1].answer;
        answerCText = displayList[2].answer;
        answerDText = displayList[3].answer;
        //randomize the placement of questions


    }

    
    public void InputTerm()
    {
        String q = GameObject.Find("QuestionInput").GetComponent<InputField>().text;
        String a = GameObject.Find("AnswerInput").GetComponent<InputField>().text;
        if (q != "" && a != "")
        {
            Term t = new Term();

            t.SetQuestion(q);
            t.SetAns(a);
            termlist.Add(t);
            // Debug.Log(termlist[0].question);

            list.text += "Q: " + q + " A: " + a + "\n";
        }
        Debug.Log(termlist.Count);

    }
    public void ClearList()
    {
        termlist.Clear();
        list.text = "";
    }
    public void CheckButtons()
    {
        buttonA = GameObject.Find("ButtonA");
        buttonB = GameObject.Find("ButtonB");
        buttonC = GameObject.Find("ButtonC");
        buttonD = GameObject.Find("ButtonD");
        if (buttonA.GetComponent<Button>().isPressed)
        {
            buttonA.GetComponent<Button>().isPressed = false;

            if (buttonA.GetComponentInChildren<Text>().text.Equals("4"))
            {
                showQuestion = true;
                correctQuestions++;
            }
            else
            {
                buttonA.GetComponentInChildren<Text>().color = Color.red;
            }

        }
        if (buttonB.GetComponent<Button>().isPressed)
        {
            buttonB.GetComponent<Button>().isPressed = false;

            if (buttonB.GetComponentInChildren<Text>().text.Equals("4"))
            {
                showQuestion = true;
                correctQuestions++;
            }
            else
            {
                buttonB.GetComponentInChildren<Text>().color = Color.red;
            }
        }
        if (buttonC.GetComponent<Button>().isPressed)
        {
            buttonC.GetComponent<Button>().isPressed = false;

            if (buttonC.GetComponentInChildren<Text>().text.Equals("4"))
            {
                showQuestion = true;
                correctQuestions++;
            }
            else
            {
                buttonC.GetComponentInChildren<Text>().color = Color.red;
            }
        }
        if (buttonD.GetComponent<Button>().isPressed)
        {
            buttonD.GetComponent<Button>().isPressed = false;

            if (buttonD.GetComponentInChildren<Text>().text.Equals("4"))
            {
                showQuestion = true;
                correctQuestions++;
                SceneManager.LoadScene("Battle");

            }
            else
            {
                buttonD.GetComponentInChildren<Text>().color = Color.red;
            }
        }
    }
    public void Continue()
    {
        SceneManager.LoadScene("Battle");
        Debug.Log("Here");
        isBattling= false;
        isAnswering = true;
        runTimer = true;
        startTime = DateTime.Now.Ticks;
        showQuestion = true;
      





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
    
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Game").Length > 1)
            Destroy(GameObject.FindGameObjectsWithTag("Game")[1]);

    }
   
}