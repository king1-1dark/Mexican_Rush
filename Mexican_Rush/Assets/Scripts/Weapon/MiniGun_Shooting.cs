using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniGun_Shooting : MonoBehaviour
{
    public Rigidbody2D player;//����� ��� ������ �� ������
    public Transform firePoint;// ������ �������� ����

    public float ShotCounter; //������� ��������� ������ ����
    public float LoadingCounter;// �������� ����� ���������

    public GameObject bulletPrefab;
    public Text invBullet;// ������� ��������
    public Text Reload;

    public int maxAmmo;// ������������ ����� ��������
    public int currentAmmo;
    public float bulletForce = 20;//���� ������
    public float ReloadTime = 5;//�����������

    public bool isReloading = false;

    public bool isShoot;//�������� �� �������

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
        if (!Input.GetButton("Fire1"))
        {
            ShotCounter = 0.1f;
            LoadingCounter = 0.8f;
        }
        
        invBullet.text = currentAmmo.ToString();
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reloading());
        }
        if (Input.GetButton("Fire1") && isShoot == true && currentAmmo > 0)
        {
            LoadingCounter -= Time.deltaTime;
            if(LoadingCounter<=0)
            {
                ShotCounter -= Time.deltaTime;
                if(ShotCounter<=0)
                {
                    ShotCounter = 0.05f;
                    isShoot = false;
                    Shoot();
                }
                
            }
            
        }

    }

    /// <summary>
    /// ����� ��������
    /// </summary>
    void Shoot()
    {
        isShoot = true;
        currentAmmo--;
   
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        player.AddForce(Player_Controller.instance.lookDir * -150f);//���� ������
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); 
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
