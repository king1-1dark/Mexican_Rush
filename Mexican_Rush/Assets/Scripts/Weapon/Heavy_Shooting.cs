using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Heavy_Shooting : MonoBehaviour
{
    public Rigidbody2D player;// Нужен для отдачи от оружия

    public Transform firePoint1;// Откуда вылетают пули
    public Transform firePoint2;

    public GameObject bulletPrefab;
    public Text invBullet;// Счетчик магазина 
    public Text Reload;

    public int maxAmmo;// Максимальный объем магазина
    public int currentAmmo;
    public float bulletForce = 30;// Сила вылета пули
    public float ReloadTime = 3;//Перезарядка

    public bool isReloading = false;

    public bool isShoot;// Проверка на выстрел

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
    /// Метод Выстрела
    /// </summary>
    void Shoot()
    {
        currentAmmo--;
        isShoot = true;

        GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);

        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();

        player.AddForce(Player_Controller.instance.lookDir * -500f); //Сила отдачи от дробовика
        rb1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Метод Перезарядки
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
