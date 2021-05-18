using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shooting : MonoBehaviour
{
    public Transform firePoint; // Откуда вылетают объекты Пули
    public GameObject bulletPrefab;
    public Text invBullet; // Счетчик магазина оружия
    public Text Reload;

    public int maxAmmo; // Максимальный объем магазина
    public int currentAmmo;

    public float bulletForce = 20; //Сила вылета пули
    public float ReloadTime = 1; //Перезарядка

    public bool isReloading = false;

    public bool isShoot; // Проверка на выстрел

    void Start()
    {
        currentAmmo = maxAmmo;    
    }

    /// <summary>
    /// Метод останавливающий перезардку, при выборе след орудий
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
    /// Метод Выстрела
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
    /// Метод Перезарядки с отставанием
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
