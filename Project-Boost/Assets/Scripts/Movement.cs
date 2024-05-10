using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 2000;
    [SerializeField] float mainRotate = 5f;
    [SerializeField] AudioClip thrustAudio;
    [SerializeField] ParticleSystem thrustParticles;
    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        StartThrusting();
    }

    void StartThrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                thrustParticles.Play();
            }
        }
        else
        {
            audioSource.Stop();
            thrustParticles.Stop();
        }
    }

    void ProcessRotation()
    {
        StartRotating();
    }

    void StartRotating()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * mainRotate * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * mainRotate * Time.deltaTime);
        }
    }


}
