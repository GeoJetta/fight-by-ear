using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCast : MonoBehaviour {
	public Camera cam;
	public Transform prefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				Transform objectHit = hit.transform;
				if (hit.collider.gameObject.tag == "Enemy" && hit.distance < 5.0f) {
					Instantiate(prefab, new Vector3(Random.Range(-10,10), 2, Random.Range(-10,10)), Quaternion.identity);
					Destroy (hit.collider.gameObject);
				}
			}

		}
	}
}
