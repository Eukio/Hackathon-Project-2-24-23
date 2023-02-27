using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthBar;
    public int health;
    [SerializeField] string tag;

    void Start()
    {
        if (tag.Equals("Player"))
            health = GameObject.FindGameObjectsWithTag(tag)[0].GetComponent<Player>().health;
        else if (tag.Equals("Enemy"))
        {
            health = GameObject.FindGameObjectsWithTag(tag)[0].GetComponent<Enemy>().health;

        }
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}