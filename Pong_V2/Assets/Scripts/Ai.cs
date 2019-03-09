using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour {
    public GameObject ball;
    public float sensitivity = 5;
    void Update () {
        //go up
        while (ball.transform.position.y > transform.position.y - transform.localScale.y / 4 && transform.position.y < 4)
        {
            transform.position += new Vector3(0, sensitivity * Time.deltaTime);
        }
        //go down
        while (ball.transform.position.y < transform.position.y + transform.localScale.y / 4 && transform.position.y > -4)
        {
            transform.position += new Vector3(0, -sensitivity * Time.deltaTime);
        }
    }
}
