using UnityEngine;
using System.Collections;

public class CountdownNumber : MonoBehaviour {

    float startTime;

    Renderer rend;

    bool fading = false;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        transform.Rotate(Vector3.up * 180);
        startTime = Time.time;
	}

    void Update() {
        if (!fading) {
            fading = true;
            StartCoroutine(FadeTo(0.0f, 0.5f));
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.localScale *= 1.01f;
	}

    IEnumerator FadeTo(float aValue, float aTime) {
        float alpha = rend.material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
            Color newColor = rend.material.color;
            newColor.a = Mathf.Lerp(alpha, aValue, t);
            rend.material.color = newColor;
            yield return null;
        }
        Destroy(gameObject);
    }
}
