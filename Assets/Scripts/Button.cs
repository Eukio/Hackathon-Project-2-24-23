

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public bool isPressed { get;  set; }
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
 
    public void HowToButtonPage()
    {
        GameObject page = GameObject.Find("HowToPage");
        page.SetActive(false);
    }
    public void OnExitButtonClicked()
    {
        GameObject postit = GameObject.Find("postit");
        postit.SetActive(false);
    }
    public void OnAddButtonClicked()
    {
        isPressed = true;
    }

    public void OnClearButtonClicked()
    {
        isPressed = true;
    }

    public void OnClicked()
    {
        isPressed = true;
        SceneManager.LoadScene("Battle");

    }
    // Update is called once per frame
    void Update()
    {

    }
    
}
