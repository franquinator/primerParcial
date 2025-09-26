using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private int tamañoInicialDeHorda = 2;
    [SerializeField]
    private int aumentoDeEnemigosPorOleada = 2;

    [SerializeField]
    private float alturaMax;
    [SerializeField]
    private float alturaMin;
    [SerializeField]
    private float positionX;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float TiempoMinimo;
    [SerializeField]
    private float TiempoMaximo;


    [SerializeField]
    private float TiempoEntreEnemigos;

    [SerializeField]
    private float segundosEntreOleadas;
    [SerializeField]
    private int cantDeOleadas;

    private float TiempoDesdeElUltimoEnemigo;
    private int enemigosEnPantalla;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(CrearHorda());
        StartCoroutine(CrearOleadas());
    }
    private void OnDrawGizmos()
    {
        Vector2 From = new(positionX, alturaMin);
        Vector2 to = new(positionX, alturaMax);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(From, to);
    }
    private void CrearEnemigo()
    {
        float positionY = Random.Range(alturaMin, alturaMax);
        Instantiate(enemy, new Vector2(positionX, positionY), enemy.transform.rotation, transform);
    }
    private void Update()
    {
        TiempoDesdeElUltimoEnemigo += Time.deltaTime;
        if (TiempoDesdeElUltimoEnemigo > TiempoEntreEnemigos && transform.childCount < enemigosEnPantalla)
        {
            CrearEnemigo();
            TiempoDesdeElUltimoEnemigo = 0;
        }
    }
    private IEnumerator CrearOleadas()
    {
        StartCoroutine(AumentarEnemigosEnPantalla(tamañoInicialDeHorda));
        for (int i = 0; i < cantDeOleadas-1; i++)
        {
            yield return new WaitForSeconds(segundosEntreOleadas);
            StartCoroutine(AumentarEnemigosEnPantalla(aumentoDeEnemigosPorOleada));
        }
    }
    private IEnumerator AumentarEnemigosEnPantalla(int CantEnemigos)
    {
        for (int i = 0; i < CantEnemigos; i++)
        {
            enemigosEnPantalla++;
            yield return new WaitForSeconds(Random.Range(TiempoMinimo, TiempoMaximo));
        }
    }
}
