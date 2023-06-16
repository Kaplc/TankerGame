using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10;

    public GameObject effectPrefbs;
    public GameObject father; // 发射对象

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (Speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Walls"))
        {
            // 特效
            GameObject effObj = Instantiate(effectPrefbs, transform.position, transform.rotation);
            Destroy(effObj, 1);
            // 音效
            AudioSource audioObj = Instantiate(audioSource, transform.position, transform.rotation);
            audioObj.GetComponent<AudioSource>().volume = BaseDataManage.Instance.musicData.soundValue;
            audioObj.GetComponent<AudioSource>().mute = !BaseDataManage.Instance.musicData.soundOpen;
            Destroy(audioObj, 1);
            
            Destroy(gameObject);
        }
    }
}