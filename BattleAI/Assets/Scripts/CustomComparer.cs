using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomComparer : IEqualityComparer<GameObject>
{

    public bool Equals(GameObject first, GameObject second)
    {
        return first.GetComponent<Transform>().position.x == first.GetComponent<Transform>().position.x && first.GetComponent<Transform>().position.z == first.GetComponent<Transform>().position.z;
    }

    public int GetHashCode(GameObject obj)
    {
        return obj.GetHashCode();
    }


}
