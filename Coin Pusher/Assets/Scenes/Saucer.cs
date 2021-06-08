using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saucer : MonoBehaviour
{
     void OnCollisionEnter(Collision colObject)
    {
        if (colObject.gameObject.tag == "Coin")
        {
            Destroy(colObject.gameObject);

            scoreS.addScore(2);

            getSE.PlayOneShot(getSE.clip);
        }

        
    }

    public GameObject scoreText;
    ScoreText scoreS;

    AudioSource getSE;
    // Start is called before the first frame update
    void Start()
    {
        scoreS = scoreText.GetComponent<ScoreText>();
        getSE = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
