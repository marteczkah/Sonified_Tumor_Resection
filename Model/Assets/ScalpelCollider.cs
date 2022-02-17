using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalpelCollider : MonoBehaviour
{
    public GameObject Tumor;
    public GameObject InnerLayer;
    public GameObject ResectionArea;
    public GameObject BloodVessel;
    public GameObject ScalpelTip;
    public Text TumorDistance;
    public Text VesselDistance;
    public Text CurrentText;

    List<float> distancesTumor = new List<float>();
    List<float> distancesVessel = new List<float>();
    


    

   

    // Start is called before the first frame update
    void Start()
    {
        //tumor = GameObject.Find("Tumor");
        //scalpelTip = GameObject.Find("ScalpelTip");
        //innerLayer = GameObject.Find("InnerLayer");
        //resectionArea = GameObject.Find("ResectionArea");
        //bloodVessel = GameObject.Find("BloodVessel");
        //tumorDistance.text = "";
        //currentText.text = "";   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     
}
