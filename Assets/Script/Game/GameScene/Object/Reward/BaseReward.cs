using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseReward : MonoBehaviour
{
    public int RotationSpeed = 100;

    public GameObject effectPrefbs;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Round()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * RotationSpeed));
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        GameObject eff = Instantiate(effectPrefbs, transform.position, transform.rotation);
        AudioSource audioSource = eff.GetComponent<AudioSource>();
        audioSource.volume = BaseDataManage.Instance.musicData.soundValue;
        audioSource.mute = !BaseDataManage.Instance.musicData.soundOpen; ;
        Destroy(eff, 1);
        Destroy(gameObject);
    }
}
