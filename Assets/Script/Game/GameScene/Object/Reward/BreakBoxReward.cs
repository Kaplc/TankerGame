using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BreakBoxReward : MonoBehaviour
{
    public List<BaseReward> listRewards = new List<BaseReward>();
    public GameObject breakEff;

    private void OnTriggerEnter(Collider other)
    {
        var pos = transform.position;
        var rota = transform.rotation;
        Destroy(gameObject);
        // 随机生成奖励
        if (Random.Range(0, 100) >= 30)
        {
            Instantiate(listRewards[Random.Range(0, listRewards.Count)], new Vector3(pos.x, pos.y + 1, pos.z), rota);
        }

        // 破坏特效
        GameObject eff = Instantiate(breakEff, pos, rota);
        // 修改音效
        AudioSource audioSource = eff.GetComponent<AudioSource>();
        audioSource.volume = BaseDataManage.Instance.musicData.soundValue;
        audioSource.mute = !BaseDataManage.Instance.musicData.soundOpen;
        // 销毁特效
        Destroy(eff, 2);
    }
}