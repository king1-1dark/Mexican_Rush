using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Heavy_Shooting : MonoBehaviour
{
    public Rigidbody2D player;// ����� ��� ������ �� ������

    public Transform firePoint1;// ������ �������� ����
    public Transform firePoint2;

    public GameObject bulletPrefab;
    public Text invBullet;// ������� �������� 
    public Text Reload;

    public int maxAmmo;// ������������ ����� ��������
    public int currentAmmo;
    public float bulletForce = 30;// ���� ������ ����
    public float ReloadTime = 3;//�����������

    public bool isReloading = false;

    public bool isShoot;// �������� �� �������

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
    }
    void Update()
    {
        Reload.gameObject.SetActive(false);
        invBullet.text = currentAmmo.ToString();
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reloading());
            
        }
        if (Input.GetButtonDown("Fire1") && isShoot == true && currentAmmo > 0)
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
        currentAmmo--;
        isShoot = true;

        GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);

        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();

        player.AddForce(Player_Controller.instance.lookDir * -500f); //���� ������ �� ���������
        rb1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// ����� �����������
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
