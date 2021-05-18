using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed; //�������� ������

    private Vector3 offset;
    private Vector3 targetPos;

    void Start()
    {
        if (target == null) return;

        offset = transform.position - target.position;
    }

    void Update()
    {
        if (target == null)return;

        targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }
}
