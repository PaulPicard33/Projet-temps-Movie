using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.XR;

public class PositionActions : MonoBehaviour

{
    // Start is called before the first frame update
    public Transform vrHeadset;
    public bool isSitting; // if the person is seated 
    public bool EndOfRoad;// if the head is in the end of the road
    public bool record; //  record the position of the head
    void Start()
    {if (vrHeadset==null)
    {
        vrHeadset = Camera.main.transform;
    }
        
    }

    // Update is called once per frame
    void Update()
    {
    UnityEngine.Vector3 headPosition = vrHeadset.position;

        
    }
    void FixedUpdate()
    {
        UnityEngine.Vector3 headPosition = vrHeadset.position;
        double distance = Vector3.Distance(headPosition, new Vector3(0, 0, 0));

        if (distance < 5f)
        {
         GameManager.Instance.GoBack();
        }
    }
}   
