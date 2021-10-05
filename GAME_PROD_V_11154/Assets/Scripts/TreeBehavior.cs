using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehavior : MonoBehaviour
{
   
    private void Update()
    {
        if (Mathf.Abs(GameControl.ship_Transform.position.magnitude - transform.position.magnitude) > 20)
        {
            ThrowBackInPool();
        }
    }
    public void OnTakeFromPool(Vector3 pos)
    {
        GameControl.Occupied_pos.Add(pos);
        transform.position = pos;
        gameObject.SetActive(true);
    }

    public void ThrowBackInPool()
    {
        GameControl.Occupied_pos.Remove(this.transform.position);
        gameObject.SetActive(false);
    }
}
