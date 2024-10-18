using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //singleton instance
    public static GameManager Instance;
    public string state; //game state
    public bool EndOfRoad;
    public bool StartWalking;
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
        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
            Debug.Log("Activation de l'écran : " + i);
        }
        
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
     //envoyer un son dans le casque pour dire de revenir en arrière 
    
    EndOfRoad =true;
     // créer la vision de la fin de la course avec un mur ou quelque chose    
    }
    public void GoForward()
    {
        //envoyer un son dans le casque pour dire de commencer à marcher 
        StartWalking = true;
    }

}
