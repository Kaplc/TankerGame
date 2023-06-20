using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10;

    public GameObject effectPrefbs;
    public BaseTank fatherTank; // 发射对象

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
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
            // // 音效
            // AudioSource audioSource = GetComponent<AudioSource>();
            // audioSource.volume = BaseDataManage.Instance.musicData.soundValue;
            // audioSource.mute = !BaseDataManage.Instance.musicData.soundOpen;
            // Destroy(audioSource, 1);

            Destroy(gameObject, 1);
        }
    }

    public void SetFatherTank(BaseTank Tank)
    {
        fatherTank = Tank;
    }
}