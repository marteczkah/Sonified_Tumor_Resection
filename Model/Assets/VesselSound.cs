using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class VesselSound : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scalpel;
    public MeshCollider vesselSurface;
    private AudioSource audioSource;
    private float distance;
    private OSCTransmitter transmitter;

    void Start()
    {
        transmitter = gameObject.AddComponent<OSCTransmitter>();
        transmitter.RemoteHost = "131.159.205.151";    
        transmitter.RemotePort = 7001;  
        InvokeRepeating("Vessel", (float) 0.3, (float) 0.3);
    }

    void FixedUpdate()
    {
        Vector3 closestPoint = vesselSurface.ClosestPoint(scalpel.transform.position);
        distance = Vector3.Distance(closestPoint, scalpel.transform.position);
        print("vessel - scalpel: " + distance);
    }

    void Vessel()
    {
        float current_dist = distance * 100.0f;
        if (current_dist <= 1.5f && current_dist > 1.0f) {
            print("vessel3");
            var message = new OSCMessage("/message/address");
            message.AddValue(OSCValue.String("vessel3"));
            transmitter.Send(message); 
        } else if (current_dist <=1.0f && current_dist > 0.5f) {
            print("vessel2");
            var message = new OSCMessage("/message/address");
            message.AddValue(OSCValue.String("vessel2"));
            transmitter.Send(message); 
        } else if (current_dist <=  0.5f && current_dist >= 0.0f) {
            print("vessel1");
            var message = new OSCMessage("/message/address");
            message.AddValue(OSCValue.String("vessel1"));
            transmitter.Send(message); 
        } else {
            var message = new OSCMessage("/message/address");
            message.AddValue(OSCValue.String("bequiet"));
            transmitter.Send(message);
        }
    }
}