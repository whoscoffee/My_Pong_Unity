using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bounce : MonoBehaviour {
    public float Speed = 10;
    public Rigidbody2D rigidbody2D;
    public Text goals_One;
    int oneCount = 0, twoCount = 0;
    public Text goals_Two;
    float pos;
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.name == "player_One")
        {
            //pos = a negitive if ball is below midpoint
            pos = transform.position.y - col.gameObject.transform.position.y;
            rigidbody2D.AddForce(new Vector2(Speed, pos * Speed), ForceMode2D.Impulse);
        }
        if (col.gameObject.name == "player_Two")
        {
            //pos = a negitive if ball is below midpoint
            pos = transform.position.y - col.gameObject.transform.position.y;
            rigidbody2D.AddForce(new Vector2(-Speed, pos * Speed), ForceMode2D.Impulse);
        }
        if (col.gameObject.name == "goal_One")
        {
            oneCount++;
            goals_One.text = oneCount.ToString();
            StartCoroutine(Goal());
        }
        if (col.gameObject.name == "goal_Two")
        {
            twoCount++;
            goals_Two.text = twoCount.ToString();
            StartCoroutine(Goal());
        }
    }
    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown("b")) { 

            int i = Random.Range(0, 2);
            if (i == 1)
                rigidbody2D.AddForce(new Vector2(Speed, 0), ForceMode2D.Impulse);
            else
                rigidbody2D.AddForce(new Vector2(-Speed, 0), ForceMode2D.Impulse);
        }
	}
    void Begin()
    {
        int i = Random.Range(0, 2);
        if (i == 1)
            rigidbody2D.AddForce(new Vector2(Speed, 0), ForceMode2D.Impulse);
        else
            rigidbody2D.AddForce(new Vector2(-Speed, 0), ForceMode2D.Impulse);
    }
    IEnumerator Goal(){
        transform.position = new Vector2(0, 0);
        rigidbody2D.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(3);
        Begin();
    }
}
