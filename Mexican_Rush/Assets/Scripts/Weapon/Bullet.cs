using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bullet : MonoBehaviour
{
    /// <summary>
    /// Метод на Счетчик очков
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "10Points")
        {
            Score_Manager.instance.Add10Point();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "25Points")
        {
            Score_Manager.instance.Add25Point();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "50Points")
        {
            Score_Manager.instance.Add50Point();
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
