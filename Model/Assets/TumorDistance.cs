using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class TumorDistance : MonoBehaviour
{
    private float distance;
    public MeshCollider tumor;
    public GameObject scalpelTip;
    private OSCTransmitter transmitter;
    private OSCReceiver receiver;    
    // Start is called before the first frame update
    void Start()
    {
        transmitter = gameObject.AddComponent<OSCTransmitter>();
        transmitter.RemoteHost = "127.0.0.1";    
        transmitter.RemotePort = 7001;  

        // receiver = gameObject.AddComponent<OSCReceiver>(); 
        // receiver.LocalPort = 7001; 
        // receiver.Bind("/message/address", MessageReceived);     

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
        bool inTheArea = false;
        bool isNearRed = false;
        bool isInRead = false;
        bool isTumor = false;
        float current_dist = distance * 100.0f;
        print("scalpel - tumor: " + current_dist + "cm");
        if (current_dist <= 5.5f && current_dist > 4.875f) { //1st outer
            current_freq = 1;
            inTheArea = true;
            // Create message
            var message = new OSCMessage("/message/address");
            // Populate values.
            message.AddValue(OSCValue.String("area60"));
            // Send message
            transmitter.Send(message); 
        } else if (current_dist <= 4.875f && current_dist > 4.250f) { //2nd outer
            current_freq = 2;
            inTheArea = true;
            var message = new OSCMessage("/message/address");
            // Populate values.
            message.AddValue(OSCValue.String("area70"));
            // Send message
            transmitter.Send(message); 
        } else if (current_dist <= 4.250f && current_dist > 3.625f) { //3rd outer
            current_freq = 3;
            inTheArea = true;
            var message = new OSCMessage("/message/address");
            // Populate values.
            message.AddValue(OSCValue.String("area80"));
            // Send message
            transmitter.Send(message); 
        } else if (current_dist <= 4.250f && current_dist > 3.625f) { //4th outer
            current_freq = 3;
            inTheArea = true;
            var message = new OSCMessage("/message/address");
            // Populate values.
            message.AddValue(OSCValue.String("area90"));
            // Send message
            transmitter.Send(message); 
        } else if (current_dist <= 3.625f && current_dist > 2.325f) { // cut here area
            current_freq = 4;
            inTheArea = true;
            var message = new OSCMessage("/message/address");
            // Populate values.
            message.AddValue(OSCValue.String("inTheArea"));
            // Send message
            transmitter.Send(message); 
        } else if (current_dist <= 2.325f && current_dist > 2.025f) { // close to the dangerous area
            isNearRed = true;
            var message = new OSCMessage("/message/address");
            // Populate values.
            message.AddValue(OSCValue.String("isNearRed"));
            // Send message
            transmitter.Send(message); 
        } else if (current_dist <= 2.025f &&  current_dist > 0.5f) { // you too close
            isInRead = true;
            var message = new OSCMessage("/message/address");
            // Populate values.
            message.AddValue(OSCValue.String("isInRed"));
            // Send message
            transmitter.Send(message); 
        } else if (current_dist <= 0.5f && current_dist >= 0) {
            isTumor = true;
            var message = new OSCMessage("/message/address");
            // Populate values.
            message.AddValue(OSCValue.String("isTumor"));
            // Send message
            transmitter.Send(message); 
        }
        // if (isNearRed) {
        //     GetComponent<ChuckSubInstance>().RunCode( @"
        //         HevyMetl hm => NRev a => dac;
        //         [80, 90, 100] @=> int scale[];
        //         1  => a.gain;
        //         0.3 => a.mix;
        //         for (0 => int i; i < scale.cap(); i++)
        //         {
        //             Std.mtof(scale[i]) => hm.freq;
        //             1 => hm.noteOn;
        //             0.1 :: second => now;
        //             1 => hm.noteOff;
        //             0.1 :: second => now;
        //         }
        //     ");
        // } else if (isInRead) {
        //     GetComponent<ChuckSubInstance>().RunCode( @"
        //         SinOsc m => SinOsc c => dac;
        //         550 => c.freq;
        //         500 => m.freq;
        //         300 => m.gain;
        //         2 => c.sync;
        //         0.5 :: second => now;
        //     ");
        // } else if (isTumor) {
        //     GetComponent<ChuckSubInstance>().RunCode( @"
        //         SinOsc sinO => dac;
        //         Std.mtof(150) => sinO.freq;
        //         0.5 :: second => now;
        //     ");
        // } else if (inTheArea) {
        //     GetComponent<ChuckSubInstance>().RunCode( string.Format ( @"
        //         ModalBar viol => NRev a => dac;
        //         [60, 70, 80, 90, 100] @=> int scale[];
        //         1  => a.gain;
        //         0.3 => a.mix;
        //         Std.mtof(scale[{0}]) => viol.freq;
        //         6 => viol.preset;
        //         1 => viol.noteOn;
        //         0.25 :: second => now;
        //         1 => viol.noteOff;
        //         0.25 :: second => now;
        //     ", current_freq));
        // }
    }

    protected void MessageReceived(OSCMessage message)
    {
        Debug.Log("message sent! " + message);
    }
}
