using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesselSound : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scalpel;
    public MeshCollider vesselSurface;
    private AudioSource audioSource;
    private float distance;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Vessel", (float) 0.3, (float) 0.3);
    }

    void FixedUpdate()
    {
        Vector3 closestPoint = vesselSurface.ClosestPoint(scalpel.transform.position);
        distance = Vector3.Distance(closestPoint, scalpel.transform.position);
        print("vessel - scalpel: " + distance);
    }

    // Update is called once per frame
    void Vessel()
    {
        bool is_playing = false;
        float current_dist = distance * 100.0f;
        if (current_dist <= 1.5f && current_dist > 1.0f) {
            audioSource.volume = 0.3f;
            is_playing = true;
        } else if (current_dist <=1.0f && current_dist > 0.5f) {
            audioSource.volume = 0.6f;
            is_playing = true;
        } else if (current_dist <=  0.5f && current_dist > 0.0f) {
            audioSource.volume = 1.0f;
            is_playing = true;
        }
        if (is_playing) {
            GetComponent<ChuckSubInstance>().RunCode(@"
                Noise n => LPF f => dac;
                0.0 => float t;

                for (0 => int i; i < 3; i++)
                {
                    // sweep the filter resonant frequency
                    500.0 + Std.fabs(Math.sin(t)) * 200.0 => f.freq;
                    t + .02 => t;
                    // advance time
                    0.1 :: second => now;
                }
            ");
        }
        
    }
}
