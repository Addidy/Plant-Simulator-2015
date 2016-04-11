using UnityEngine;
using System.Collections;

public class LineWidener : MonoBehaviour {
    public float width = 1;
	// Use this for initialization
	void Start () {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.SetWidth(0, 10);
    }
}
