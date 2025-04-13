using UnityEngine;

public class CajaSimple : MonoBehaviour
{
    public GameObject monedaPrefab;
    public Transform puntoSpawn;
    private bool usada = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (usada) return;

        if (collision.collider.CompareTag("Player"))
        {
            // Golpe desde abajo
            if (collision.contacts[0].normal.y > 0.5f)
            {
                usada = true;
                if (monedaPrefab != null && puntoSpawn != null)
                    Instantiate(monedaPrefab, puntoSpawn.position, Quaternion.identity);
            }
        }
    }
}
