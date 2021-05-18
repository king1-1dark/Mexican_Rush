using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shooting : MonoBehaviour
{
    public Transform firePoint; // ������ �������� ������� ����
    public GameObject bulletPrefab;
    public Text invBullet; // ������� �������� ������
    public Text Reload;

    public int maxAmmo; // ������������ ����� ��������
    public int currentAmmo;

    public float bulletForce = 20; //���� ������ ����
    public float ReloadTime = 1; //�����������

    public bool isReloading = false;

    public bool isShoot; // �������� �� �������

    void Start()
    {
        currentAmmo = maxAmmo;    
    }

    /// <summary>
    /// ����� ��������������� ����������, ��� ������ ���� ������
    /// </summary>
    void OnEnable()
    {
        isReloading = false;
    }
    void Update()
    {
        Reload.gameObject.SetActive(false);
        invBullet.text = currentAmmo.ToString();
        if(currentAmmo <= 0)
        {
            StartCoroutine(Reloading());
        }
        if(Input.GetButtonDown("Fire1") && isShoot == true && currentAmmo > 0)
        {
            isShoot = false;
            Shoot();
        }
        
    }
    /// <summary>
    /// ����� ��������
    /// </summary>
    void Shoot()
    {
        isShoot = true;
        currentAmmo--;
        
        GameObject bullet =Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb =bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    /// <summary>
    /// ����� ����������� � �����������
    /// </summary>
    /// <returns></returns>
    IEnumerator Reloading()
    {
        isReloading = true;
        Reload.gameObject.SetActive(true);
        yield return new WaitForSeconds(ReloadTime);
        currentAmmo = maxAmmo; 
        isReloading = false;
    }
}
