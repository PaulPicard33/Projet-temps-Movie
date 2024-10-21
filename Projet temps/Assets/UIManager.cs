using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField Text_Date_person;
    public Dropdown CoolDown;
    public Dropdown CountDown;
    public Dropdown Limitmax;
    public Dropdown Limitmin;
    public Dropdown D_level;
    public TMP_Text Trials;

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
         return Random.Range(min, max);
         
    }
    public List<double> Distance_list()
    {   double i;
        
        int output_max = Limitmax.options[Limitmax.value].text[0];
        int output_min = Limitmin.options[Limitmin.value].text[0];
        for (i = output_min; i < output_max; i++)
        {   List<double> output;
            double half = i + 0.5;               
            output.Add(i);
            output.Add(half);
        }
        return();
    }
}

