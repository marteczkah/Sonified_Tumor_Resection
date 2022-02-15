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
    
    private int[] frequency = {10, 20, 30, 40, 50, 60, 70, 80, 90, 100};
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = letter.GetComponent<Renderer>();
        InvokeRepeating("DistanceUpdate", (float) 0.5, (float) 0.5);
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speedx);

        letter_pos = letter.position + letter.right * -letter.localScale.x / 2f;

        Debug.Log(Time.deltaTime);

        // print(rend.bounds);
        distance = (letter.position - transform.position).magnitude;
    }

    // FixedUpdate is called every 0.2 seconds
    // 882 samples per 0.2 seconds 
    void DistanceUpdate()
    {
        int current_freq = 0;
        if (distance > 30) {
            current_freq = 0;
            print("f" + current_freq);
        } else if (distance <=30 && distance > 25) {
            current_freq = 1;
            print("f" + current_freq);
        } else if (distance <=25 && distance > 20) {
            current_freq = 2;
            print("f" + current_freq);
        } else if (distance <=20 && distance > 17) {
            current_freq = 3;
            print("f" + current_freq);
        } else if (distance <=17 && distance > 15) {
            current_freq = 4;
            print("f" + current_freq);
        } else if (distance <=15 && distance > 10) {
            current_freq = 5;
            print("f" + current_freq);
        } else if (distance <=10 && distance > 7) {
            current_freq = 6;
            print("f" + current_freq);
        } else if (distance <=7 && distance > 5) {
            current_freq = 7;
            print("f" + current_freq);
        } else if (distance <=5 && distance > 3) {
            current_freq = 8;
            print("f" + current_freq);
        } else {
            current_freq = 9;
            print("f" + current_freq);
        }

        GetComponent<ChuckSubInstance>().RunCode( string.Format ( @"
            ModalBar viol => dac;
            [10, 20, 30, 40, 50, 60, 70, 80, 90, 100] @=> int scale[];
            Std.mtof(scale[{0}]) => viol.freq;
            6 => viol.preset;
            1 => viol.noteOn;
            0.5 :: second => now;
            1 => viol.noteOff;
            0.5 :: second => now;
        ", current_freq));

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
