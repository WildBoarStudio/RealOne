using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private float cloudSpeed = 0.1f;
    [SerializeField] private float cloudSize;
    void Start()
    {//gets all different type of variables to make cloud fit game
        float cloudFactor = Random.Range(1, cloudSize);
        float cloudRotation = Random.Range(0, 360);
        Vector3 cloudVector = new Vector3(cloudFactor, cloudFactor, cloudFactor);
        transform.localScale = cloudVector;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,cloudRotation));

    }

    // Update is called once per frame
    void Update()
    {//moves cloud forward after getting default values from start
        this.transform.position += transform.forward * cloudSpeed * Time.deltaTime;
    }
}
