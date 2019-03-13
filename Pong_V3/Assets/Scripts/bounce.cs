using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bounce : MonoBehaviour {

    public float Speed = 10;
    public GameObject player_One;
    public GameObject player_Two;
    public GameObject goal_One;
    public GameObject goal_Two;
    public Text goals_One;
    public Text goals_Two;
    
    float pos, oneCount, twoCount;
    public double hitOnX, hitOnY;
    void OnCollisionEnter2D (Collision2D col)
    {
        // if hits player 1
        if (col.gameObject == player_One)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Speed, (transform.position.y - col.gameObject.transform.position.y) * Speed), ForceMode2D.Impulse);
        // if hits player 2
        if (col.gameObject == player_Two)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-Speed, (transform.position.y - col.gameObject.transform.position.y) * Speed), ForceMode2D.Impulse);
        // if hits goal 1
        if (col.gameObject == goal_One) {
            oneCount++;
            goals_One.text = oneCount.ToString();
            hitOnX = transform.localPosition.x;
            hitOnY = transform.localPosition.y;
            StartCoroutine(Goal());
        }
        // if hits goal 2
        if (col.gameObject == goal_Two) {
            twoCount++;
            goals_Two.text = twoCount.ToString();
            hitOnX = transform.localPosition.x;
            hitOnY = transform.localPosition.y;
            StartCoroutine(Goal());
        }
    }
    void Update() {
        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 6 || transform.position.y < -6)
            StartCoroutine(Goal());

        if (Input.GetKeyDown("b"))
           Begin();
	}
    void Begin()
    {
        /* int i = Random.Range(0, 2);
        if (i == 1)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Speed, Random.Range(-Speed, Speed)), ForceMode2D.Impulse);
        else
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-Speed, Random.Range(-Speed, Speed)), ForceMode2D.Impulse);*/
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-Speed, 0), ForceMode2D.Impulse);
    }
    IEnumerator Goal(){
        transform.position = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(1);
        Begin();
    }
}