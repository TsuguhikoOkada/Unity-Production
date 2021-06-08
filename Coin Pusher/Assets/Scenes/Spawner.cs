using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float moveSpeed = 2.0f;
    Rigidbody rb;

    public GameObject coin;

    public GameObject LeftWall;

    float leftWallPositionX;

    public GameObject RightWall;

    float rightWallPositionX;

    public GameObject scoreText;

    ScoreText scoreS;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        leftWallPositionX = LeftWall.transform.position.x;

        rightWallPositionX = RightWall.transform.position.x;

        scoreS = scoreText.GetComponent<ScoreText>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = this.transform.position;

        currentPosition.x = Mathf.Clamp(currentPosition.x,
                                        leftWallPositionX,
                                        rightWallPositionX);

        this.transform.position = currentPosition;

        float x = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(x, 0, 0);

        rb.velocity = direction * moveSpeed;

        if (Input.GetKeyDown("space"))
        {
            Instantiate(coin, this.transform.position, this.transform.rotation);

            scoreS.subScore(1);
        }

        
    }
}
