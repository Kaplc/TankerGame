using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target; // 目标
    public float targetHeight; // 跟随目标高度
    public float targetAngle; // 跟随的角度(绕y轴)
    public float distance = 10.0f; // 跟随的距离

    public float distanceSpeed; // 改变跟随距离速度
    public float distanceMin = 5.0f; // 最小跟随距离
    public float distanceMax = 15.0f;

    public float lookAtSpeed = 5.0f; // 看向速度
    public float roundSpeed = 5.0f; // 

    public Vector3 nowPos;
    public Vector3 nowRotation;
    

    // Update is called once per frame
    void LateUpdate()
    {
        distance += -Input.GetAxis("Mouse ScrollWheel") * distanceSpeed; // 滚轮控制跟随距离
        distance = Mathf.Clamp(distance, distanceMin, distanceMax); // 限制跟随距离

        nowPos = target.position + Vector3.up * targetHeight; // 设置目标位置高度 向量*距离=模长 => 模长+位置=新位置
        // 四元数*向量=旋转后的向量
        nowRotation = Quaternion.AngleAxis(targetAngle, target.transform.up) * -transform.forward; // 将向后向量旋转对应角度
        
        nowPos += nowRotation * distance; // 最终位置
        // 差值运算赋值
        transform.position = Vector3.Lerp(transform.position, nowPos, Time.deltaTime * roundSpeed); // 位置
        
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.forward), Time.deltaTime * lookAtSpeed);
        // transform.rotation = target.rotation;
    }
}