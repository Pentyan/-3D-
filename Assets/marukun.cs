using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marukun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         Rigidbody rb = this.GetComponent<Rigidbody> ();
        //  Vector3 force = new Vector3(transform.rotation.eulerAngles.x, 0.0f, transform.rotation.eulerAngles.z);
        Vector3 force = new Vector3 (0,0,0);
         rb.AddForce (force);
    }
}
