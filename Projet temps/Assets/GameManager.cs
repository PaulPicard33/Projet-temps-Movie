using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //singleton instance
    public static GameManager Instance;
    void Awake(){
        if(Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
