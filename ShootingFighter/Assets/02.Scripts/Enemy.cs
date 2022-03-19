using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*private void OnCollisionEnter(Collision collision)
    {
        *//*collsion.gameObject.GetComponent<Player>().Hurt();
        Destroy(gameObject);*//*
        if(collision.gameObject == null)
        {
            Debug.Log(collision.gameObject.name);
        }*//*

        Debug.Log($"collieded! {collision.gameObject.name}");


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"triggerd! {other.gameObject.name}");
    }*/


    /*private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }*/

    public GameObject destroyEffect;
    private void OnDestroy()
    {
        // 여기서 Instantiate는 안된다.
    }


    public void DoDestroyEffect()
    {
        GameObject go = Instantiate(destroyEffect,transform.position, Quaternion.identity);
        Destroy(go,3);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }


}
 