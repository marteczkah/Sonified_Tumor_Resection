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
    public int position = 1;
    public int song_samples = 0; 
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = letter.GetComponent<Renderer>();
    }

    // FixedUpdate is called every 0.2 seconds
    // 882 samples per 0.2 seconds 
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speedx);

        letter_pos = letter.position + letter.right * -letter.localScale.x / 2f;

        Debug.Log(Time.deltaTime);

        // print(rend.bounds);
        distance = (letter.position - transform.position).magnitude;

        GetComponent<ChuckSubInstance>().RunCode(string.Format (@"
            SinOsc s => dac;
            {0}::second => now;
        ", Time.deltaTime));

        // GetComponent<ChuckSubInstance>().RunCode(string.Format (@"
        //     // Gain g;
        //     // g => dac;
	    //     // SawOsc env;
        //     // 0.0 => env.width;
        //     // 1.2 => env.freq;
        //     // env => g;

        //     SndBuf buf;
        //     me.sourceDir() + ""/Songs_Wav/do_i_wanna_know.wav"" => string music_file;               
        //     music_file => buf.read; 
        //     1.0 => buf.rate;
        //     {0} => buf.pos; 
        //     buf => dac;

        //     chout <= ""Hello World"" <= IO.newline();

        //     20::ms => now;
        // ", position));

        // if (distance > 4.5f)
        // {
        //     GetComponent<ChuckSubInstance>().RunCode(string.Format (@"
        //         // Gain g;
        //         // g => dac;

	    //         // SawOsc env;
        //         // 0.0 => env.width;
        //         // 1.2 => env.freq;
        //         // env => g;

        //         SndBuf buf;
        //         me.sourceDir() + ""/Songs_Wav/do_i_wanna_know.wav"" => string music_file;
        //         music_file => buf.read; 
        //         1.0 => buf.rate;
        //         {0} => buf.pos; 
        //         buf => dac;

        //         chout <= ""Hello World"" <= IO.newline();

        //         20::ms => now;
        //     ", position));
        // }

        // else
        // {
        //     GetComponent<ChuckSubInstance>().RunCode(string.Format (@"
        //         // Gain g;
        //         // g => dac;

        //         // SawOsc env;
        //         // 0.0 => env.width;
        //         // 1.2 => env.freq;
        //         // env => g;

        //         SndBuf buf_2;
        //         me.sourceDir() + ""/Songs_Wav/do_i_wanna_know.wav"" => string music_file;
        //         music_file => buf_2.read; 
        //         0.2 => buf_2.rate;
        //         {0} => buf_2.pos; 
        //         buf_2 => dac;

        //         20::ms => now;
        //         ", position));
        // }
        position += 882;
        if (position >= 12014208) {
            position = 1;
        }

    }

}
