using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCast : MonoBehaviour {
	public Camera cam;
	public Transform prefab;
	Light myLight;

	// Use this for initialization
	void Start () {
		myLight = (Light)GameObject.FindObjectOfType (typeof(Light));
		myLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			Debug.DrawRay(transform.position, transform.forward, Color.green);
			if (Physics.Raycast (ray, out hit)) {
				Transform objectHit = hit.transform;
				if (hit.collider.gameObject.tag == "Enemy" && hit.distance < 5.0f) {
					StartCoroutine (Example(hit));
				}
			}

		}
	}

	IEnumerator Example( RaycastHit iHit )
	{
		myLight.enabled = true;
		yield return new WaitForSeconds(2);
		myLight.enabled = false;
		Instantiate(prefab, new Vector3(Random.Range(-10,10), 2, Random.Range(-10,10)), Quaternion.identity);
		Destroy (iHit.collider.gameObject);
	}

}
