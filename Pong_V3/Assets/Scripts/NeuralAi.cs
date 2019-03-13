using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NeuralAi : MonoBehaviour { 
    public GameObject ball;
    public double sensitivity;
    public double learningCurve = 0.1f;
    public float Range = 0.1f;
    public int tries = 20;
    public Text points;
    public Text HITS, GEN, BABY;
    bounce b;
    String str;
    /* Below is the assload of shit Variable that wont be explained 
    in this version. next version will be way Neater. this version 
    needs to work first though.....
    perfeable neurons and weights should get stuffed inside arrays for
    beauty purposees*/
    double x, y, x1, x2, x3, x4, y1, y2, y3, y4, h1, h2, h3, h4, 
        w1, w2, w3, w4, w11, w22, w33, w44, diff, output, output2;
    int count, hitCount, babyCount,genCount, bestBaby;
    double xx1,xx2,xx3,xx4,yy1,yy2,yy3,yy4,ww1,ww11,ww2,ww22,ww3,ww33,ww4,ww44;
    void Awake(){
        b = ball.GetComponent<bounce>();
        if (b == null)
            b = ball.AddComponent<bounce>();
        RandomWeights();
    }
	void Update () {
        Init();
        if (transform.position.y + output * output2 < 4.2 && transform.position.y + output * output2 > -4.2)
            transform.position += new Vector3(0, (float)output * (float)output2);
        if (points.text.Equals(str) == false) {
            str = points.text;
            Teach();
        }
        //at end of life
        if(tries == count){
            transform.position = new Vector2(transform.position.x, 0);
            Debug.Log("baby number :" + babyCount);
            Debug.Log("hitCount : " + hitCount);
            babyCount++;
            BABY.text = "Baby: " + babyCount;
            count = 0;
            //sorting for best baby
            if (hitCount > bestBaby) {
                bestBaby = hitCount;
                CopyWeights();
            }
            hitCount = 0;
            //at end ofENeration
            if (babyCount == 10 ) {
            genCount++;
            GEN.text = "GEN:" + genCount;
                Debug.Log("Gen :" + genCount);
                Debug.Log("best baby :" + bestBaby);
                babyCount = 0;
                BabyMake();
            } else
                if (babyCount <= 10)
                    RandomWeights();
            if (genCount > 0) {
                BabyMake();
            }
        }
    }
    void Init() {
        x = ball.transform.position.x;
        y = ball.transform.position.y;

        h1 = x * x1 + y * y1;
        h2 = x * x2 + y * y2;
        h3 = x * x3 + y * y3;
        h4 = x * x4 + y * y4;

        output = (h1 * w1) + (h2 * w2) + (h3 * w3) + (h4 * w4);
        output2 = (h1 * w11) + (h2 * w22) + (h3 * w33) + (h4 * w44);
    }
    void RandomWeights() {
        x = b.hitOnX;
        y = b.hitOnY;

        x1 = UnityEngine.Random.Range(-Range, Range);
        x2 = UnityEngine.Random.Range(-Range, Range);
        x3 = UnityEngine.Random.Range(-Range, Range);
        x4 = UnityEngine.Random.Range(-Range, Range);

        y1 = UnityEngine.Random.Range(-Range, Range);
        y2 = UnityEngine.Random.Range(-Range, Range);
        y3 = UnityEngine.Random.Range(-Range, Range);
        y4 = UnityEngine.Random.Range(-Range, Range);

        w1 = UnityEngine.Random.Range(-Range, Range);
        w11 = UnityEngine.Random.Range(-Range, Range);
        w2 = UnityEngine.Random.Range(-Range, Range);
        w22 = UnityEngine.Random.Range(-Range, Range);
        w3 = UnityEngine.Random.Range(-Range, Range);
        w33 = UnityEngine.Random.Range(-Range, Range);
        w4 = UnityEngine.Random.Range(-Range, Range);
        w44 = UnityEngine.Random.Range(-Range, Range);
    }
    void OnCollisionEnter2D (Collision2D col) {
        hitCount++;
        HITS.text = "Hits: " + hitCount;
    }
    void Teach() {
        x = b.hitOnX;
        y = b.hitOnY;
        diff =  y - transform.position.y ;
        x1 -= learningCurve * diff * x;
        x2 -= learningCurve * diff * x;
        x3 -= learningCurve * diff * x;
        x4 -= learningCurve * diff * x;

        y1 -= learningCurve * diff * y;
        y2 -= learningCurve * diff * y;
        y3 -= learningCurve * diff * y;
        y4 -= learningCurve * diff * y;

        w1 -= learningCurve * diff * h1;
        w11 -= learningCurve * diff * h1;
        
        w2 -= learningCurve * diff * h2;
        w22 -= learningCurve * diff * h2;
        
        w3 -= learningCurve * diff * h3;
        w33 -= learningCurve * diff * h3;
        
        w4 -= learningCurve * diff * h4;
        w44 -= learningCurve * diff * h4;

        count++;
    }
    IEnumerator Wait(float f) {
        yield return new WaitForSeconds(f);
    }
    void OnApplicationQuit() {
        PrintStuff();
    }
    void PrintStuff() {
        Debug.Log("Count : " + count);
        Debug.Log("Hit Count : " + hitCount);
        Debug.Log("x1 : " + x1);
        Debug.Log("x2 : " + x2);
        Debug.Log("x3 : " + x3);
        Debug.Log("x4 : " + x4);

        Debug.Log("y1 : " + y1);
        Debug.Log("y2 : " + y2);
        Debug.Log("y3 : " + y3);
        Debug.Log("y4 : " + y4);

        Debug.Log("h1 : " + h1);
        Debug.Log("h2 : " + h2);
        Debug.Log("h3 : " + h3);
        Debug.Log("h4 : " + h4);

        Debug.Log("w1 : " + w1);
        Debug.Log("w2 : " + w2);
        Debug.Log("w3 : " + w3);
        Debug.Log("w4 : " + w4);

        Debug.Log("w11 : " + w11);
        Debug.Log("w22 : " + w22);
        Debug.Log("w33 : " + w33);
        Debug.Log("w44 : " + w44);
    }
    void CopyWeights() {
        xx1 = x1;
        xx2 = x2;
        xx3 = x3;
        xx4 = x4;

        yy1 = y1;
        yy2 = y2;
        yy3 = y3;
        yy4 = y4;

        ww1 = w1;
        ww11 = w11;
        ww2 = w2;
        ww22 = w22;
        ww3 = w3;
        ww33 = w33;
        ww4 = w4;
        ww44 = w44;
    }
    void BabyMake() {
        x1 = xx1 + xx1 * UnityEngine.Random.Range(-Range, Range);
        x2 = xx2 + xx2 * UnityEngine.Random.Range(-Range, Range);
        x3 = xx3 + xx3 * UnityEngine.Random.Range(-Range, Range);
        x4 = xx4 + xx4 * UnityEngine.Random.Range(-Range, Range);

        y1 = yy1 + yy1 * UnityEngine.Random.Range(-Range, Range);
        y2 = yy2 + yy2 * UnityEngine.Random.Range(-Range, Range);
        y3 = yy3 + yy3 * UnityEngine.Random.Range(-Range, Range);
        y4 = yy4 + yy4 * UnityEngine.Random.Range(-Range, Range);

        w1 = ww1 + ww1 * UnityEngine.Random.Range(-Range, Range);
        w11 = ww11 + ww11 * UnityEngine.Random.Range(-Range, Range);
        w2 = ww2 + ww2 * UnityEngine.Random.Range(-Range, Range);
        w22 = ww22 + ww22 * UnityEngine.Random.Range(-Range, Range);
        w3 = ww3 + ww3 * UnityEngine.Random.Range(-Range, Range);
        w33 = ww33 + ww33 * UnityEngine.Random.Range(-Range, Range);
        w4 = ww4 + ww4 * UnityEngine.Random.Range(-Range, Range);
        w44 = ww44 + ww44 * UnityEngine.Random.Range(-Range, Range);
    }
}