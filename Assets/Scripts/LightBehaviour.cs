using UnityEngine;
using System.Collections;

public class LightBehaviour : MonoBehaviour {

    public float startingBoundary = 5;
    public float bIncreaseRate = 1;
    public float speed = 1;

    private float boundary;
    private float direction = 1;

	// Use this for initialization
	void Start () {
        boundary = startingBoundary;
	}
	
	// Update is called once per frame
    //make light move left and right toward the increasing boundary
	void Update () {
	    if (transform.localPosition.x > boundary) {
            direction = -1;
        }else if (transform.localPosition.x < -boundary) {
            direction = 1;
        }
        float movement = direction * speed * Time.deltaTime;
        transform.localPosition += new Vector3(movement, 0f, 0f);
    }

    public void IncreaseBoundary() {
        boundary += bIncreaseRate * Time.deltaTime;
    }
}
