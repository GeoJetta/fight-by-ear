using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public GameObject player;
	Renderer renderer;
	Material material;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		material = renderer.material;
		material.DisableKeyword("_EMISSION");
		audioSource.time = Random.Range (0.0f, 40.0f);
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position,player.transform.position,Time.deltaTime*0.2f);
		if (Vector3.Distance (transform.position, player.transform.position) < 1.5f)
			LightOn (false);
		else if (Vector3.Distance (transform.position, player.transform.position) < 2.0f)
			LightOn (true); 
		else
			LightOn (false);
	}

	public void LightOn( bool on )
	{

		if( on )
			material.EnableKeyword("_EMISSION");
		else
			material.DisableKeyword("_EMISSION");

	}
		
}
