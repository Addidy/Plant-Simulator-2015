using UnityEngine;
using System.Collections;

public class TiltController : MonoBehaviour {

    public float baseUserForce = 50f;

    //depending on whether the user inputs left or right a force should be added to tilt the shelf either way
    void FixedUpdate() {
        float force = Input.GetAxis("Horizontal") * baseUserForce * Time.deltaTime;
        GetComponent<Rigidbody>().AddTorque(transform.forward * -force);
    }
}
