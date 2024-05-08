using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject prefabBala;
    public Transform spanwArma;
    public float fuerza;
    public int municionActual = 25;
    public int municionMax = 25;

    public void Disparar()
    {
        if (municionActual > 0)
        {
            GameObject bala = Instantiate(prefabBala, spanwArma.position, spanwArma.rotation);
            bala.GetComponent<Rigidbody>().velocity = new Vector3() * fuerza;

        }

    }
    public void Recargar()
    {

    }
}
