using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3Behavior : MonoBehaviour
{
    public void DestroyObject()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
