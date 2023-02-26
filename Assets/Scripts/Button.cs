using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }
    public void OnPlayButtonClicked()
    {
        isPressed = true;
        SceneManager.LoadScene("InputTerms");
    }

    public void OnExitButtonClicked()
    {
        GameObject postit = GameObject.Find("postit");
        postit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
