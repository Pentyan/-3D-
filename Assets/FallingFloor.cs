using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool Falling;
    private int FallingSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Falling == true)
        {
            Debug.Log("otiru");
            transform.position -= new Vector3(0, FallingSpeed * Time.deltaTime, 0);
        }

        if (transform.position.y <= -10)
        {
            transform.position = initialPosition;
            Falling = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.tag == "Player2")
        {
            Falling = true;
        }
    }
}
