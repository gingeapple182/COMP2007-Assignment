using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeFall : MonoBehaviour
{
    private Animator bridgeAnim;
    //private bool bridgeFallen = false;

    // Start is called before the first frame update
    void Start()
    {
        bridgeAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bridgeAnim.SetTrigger("BridgeFall");
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (bridgeFallen == false)
    //    {
    //        bridgeAnim.Play("BridgeFall");
    //        print("Bridge fell");
    //        bridgeFallen = true;
    //    }
    //}
}
