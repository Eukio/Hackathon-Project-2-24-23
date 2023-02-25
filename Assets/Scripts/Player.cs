<<<<<<< Updated upstream
using System;
=======
>>>>>>> Stashed changes
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
    [SerializeField] float speed; Rigidbody2D rb;
    [SerializeField] GameObject RayObject;
    RaycastHit2D hitWall;
    bool run;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        run = true;
    }

    // U
    void Update()
    {
        if (run)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                jump = true;
            if (Input.GetKeyDown(KeyCode.A))
            {
                //  GetComponent<Animator>().SetBool("running", true);
                left = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                // GetComponent<Animator>().SetBool("running", true);
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


        }
    }
    private void FixedUpdate()
    {
        hitWall = Physics2D.Raycast(RayObject.transform.position, -Vector2.up);
        Debug.DrawRay(RayObject.transform.position, -Vector2.up * hitWall.distance, Color.red);


        float xChange = 0f +0f+0f;
        float yChange = 0f;
        if (right)
        xChange += speed;
        if(left)
        xChange -= speed;



        if (jump && hitWall.distance <= 0.02)
        {
            rb.AddForce(Vector3.up * 220);
        }


        if (run == true)
            GetComponent<Transform>().position += new Vector3(xChange * Time.deltaTime, yChange * Time.deltaTime, 0);
    }
}
<<<<<<< Updated upstream
/*asldfjlasdfljads
 * asdfasdf
 * dfasdfadsfad
 * asdfasdf
 * DOES THIS WORK????
 * asdfladkfjlkasdfasdfadsfadfasdfadsfewfqwef*/
=======
>>>>>>> Stashed changes
