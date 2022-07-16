using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatScript : MonoBehaviour
{
    
    [SerializeField] private float levitateSpeed;
    [SerializeField] private float levitateHeight = 2f;
    [SerializeField] private float levitateStartHeight;
    [SerializeField] private bool hasReachedTop = false;

    private void Start()
    {
        levitateSpeed = Random.Range((float)0.001, 1);
        levitateStartHeight = transform.position.y;
    }

    void Update()
    {
        if(!hasReachedTop)
        {
            transform.position += new Vector3(0, (float)0.01 * levitateSpeed, 0);
        }
        else
        {
            transform.position -= new Vector3(0, (float)0.01 * levitateSpeed, 0);
        }

        if(transform.position.y> levitateStartHeight + levitateHeight)
        {
            hasReachedTop = true;
        }
        if(transform.position.y< levitateStartHeight - levitateHeight)
        {
            hasReachedTop = false;
        }
        
    }
}
