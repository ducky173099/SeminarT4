using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLifeDestroyer : MonoBehaviour
{
    public float LifeTime = 2f; //time delay de destroy gameobject

    private void Start()
    {
        Destroy(this.gameObject, LifeTime);
    }
}
