using UnityEngine;
using System.Collections;

public class CloudBehaviour : MonoBehaviour {

    public float startingBoundary = 5;
    public float speed = 1;
    public float direction = 1;

    private float boundary;

    // Use this for initialization
    void Start()
    {
        boundary = startingBoundary;
    }

    // Update is called once per frame
    //make light move left and right toward the increasing boundary
    void Update()
    {
        if (transform.localPosition.x > boundary)
        {
            direction = -1;
        }
        else if (transform.localPosition.x < -boundary)
        {
            direction = 1;
        }
        float movement = direction * speed * Time.deltaTime;
        transform.localPosition += new Vector3(movement, 0f, 0f);
    }
}
