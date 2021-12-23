using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Capsule : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
            GetComponent<ChuckSubInstance>().RunCode(@"
                SinOsc foo => dac;
                repeat( 5 )
                {
                    Math.random2f( 300, 1000 ) => foo.freq;
                    100::ms => now;
                }
		    ");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
            GetComponent<ChuckSubInstance>().RunCode(@"
                SinOsc foo => dac;
                repeat( 5 )
                {
                    Math.random2f( 700, 1000 ) => foo.freq;
                    100::ms => now;
                }
		    ");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            position.z++;
            this.transform.position = position;
            GetComponent<ChuckSubInstance>().RunCode(@"
                SinOsc foo => dac;
                repeat( 5 )
                {
                    Math.random2f( 200, 500 ) => foo.freq;
                    100::ms => now;
                }
		    ");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.z--;
            this.transform.position = position;
            GetComponent<ChuckSubInstance>().RunCode(@"
                SinOsc foo => dac;
                repeat( 5 )
                {
                    Math.random2f( 500, 600 ) => foo.freq;
                    100::ms => now;
                }
		    ");
        }
        
    }
}
