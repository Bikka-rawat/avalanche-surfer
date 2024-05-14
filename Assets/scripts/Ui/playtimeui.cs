using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playtimeui : MonoBehaviour
{
    public Movement movementsc;

    [SerializeField] TextMeshProUGUI speedometertext;

    [SerializeField] TextMeshProUGUI skiglassamount;
    void Start()
    {
        
    }

    void Update()
    {
        speedometertext.text = Mathf.Floor(movementsc.speedometerspeed).ToString();
        setskiglassamount();


    }
    public void setskiglassamount()
    {
        skiglassamount.text = movementsc.skiglassamount.ToString();

        
    }
}
