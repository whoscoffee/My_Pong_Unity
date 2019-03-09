using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLP : MonoBehaviour
{
    public float sensitivity = 5;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p") && transform.position.y < 4)
        {
            transform.position += new Vector3(0, sensitivity * Time.deltaTime);
        }
        if (Input.GetKey("l") && transform.position.y > -4)
        {
            transform.position += new Vector3(0, -sensitivity * Time.deltaTime);
        }
    }
}