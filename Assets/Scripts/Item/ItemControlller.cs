using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class ItemControlller : NetworkBehaviour
{
    public float rotationSpeed = 100f;
    public override void FixedUpdateNetwork()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
    
}
