using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    /*
    keeps angle matching shelf
    manages growth function
    */

    public float rateOfGrowth = 1;
    public float rateOfBackZoom = 1;
    public float rateOfYPan = 1;
    public float rateOfRise = 1;
    public float growthMultiplier = 1;

    private float lightCiel;
    private GameObject camera;
    private GameObject shelf;
    private GameObject pot;
    private GameObject stalk;
    private GameObject flower;
    private GameObject sunlight;
    //private Vector3 flowerSize;

	// Use this for initialization
	void Start () {
        camera = GameObject.FindWithTag("MainCamera");
        shelf = GameObject.FindWithTag("Shelf");
        pot = GameObject.FindWithTag("Pot");
        stalk = GameObject.FindWithTag("Stalk");
        flower = GameObject.FindWithTag("Flower");
        sunlight = GameObject.FindWithTag("Sunlight");
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion shelfAngle = shelf.transform.rotation;
        pot.transform.eulerAngles = shelfAngle.eulerAngles;
	}

    public void Grow() {
        float rate = Time.deltaTime;
        rate *= growthMultiplier;
        float growthRate = rate * rateOfGrowth;
        stalk.transform.localScale += new Vector3(0f, 0f, growthRate);
        flower.transform.localScale = new Vector3(flower.transform.localScale.x, 1 / stalk.transform.localScale.z, flower.transform.localScale.z); //new Vector3(growthRate, 0f, growthRate);
        camera.transform.position += new Vector3(0f, rate * rateOfYPan, rate * -rateOfBackZoom);
        sunlight.transform.position += new Vector3(0f, growthRate * rateOfRise, 0f);
    }
}
