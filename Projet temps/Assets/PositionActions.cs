using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.XR;


public class PositionActions : MonoBehaviour

{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    UnityEngine.Vector3 headPosition = transform.position;

        
    }
    void FixedUpdate()
    {
        UnityEngine.Vector3 headPosition = transform.position;
        double distance = Vector3.Distance(headPosition, new Vector3(0, 0, 0));
        if (GameManager.Instance.count_max_distances == GameManager.Instance.Max_distances.Count-1)
        {GameManager.Instance.Max_distances = GameManager.Instance.shuffle(GameManager.Instance.Max_distances);
        GameManager.Instance.count_max_distances =0;
        if (distance > GameManager.Instance.Max_distances[GameManager.Instance.count_max_distances])
        {
         GameManager.Instance.GoBack();
        }
        }
    }
}   
