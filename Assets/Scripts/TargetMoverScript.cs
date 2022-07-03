using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class TargetMoverScript : MonoBehaviour
{
    public float Speed = 5;
    public float Multiplier = 3;

    // Update is called once per frame
    void Update()
    {
        var actualSpeed = Speed;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            actualSpeed *= Multiplier;
        }
        
        var newPos = transform.position.x + (actualSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        transform.position = new Vector3(newPos, transform.position.x, transform.position.y);
    }
}
