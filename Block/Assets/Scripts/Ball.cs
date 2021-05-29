using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    private Rigidbody rigid;
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        rigid.AddForce((transform.forward + transform.right) * speed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

