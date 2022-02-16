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
    public AudioSource[] audioSource;
    public AudioSource chuckAudio;
    public AudioSource bachAudio;
    public AudioClip song1;
    private int[] frequency = {10, 20, 30, 40, 50, 60, 70, 80, 90, 100};
    Renderer rend;
    bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        rend = letter.GetComponent<Renderer>();
        audioSource = GetComponents<AudioSource>();
        bachAudio = audioSource[1];
        bachAudio.clip = song1;
        bachAudio.time = 5;
        InvokeRepeating("ChuckBach", (float) 0.5, (float) 0.5);
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
    void PlainChuck()
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
            ModalBar viol => NRev a => dac;
            [10, 20, 30, 40, 50, 60, 70, 80, 90, 100] @=> int scale[];
            1  => a.gain;
            0.3 => a.mix;
            Std.mtof(scale[{0}]) => viol.freq;
            6 => viol.preset;
            1 => viol.noteOn;
            0.3 :: second => now;
            1 => viol.noteOff;
            0.3 :: second => now;
        ", current_freq));
    }

    void ChuckBach() 
    {
        int current_freq = 0;
        bool play = false;
        if (distance > 30) {
            play = false;
            current_freq = 0;
            print("f" + current_freq);
        } else if (distance <=30 && distance > 25) {
            play = false;
            current_freq = 1;
            print("f" + current_freq);
        } else if (distance <=25 && distance > 20) {
            play = false;
            current_freq = 2;
            print("f" + current_freq);
        } else if (distance <=20 && distance > 17) {
            play = false;
            current_freq = 3;
            print("f" + current_freq);
        } else if (distance <=17 && distance > 15) {
            play = false;
            current_freq = 4;
            print("f" + current_freq);
        } else if (distance <=15 && distance > 10) {
            play = false;
            current_freq = 6;
            print("f" + current_freq);
        } else if (distance <=10 && distance > 7) {
            play = false;
            current_freq = 7;
            print("f" + current_freq);
        } else if (distance <=7 && distance > 5) {
            play = false;
            current_freq = 8;
            print("f" + current_freq);
        } else if (distance <=5 && distance > 3) {
            play = false;
            current_freq = 9;
            print("f" + current_freq);
        } else {
            play = true;
        }

        if (play) {
            if (playing == false) {
                bachAudio.Play();
                playing = true;
            }
        } else {
            playing = false;
            bachAudio.Pause();
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
        }
    }
}
