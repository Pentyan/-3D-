using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    private Vector3 initialPosition;

    [SerializeField]
    private int movex = 0;

    [SerializeField]
    private int movey = 0;

    [SerializeField]
    private int movez = 0;

    [SerializeField]
    private int movespeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time * movespeed) * movex + initialPosition.x, Mathf.Sin(Time.time * movespeed) * movey + initialPosition.y, Mathf.Sin(Time.time * movespeed) * movez + +initialPosition.z);
    }
}
