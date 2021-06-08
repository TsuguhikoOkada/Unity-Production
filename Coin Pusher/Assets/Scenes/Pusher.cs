using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Vector3 initPosition;
    Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        initPosition = this.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = new Vector3(initPosition.x,
                                  initPosition.y,
                                  initPosition.z + Mathf.Sin(Time.time));

        this.GetComponent<Rigidbody>().MovePosition(newPosition);
    }
}
