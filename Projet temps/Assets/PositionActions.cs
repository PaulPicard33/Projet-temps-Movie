using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.XR;


public class PositionActions : MonoBehaviour

{
    // Start is called before the first frame update
    public Transform vrHeadset;
    public UIManager UImanager;
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
        if (GameManager.Instance.count_max_distances == UImanager.Distance_list().Count)
        {GameManager.Instance.Max_distances = GameManager.Instance.shuffle(GameManager.Instance.Max_distances);
        GameManager.Instance.count_max_distances =0;
        if (distance > GameManager.Instance.Max_distances[GameManager.Instance.count_max_distances])
        {
         GameManager.Instance.GoBack();
        }
        }
    }
}   
