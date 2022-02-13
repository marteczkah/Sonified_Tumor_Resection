using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVING : MonoBehaviour

{
    public float speedx = 5.0f;
    public Transform letter;
    public Vector3 letter_pos;
    public float distance;
    public float time_ = 0f;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = letter.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speedx);

        letter_pos = letter.position + letter.right * -letter.localScale.x / 2f;

        // print(rend.bounds);
        distance = (letter.position - transform.position).magnitude;

        print("d" + distance);

        if (distance > 4.5f)
        {

            if (Time.time - time_ >= 1.5f)
            {
                GetComponent<ChuckSubInstance>().RunCode(@"
	        SinOsc foo => dac;
		        300 => foo.freq;
		        300::ms => now;
            ");
                time_ = Time.time;
            }
        }

        else
        {
                if (Time.time - time_ >= 1)
                {
                    GetComponent<ChuckSubInstance>().RunCode(@"
	        SinOsc foo => dac;
		        600 => foo.freq;
		        150::ms => now;
            ");
                    time_ = Time.time;
                }

        }

    }

}
