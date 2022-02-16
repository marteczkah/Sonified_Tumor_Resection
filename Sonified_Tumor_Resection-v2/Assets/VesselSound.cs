using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesselSound : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject moving_object;
    public GameObject cube;
    private float distance;
    void Start()
    {
        InvokeRepeating("Vessel", (float) 0.3, (float) 0.3);
    }

    void Update()
    {
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
}
