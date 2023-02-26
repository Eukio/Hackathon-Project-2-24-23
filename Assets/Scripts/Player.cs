
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private bool jump, left, right;
    [SerializeField] float speed;
    Rigidbody2D rb;
    [SerializeField] GameObject playerAttack;
    [SerializeField] public int health { get; set; }
    [SerializeField] GameObject RayObject;

    RaycastHit2D hitWall;
    bool run { get; set; }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        run = true;
        playerAttack.SetActive(false);
    }

    // Us
    void Update()
    {
        if (run)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                jump = true;
            if (Input.GetKeyDown(KeyCode.A))
            {
                  GetComponent<Animator>().SetBool("Run", true);
                left = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                GetComponent<Animator>().SetBool("Run", true);
                right = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
                jump = false;
            if (Input.GetKeyUp(KeyCode.A))
            {
                left = false;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                right = false;

            }
            if(Input.GetMouseButtonDown(0))//&& animation is not Attacking
            {
                StartCoroutine(DelayedAttack());
            }
            //right click attack on for end animation

        }
    }
    private void FixedUpdate()
    {
        hitWall = Physics2D.Raycast(RayObject.transform.position, -Vector2.up);
        Debug.DrawRay(RayObject.transform.position, -Vector2.up * hitWall.distance, Color.red);


        float xChange = 0f +0f+0f;
        float yChange = 0f;
        if(left || right)
        {
            if (!jump)
                GetComponent<Animator>().SetBool("Run", true);
            else
            {
                GetComponent<Animator>().SetBool("Run", false);
            }
        }
        else if (!right && !left)
            {
                GetComponent<Animator>().SetBool("Run", false);
            RayObject.transform.position = new Vector3(transform.position.x+.64f , RayObject.transform.position.y);
          
        }

        if (right)
        {
           
            GetComponent<SpriteRenderer>().flipX = false;
            playerAttack.GetComponent<PolygonCollider2D>().offset= Vector2.right;
            GetComponent<BoxCollider2D>().offset = new Vector2(-1.923342f, 0.5284345f);

            RayObject.transform.position = new Vector3(transform.position.x - 0.76f, RayObject.transform.position.y);
            xChange += speed;

        }
      else  if (left)
        {
         
            GetComponent<SpriteRenderer>().flipX = true;
            playerAttack.GetComponent<PolygonCollider2D>().offset = Vector2.left;
            GetComponent<BoxCollider2D>().offset = new Vector2(1.923342f, 0.5284345f);

            RayObject.transform.position = new Vector3(transform.position.x + 0.76f, RayObject.transform.position.y);


            xChange -= speed;
        }
        
       



        if (jump && hitWall.distance <= 0.02)
        {
            rb.AddForce(Vector3.up * 220);
        }


        if (run == true)
            GetComponent<Transform>().position += new Vector3(xChange * Time.deltaTime, yChange * Time.deltaTime, 0);
    }
    IEnumerator DelayedAttack()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        playerAttack.SetActive(true);
        yield return new WaitForSeconds(.3f);
        GetComponent<Animator>().SetBool("Attack", false);
        playerAttack.SetActive(false);



    }
    public void ResetBattle()
    {
        transform.position = Vector3.zero;
    }
}

