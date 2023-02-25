using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int attack;
    public Vector2 move;
    public GameObject player;

    [SerializeField] float distance = .5f;
    [SerializeField] float speed;

    private Transform target;
    private Animator animator;
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
        player = GameObject.Find("Player");
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //flip enemy to face towards player
        spriteRenderer.flipX = !(target.position.x < transform.position.x);
        Debug.Log(target.position);
        //move towards enemy
        if (Vector2.Distance(GetComponent<Transform>().position, target.position) < distance)
        {
            Debug.Log("move");
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, 0), speed * Time.deltaTime);
            //animator.SetBool("IsRunning", true);
        }
        else
        {
            if (Vector2.Distance(transform.position, GetComponent<Transform>().position) <= 0)
            {
                //animator.SetBool("IsRunning", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
