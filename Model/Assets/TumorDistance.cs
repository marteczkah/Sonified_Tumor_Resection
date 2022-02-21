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
        InvokeRepeating("Chuck", (float) 0.5, (float) 0.5);
    }

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
            var message = new OSCMessage("/message/address");
            message.AddValue(OSCValue.String("outerLayerOne"));
            transmitter.Send(message); 
        } else if (current_dist <= 4.875f && current_dist > 4.250f) { //2nd outer
            current_freq = 2;
            inTheArea = true;
            var message = new OSCMessage("/message/address");
            message.AddValue(OSCValue.String("outerLayerTwo"));
            transmitter.Send(message); 
        } else if (current_dist <= 4.250f && current_dist > 3.625f) { //3rd outer
            current_freq = 3;
            inTheArea = true;
            var message = new OSCMessage("/message/address");
            message.AddValue(OSCValue.String("outerLayerThree"));
            transmitter.Send(message); 
        } else if (current_dist <= 4.250f && current_dist > 3.625f) { //4th outer
            current_freq = 3;
            inTheArea = true;
            var message = new OSCMessage("/message/address");
            message.AddValue(OSCValue.String("outerLayerFour"));
            transmitter.Send(message); 
        } else if (current_dist <= 3.625f && current_dist > 2.325f) { // cut here area
            current_freq = 4;
            inTheArea = true;
            var message = new OSCMessage("/message/address");
            message.AddValue(OSCValue.String("inTheArea"));
            transmitter.Send(message); 
        } else if (current_dist <= 2.325f && current_dist > 2.025f) { // close to the dangerous area
            isNearRed = true;
            var message = new OSCMessage("/message/address");
            message.AddValue(OSCValue.String("isNearRed"));
            transmitter.Send(message); 
        } else if (current_dist <= 2.025f &&  current_dist > 0.5f) { // you too close
            isInRead = true;
            var message = new OSCMessage("/message/address");
            message.AddValue(OSCValue.String("isInRed"));
            transmitter.Send(message); 
        } else if (current_dist <= 0.5f && current_dist >= 0) {
            isTumor = true;
            var message = new OSCMessage("/message/address");
            message.AddValue(OSCValue.String("isTumor"));
            transmitter.Send(message); 
        }
    }

    protected void MessageReceived(OSCMessage message)
    {
        Debug.Log("message sent! " + message);
    }
}
