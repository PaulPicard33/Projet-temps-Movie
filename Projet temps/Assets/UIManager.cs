using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.VoiceSDK.UX;
using TMPro;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField Text_Date_person;
    public TMP_Dropdown CoolDown;
    public TMP_Dropdown CountDown;
    public TMP_InputField Limitmax;
    public TMP_InputField Limitmin;
    public TMP_Dropdown D_level;
    public TMP_Text Trials;
    public TMP_InputField NumberOfTrials;
    public Button ResetButton;

    void Start()
    {
        Trials.text = "Trials: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
        {

        }
     public  void ChangeText_Trials()
    {
        Trials.text = "Trials: " + GameManager.Instance.trials.ToString();
    }
    
    public float generateCoolDown()
    {   
        string output  = CountDown.options[CountDown.value].text;
         float min = output[0];
         float max  = output[2];
         return UnityEngine.Random.Range(min, max);
         
    }
    public List<double> Distance_list()
    {   
        int i;
        List<double> output = new List<double>();
        int output_max = int.Parse(Limitmax.text[0].ToString());
        int output_min = int.Parse(Limitmin.text[0].ToString());
        for (i = output_min; i < output_max; i++)
        {   
            double half = i + 0.5;               
            output.Add(i);
            output.Add(half);
        }
        output.Add(output_max);
        return output;
        
    }
    
}
    


