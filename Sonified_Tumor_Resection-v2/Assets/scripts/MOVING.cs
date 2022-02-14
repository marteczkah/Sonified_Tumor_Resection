using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MOVING : MonoBehaviour

{
    public float speedx = 5.0f;
    public Transform letter;
    public Vector3 letter_pos;
    public float distance;
    public float time_ = 0f;
    Renderer rend;
    private AudioSource audioSource;

    public AudioClip song1;
    public AudioClip song2; 
    public int startingPitch = 4;

    private bool paused1;
    private bool paused2;

    // Start is called before the first frame update
    void Start()
    {
        rend = letter.GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
        paused1 = true;
        paused2 = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speedx);

        letter_pos = letter.position + letter.right * -letter.localScale.x / 2f;

        // print(rend.bounds);
        distance = (letter.position - transform.position).magnitude;

        print("d" + distance);

        if (paused2 && distance < 10.5) {
            audioSource.Pause();
            audioSource.clip = song2;
            // audioSource.pitch = 0.5f;
            audioSource.Play();
            paused2 = false;
            paused1 = true;
        }

        if (paused1 && distance >= 10.5) {
            audioSource.Pause();
            audioSource.clip = song1;
            audioSource.Play();
            paused1 = false;
            paused2 = true;
        }

    }

}
