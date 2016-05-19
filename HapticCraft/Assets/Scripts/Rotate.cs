using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public float rotation;

	void Start () {
        transform.Rotate(Vector3.up * rotation);
	}
}
