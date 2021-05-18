using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Points : MonoBehaviour
{
    public GameObject[] Points;
    public float spawnTime; //����� ���������
    public float repeatTime; //����� ����� ����� ��������� �����
    public Transform spawnPoints;
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, repeatTime);
    }
    void Spawn()
    {
        int pointLenght = Random.Range(0, Points.Length);
        Instantiate(Points[pointLenght], spawnPoints.position, spawnPoints.rotation);
    }
}
