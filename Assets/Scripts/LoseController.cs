using UnityEngine;
using System.Collections;

public class LoseController : MonoBehaviour {
    //controls when the lose condition of the game gets called

    private GameController game;

	// Use this for initialization
	void Start () {
        game = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Pot") {
            game.Lose();
        }
    }
}
