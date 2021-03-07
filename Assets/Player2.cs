using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField]
    private float JumpPower = 800;
    [SerializeField]
    private float MoveSpeed = 25
        ;

    Animator anim;// Animatorの機能を使うための変数

    private bool Grounded;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();// animにAnimatorの値を代入する
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.TransformDirection(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.TransformDirection(Vector3.back * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -2, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 2, 0));
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))// もし、WまたはSキーがおされたら、
        {
            anim.SetBool("isRunning", true);// アニメーターのisRunningをtrueにする
        }

        else// そうでなければ
        {
            anim.SetBool("isRunning", false);// アニメーターのisRunningをfalseにする
        }

        if (Input.GetKey(KeyCode.Slash))
        {
            anim.SetBool("isjanp", true);
            MoveSpeed = 1;
        }

        else
        {
            anim.SetBool("isjanp", false);
            MoveSpeed = 3;
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (Grounded == true)
            {
                rb.AddForce(Vector3.up * JumpPower);
            }
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            //transform.GetComponent(new Vector3(Player));
            //transform.position = Player.position {get;internal set;}
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = true;// Groundedをtrueにする
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = false;
        }
    } }