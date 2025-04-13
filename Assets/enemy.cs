using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2f;

    private Transform objetivoActual;

    void Start()
    {
        objetivoActual = puntoB;
    }

    void Update()
    {
        // Mover hacia el objetivo actual
        transform.position = Vector3.MoveTowards(transform.position, objetivoActual.position, velocidad * Time.deltaTime);

        // Revisar si ya llegó
        if (Vector3.Distance(transform.position, objetivoActual.position) < 0.1f)
        {
            // Cambiar el objetivo
            objetivoActual = (objetivoActual == puntoA) ? puntoB : puntoA;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.contacts[0].normal.y < -0.5f)
        {
            //life -= 1;
            Destroy(gameObject);
            Debug.Log("Enemy");

        }

    }
}
