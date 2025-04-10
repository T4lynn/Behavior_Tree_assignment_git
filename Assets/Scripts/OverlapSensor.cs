using JetBrains.Annotations;
using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapSensor : MonoBehaviour
{

    public float radius;
    Vector3 sphereRadius;
    public BBParameter<bool> sensedPlayer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        sphereRadius = new Vector3(radius, radius, radius) + transform.position;
        //Debug.DrawLine(transform.position, sphereRadius);
       if ( Physics.OverlapSphere(transform.position, radius).Length > 0 )
        {
            Debug.Log("Player in sphere");

            sensedPlayer.value = true;
        } else { Debug.Log("player out of sphere");  sensedPlayer.value= false; }
    }
}
