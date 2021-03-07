using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onigokko2 : MonoBehaviour
{
    private float TimeLimit;

    // Start is called before the first frame update
    void Start()
    {
        TimeLimit = 180;
    }

    // Update is called once per frame
    void Update()
    {
        TimeLimit -= Time.deltaTime;

        if (TimeLimit <= 0)
        {
            SceneManager.LoadScene("1P WIN");
        }
    }
}
