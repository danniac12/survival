
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    Heroe heroe;
    public string clor;
    /// <summary>
    ///  se determina las cantidades de zombie y ciudadano que se generarán. 
    ///  e indica la informacion que tendran los ciudadnos como nombre y edad
    /// </summary>
    void Start()
    {

        heroe = new Heroe();
        
        string[] name = new string[]
        { "santiago", "rio", "tere", "troy", "Joe Salinas",
         "Aleesha Harwood","Abdirahman Hendrix","Kaycee Regan","Chantal Barker","Cherise Buckley",
         "Taiba Mcfarland","Sanah Stuart", "Jack Melia", "Pascal Mckenzie","Kelly Rankin",
         "Everly Moore","Muna Cherry","Anya Phelps","Marguerite Fraser","Kali Pennington"
        };
        int zrnd;
        int rasgo;
        zrnd = Random.Range(5, 10);
        for (int i = 0; i < zrnd; i++)
        {
            rasgo = Random.Range(0, 2);
            if(rasgo == 0)
            {
                int crnd = Random.Range(1, 4);
                if (crnd == 1)
                {
                    clor = "Cyan";
                }
                if (crnd == 2)
                {
                    clor = "Magenta";
                }
                if (crnd == 3)
                {
                    clor = "Verde";
                }

                new Zombie(clor);
            }
            if (rasgo == 1)
            {
                int nrnd = Random.Range(0, 20);
                int ernd = Random.Range(15, 101);
                new Aldeano(name[nrnd], ernd);
            }   
        }     
    }

    void Update()
    {
        heroe.Movimiento(heroe.heroMov.position);
    }
}
/// <summary>
/// Se genera gran parte las estancias del lo jugable
/// </summary>

public class Heroe
{
    public Transform heroMov;
    public Heroe()
    {
        GameObject hero = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        heroMov = hero.transform;
        hero.AddComponent<Camera>();
        hero.name = "Heroe";
       
    }

    public Vector3 Movimiento(Vector3 vec)
    {
        vec = heroMov.position;
        if (Input.GetKey(KeyCode.W))
        {
            heroMov.transform.Translate(0, 0, 0.3f);

        }
        if (Input.GetKey(KeyCode.S))
        {
            heroMov.transform.Translate(0, 0, -0.3f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            heroMov.transform.Rotate(0, -1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            heroMov.transform.Rotate(0, 1, 0, 0);
        }
        return vec;
    }

}
/// <summary>
/// Se da Toda la funcion de los zombies
/// </summary>
public class Zombie
{
    /// <summary>
    /// Toma toda 
    /// </summary>
    /// <param name="color">
    /// Se le da un string con los nombres "Cyan, Magenta o Verde", Para darle su color y ademas se crean todas las estancias
    /// </param>
    public Zombie(string color)
    {

        GameObject zesfera = GameObject.CreatePrimitive(PrimitiveType.Cube);
        zesfera.name = "Zombie";
        Renderer zrendere = zesfera.GetComponent<Renderer>();
        float Rx = Random.Range(-10, 10);
        float Ry = Random.Range(-10, 10);
        zesfera.transform.position = new Vector3(Rx, 0, Ry);
        if (color == "Cyan")
        {
            zrendere.material.color = Color.cyan;
        }
        if (color == "Magenta")
        {
            zrendere.material.color = Color.magenta;
        }
        if (color == "Verde")
        {
            zrendere.material.color = Color.green;
        }
        Debug.Log(imprime("Soy un Zombie de color " + color));

    }
    private object imprime(string v)
    {        
        return v;
    }
}

/// <summary>
/// Se toma todo lo de los aldeanos
/// </summary>
public class Aldeano
{
    /// <summary>
    /// Es la estancia de todos los aldeano
    /// </summary>
    /// <param name="nombre">
    /// Se da un nombre dentro de un array
    /// </param>
    /// <param name="edad">
    /// Se da un nombre dentro de un entero
    /// </param>
    public Aldeano(string nombre, int edad)
    {
        GameObject acube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        acube.name = nombre;
        float Rx = Random.Range(-10, 10);
        float Ry = Random.Range(-10, 10);
        acube.transform.position = new Vector3(Rx, 0, Ry);
        Debug.Log(imprime("Hola Soy " + nombre + " y tengo " + edad + " años"));
    }

    private object imprime(string v)
    {
       
        return v;
    }
}