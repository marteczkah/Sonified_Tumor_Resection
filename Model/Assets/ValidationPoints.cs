using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValidationPoints : MonoBehaviour
{
    public float scored_points = 0;
    public MeshCollider tumor;
    public GameObject scalpelTip;
    private float tumor_distance;
    private float too_close_time = 0;
    bool too_close = false;
    public TextMeshPro scoreText;
    void Start()
    {
        // scoreText = GetComponent<TextMeshPro>();
    }
    void FixedUpdate()
    {
        Vector3 closestPoint = tumor.ClosestPoint(scalpelTip.transform.position);
        tumor_distance = Vector3.Distance(closestPoint, scalpelTip.transform.position);
    }
    void OnTriggerEnter(Collider other) {
        float current_dist = tumor_distance * 100.0f;
        float initial_score = scored_points;
        if (other.gameObject.CompareTag("YellowBigBall")) {
            other.gameObject.SetActive(false);
            scored_points += 0.5f;
            too_close = false;
        }
        if (other.gameObject.CompareTag("YellowSmallBall")) {
            other.gameObject.SetActive(false);
            scored_points += 1.0f;
            too_close = false;
        }
        if (other.gameObject.CompareTag("GreenBigBall")) {
            other.gameObject.SetActive(false);
            scored_points += 2.0f;
            too_close = false;
        }
        if (other.gameObject.CompareTag("GreenSmallBall")) {
            other.gameObject.SetActive(false);
            scored_points += 4.0f;
            too_close = false;
        }
        if (current_dist < 2.025f && current_dist > 0.5f) {
            scored_points -= 1.0f;  
        }
        if (current_dist < 0.5f) {
            scored_points = 0.0f;
        }
        scoreText.text = "Your score: " + scored_points;
        print(scored_points);
    }
}
