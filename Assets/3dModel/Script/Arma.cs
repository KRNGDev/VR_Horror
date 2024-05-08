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
    public bool balasInfinitas = true;
    public void ApretarGatillo()
    {
        if (municionActual > 0 || balasInfinitas == true)
        {
            Disparar();
        }
    }
    public void Disparar()
    {
        if (municionActual > 0 || balasInfinitas == true)
        {
            GameObject bala = Instantiate(prefabBala, spanwArma.position, spanwArma.rotation);
            bala.GetComponent<Rigidbody>().AddForce(spanwArma.transform.forward * fuerza);

        }

    }
    public void Recargar()
    {

    }
}
