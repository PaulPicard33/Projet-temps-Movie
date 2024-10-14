using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //singleton instance
    public static GameManager Instance;
    public string state; //game state
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
        switch (state)
        {   case("seated1"):




                break;
            case("Forward"):
            
            
                break;
            case ("Backward"):


                break;


            case("seated 2"):


                break;

            case("visualisation"):

                break;
        }
    
    }
    void FixedUpdate(){
        
    }

    public void GoBack()
    {
        
    }
}
