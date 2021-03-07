using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTimer : MonoBehaviour {
    float timer = 20;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        GetComponent<Text> ().text = "Time:" + ((int)timer).ToString ();

        //↓ここから
        //もし変数「timer」が0より小さくなったら
        if (timer < 0) {
            //変数「timer」を0にする
            timer = 0;
        }
        //↑ここまで
    }
}