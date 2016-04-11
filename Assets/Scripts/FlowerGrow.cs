using UnityEngine;
using System.Collections;

public class FlowerGrow : MonoBehaviour {

    public bool debug = false;

    private PlayerController player;
    private LightBehaviour sun;
    private GameController game;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        sun =  GameObject.FindWithTag("Sunlight").GetComponent<LightBehaviour>();
        game = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}

    void Update() {
        if (debug) {
            Growing();
        }
    }

    void OnTriggerStay(Collider col) {
        if (col.tag == "Sun Trigger" && !debug) {
            Growing();
        }
    }

    void Growing() {
        player.Grow();
        sun.IncreaseBoundary();
        game.IncreaseScore();
    }
}
