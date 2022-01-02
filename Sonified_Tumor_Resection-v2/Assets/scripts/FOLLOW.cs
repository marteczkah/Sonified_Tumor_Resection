using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOLLOW : MonoBehaviour
{

    public Transform targ;
    Vector3 direction;
    public float speeed = 4.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        direction = (targ.position - transform.position).normalized;
        if ((targ.position - transform.position).magnitude > 0.1)
            transform.Translate(direction * Time.deltaTime * speeed);

    }
}
