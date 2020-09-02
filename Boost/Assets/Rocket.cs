using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;
	[SerializeField] float rcsThrust = 100f;
	[SerializeField] float mainThrust = 100f;

	// Start is called before the first frame update
	void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
		Thrust();
		Rotate();
    }

	private void OnCollisionEnter( Collision collision ) {

		switch ( collision.gameObject.tag ) {

			case "Friendly":
				print( "Friendly" );
				break;
			default:
				print( "Dead" );
				break;
		
		}

	}

	private void Rotate() {

		
		float rotationSpeedThisFrame = rcsThrust * Time.deltaTime;

		rigidBody.freezeRotation = true;

		if ( Input.GetKey( KeyCode.A ) ) {

			
			transform.Rotate( Vector3.forward * rotationSpeedThisFrame );
		}
		else if ( Input.GetKey( KeyCode.D ) ) {
			transform.Rotate( -Vector3.forward * rotationSpeedThisFrame );
		}

		rigidBody.freezeRotation = false;


	}

	private void Thrust() {

		if ( Input.GetKey( KeyCode.Space ) ) {

			rigidBody.AddRelativeForce( Vector3.up * mainThrust );

			if ( !audioSource.isPlaying ) {
				audioSource.Play();
			}

		}

		if ( Input.GetKeyUp( KeyCode.Space ) ) {
			audioSource.Stop();
		}

	}
}
