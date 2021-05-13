using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Shader crt;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.SetReplacementShader(crt, "Transparent");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
