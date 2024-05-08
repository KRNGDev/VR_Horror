using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Boton : MonoBehaviour
{
    public Color color;
    public Color color2;
    public AudioClip musica;
    public string interactorObjectName;
    bool encendido = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == interactorObjectName)
        {
            if (!encendido)
            {
                GetComponent<MeshRenderer>().material.color = color;
                GetComponent<AudioSource>().PlayOneShot(musica);
                encendido = true;
            }
            else
            {
                GetComponent<MeshRenderer>().material.color = color2;
                GetComponent<AudioSource>().Stop();
                encendido = false;
            }
        }
    }
}

