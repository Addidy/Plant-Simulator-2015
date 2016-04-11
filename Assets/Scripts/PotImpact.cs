using UnityEngine;
using System.Collections;

public class PotImpact : MonoBehaviour {

    private AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}

    void OnCollisionEnter(Collision col) {
        //TODO play sound
        audio.Play();
    }
}
