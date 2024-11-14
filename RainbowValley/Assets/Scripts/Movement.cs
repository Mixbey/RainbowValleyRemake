using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void Move(Transform modifier, Vector3 dir, float spd)
    {
        modifier.position += dir * Time.deltaTime * spd;
    }
}
