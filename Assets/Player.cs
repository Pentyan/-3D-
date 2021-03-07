using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]// SerializeFieldと書くとその次の変数がエディタ上で数値を調整可能になる
    private float JumpPower = 400;// ジャンプ力

    [SerializeField]
    private float MoveSpeed = 10;// 移動スピード

    private bool Grounded;// 地面についているか判定する変数

    private Rigidbody rb;// Rigidbodyを扱うための変数

    public float sensitivityX = 15F;//マウスの横の動きの強さ
    public float sensitivityY = 15F;//マウスの縦の動きの強さ

    public float minimumX = -360F;//横の回転の最低値
    public float maximumX = 360F;//横の回転の最大値

    public float minimumY = -60F;//縦の回転の最低値
    public float maximumY = 60F;//縦の回転の最大値

    float rotationX = 0f;
    float rotationY = 0f;

    Animator anim;
    public GameObject VerRot;//縦回転させるオブジェクト（カメラ）
    public GameObject HorRot;//横回転させるオブジェクト（プレイヤー）

    public static Vector3 position { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();// Rigidbodyの値を取得してrbに代入する
        anim = GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))// もし、Wキーがおされたら、
        {
            transform.position += transform.TransformDirection(Vector3.forward * MoveSpeed * Time.deltaTime);// 前方に進む
        }

        if (Input.GetKey(KeyCode.S))// もし、Sキーがおされたら、
        {
            transform.position += transform.TransformDirection(Vector3.back * MoveSpeed * Time.deltaTime);// 後方に進む
        }

        if (Input.GetKey(KeyCode.A))// もし、Aキーがおされたら、
        {
            transform.position += transform.TransformDirection(Vector3.left * MoveSpeed * Time.deltaTime);// 左に進む
        }

        if (Input.GetKey(KeyCode.D))// もし、Dキーがおされたら、
        {
            transform.position += transform.TransformDirection(Vector3.right * MoveSpeed * Time.deltaTime);// 右に進む
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }


        if (Grounded == true)//  もし、Groundedがtrueなら、
        {
            if (Input.GetKeyDown(KeyCode.Space))//  もし、スペースキーがおされたなら、  
            {
                Grounded = false;//  Groundedをfalseにする
                rb.AddForce(Vector3.up * JumpPower);//  上にJumpPower分力をかける
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isjanp", true);
            MoveSpeed = 1;
        }

        else
        {
            anim.SetBool("isjanp", false);
            MoveSpeed = 3;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //anim.SetBool("isdown", true);
            //MoveSpeed = 1;
        }
        else
        {
            anim.SetBool("isdown", false);
            MoveSpeed = 3;
        }

        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;//rotationXを現在のyの向きにXの移動量*sensitivityXの分だけ回転させる

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;//rotationYにYの移動量*sensitivityYの分だけ増やす
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);//rotationYを-60〜60の値にする

        VerRot.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);//オブジェクトの向きをnew Vector3(-rotationY, rotationX, 0)にする
        HorRot.transform.localEulerAngles = new Vector3(0, rotationX, 0);//オブジェクトの向きをnew Vector3(-rotationY, rotationX, 0)にする

        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
        if (collision.gameObject.tag == "MoveFloor")
        {
            Grounded = true;
            transform.SetParent(collision.transform);
        }
        if (collision.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            Grounded = true;//  Groundedをtrueにする
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = false;
        }

        if (collision.gameObject.tag == "MoveFloor")
        {
            Grounded = false;
            transform.SetParent(null);
        }
    }
}