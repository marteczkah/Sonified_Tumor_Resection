using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumorDistance : MonoBehaviour
{
    private float distance;
    public MeshCollider tumor;
    public GameObject scalpelTip;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Chuck", (float) 0.5, (float) 0.5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 closestPoint = tumor.ClosestPoint(scalpelTip.transform.position);
        distance = Vector3.Distance(closestPoint, scalpelTip.transform.position);
    }

    void Chuck()
    {
        int current_freq = 0;
        float current_dist = distance * 100.0f;
        print("scalpel - tumor: " + current_dist + "cm");
        if (current_dist > 5.5f) { // out
            current_freq = 0;
        } else if (current_dist <= 5.5f && current_dist > 4.875f) { //1st outer
            current_freq = 1;
        } else if (current_dist <= 4.875f && current_dist > 4.250f) { //2nd outer
            current_freq = 2;
        } else if (current_dist <= 4.250f && current_dist > 3.625f) { //3rd outer
            current_freq = 3;
        } else if (current_dist <= 4.250f && current_dist > 3.625f) { //4th outer
            current_freq = 3;
        } else if (current_dist <= 3.625f && current_dist > 2.325f) { // cut here area
            current_freq = 4;
        } else if (current_dist <= 2.325f && current_dist > 2.025f) { // close to the dangerous area
            current_freq = 5;
        } else if (current_dist <= 2.025f) { // you too close
            current_freq = 6;
        } 
        GetComponent<ChuckSubInstance>().RunCode( string.Format ( @"
            ModalBar viol => NRev a => dac;
            [10, 30, 40, 60, 70, 90, 100] @=> int scale[];
            1  => a.gain;
            0.3 => a.mix;
            Std.mtof(scale[{0}]) => viol.freq;
            6 => viol.preset;
            1 => viol.noteOn;
            0.25 :: second => now;
            1 => viol.noteOff;
            0.25 :: second => now;
        ", current_freq));
    }
}
