using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyboxrotation : MonoBehaviour
{
    [SerializeField] float skyboxrotationvalue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", skyboxrotationvalue);
    }
}
