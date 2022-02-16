using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesselSound : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject moving_object;
    public GameObject cube;
    private float distance;
    private AudioSource audioSource;
    void Start()
    {
        InvokeRepeating("Vessel2", (float) 0.3, (float) 0.3);
    }

    void Update()
    {
        audioSource = GetComponent<AudioSource>();
        distance = Vector3.Distance(moving_object.transform.position, cube.transform.position);
    }
    // Update is called once per frame
    void Vessel() {
        if (distance < 10 && distance > 7.5) {
            GetComponent<ChuckSubInstance>().RunCode(@"
                Impulse imp => ResonZ filt => dac;
                100.0 => filt.Q;
                500 => filt.freq;
                100.0 => imp.next;
                0.1 :: second => now;
                1000 => filt.freq;
                100.0 => imp.next;
                0.1 :: second => now;
                250 => filt.freq;
                100.0 => imp.next;
                0.1 :: second => now;
            ");
        } else if (distance <=7.5 && distance > 5) {
            GetComponent<ChuckSubInstance>().RunCode(@"
                Impulse imp => ResonZ filt => dac;
                100.0 => filt.Q;
                1500 => filt.freq;
                100.0 => imp.next;
                0.1 :: second => now;
                2000 => filt.freq;
                100.0 => imp.next;
                0.1 :: second => now;
                1000 => filt.freq;
                100.0 => imp.next;
                0.1 :: second => now;
            ");
        } else if (distance <= 5) {
            GetComponent<ChuckSubInstance>().RunCode(@"
                Impulse imp => ResonZ filt => dac;
                100.0 => filt.Q;
                3500 => filt.freq;
                100.0 => imp.next;
                0.1 :: second => now;
                4000 => filt.freq;
                100.0 => imp.next;
                0.1 :: second => now;
                3000 => filt.freq;
                100.0 => imp.next;
                0.1 :: second => now;
            ");
        }
    }

    void Vessel2() {
        bool is_playing = false;
        if (distance < 10 && distance > 7.5) {
            audioSource.volume = 0.3f;
            is_playing = true;
        } else if (distance <=7.5 && distance > 5) {
            audioSource.volume = 0.6f;
            is_playing = true;
        } else if (distance <= 5) {
            audioSource.volume = 1.0f;
            is_playing = true;
        }
        if (is_playing) {
            GetComponent<ChuckSubInstance>().RunCode(@"
                Noise n => LPF f => dac;
                // set biquad pole radius
                //.99 => f.prad;
                // set biquad gain
                //100 => f.freq;
                // set equal zeros 
                //1 => f.eqzs;
                // our float
                0.0 => float t;

                // infinite time-loop
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
