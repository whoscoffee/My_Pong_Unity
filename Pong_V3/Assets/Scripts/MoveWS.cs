using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWS : MonoBehaviour {
    public float sensitivity = 5;

	void Update () {
		if (Input.GetKey("w") && transform.position.y < 4)
        {
            transform.position += new Vector3(0, sensitivity * Time.deltaTime);
        }
        if (Input.GetKey("s") && transform.position.y > -4 )
        {
            transform.position += new Vector3(0, -sensitivity * Time.deltaTime);
        }
    }
}
