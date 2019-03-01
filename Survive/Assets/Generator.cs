using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    Heroe ero = new Heroe();
    Citizen citizen = new Citizen();
    Zombie zombie = new Zombie();
    
    
    string[] Name = new string[]     
    { "santiago", "rio", "tere", "troy", "Joe Salinas",
      "Aleesha Harwood","Abdirahman Hendrix","Kaycee Regan","Chantal Barker","Cherise Buckley",
      "Taiba Mcfarland","Sanah Stuart", "Jack Melia", "Pascal Mckenzie","Kelly Rankin",
      "Everly Moore","Muna Cherry","Anya Phelps","Marguerite Fraser","Kali Pennington"
    };
    /// <summary>
    ///  se determina las cantidades de zombie y ciudadano que se generarán. 
    ///  e indica la informacion que tendran los ciudadnos como nombre y edad
    /// </summary>
    void Start()
    {
        ero.hero = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        ero.hero.AddComponent<Camera>();
        int rnd = UnityEngine.Random.Range(4, 10);
        

        for (int i = 0; i < rnd; i++)
        {
            int age = UnityEngine.Random.Range(15, 100);
            int nom = UnityEngine.Random.Range(0, 19);
            int forme = UnityEngine.Random.Range(0, 2);
            if (forme == 0)
            {
               
                citizen.City(Name[nom],age);
                
            }
            else
            {
                zombie.Zomb();
            }
                
        }
    }

   

    void Update()
    {
        ero.Movimiento();
    }
  
}


// Update is called once per frame

/// <summary>
/// Se genera gran parte las estancias del lo jugable
/// </summary>
public class Heroe
{
    public GameObject hero;

 
    public void Movimiento()
    {
       
        if (Input.GetKey(KeyCode.W))
        {
            hero.transform.Translate(0,0,0.3f);

        }
        if (Input.GetKey(KeyCode.S))
        {
            hero.transform.Translate(0, 0, -0.3f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            hero.transform.Rotate(0, -1, 0,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            hero.transform.Rotate(0,1, 0, 0);
        }
       
    }
    
}
/// <summary>
/// genera al los ciudadanos 
/// </summary>
 public class Citizen
 {
    GameObject body;
  
    public void City (string name, int age)
    {
        body = GameObject.CreatePrimitive(PrimitiveType.Cube);
        float x = UnityEngine.Random.Range(-10,10);
        float z = UnityEngine.Random.Range(-10, 10);
        body.transform.position = new Vector3(x, 0, z);
        Debug.Log("Hola soy "+ name +" y tengo "+ age + " años");
      
    }
 }
/// <summary>
/// genera los zombies y les asigna un color 
/// </summary>
public class Zombie
{
    GameObject body;
    public void Zomb()
    {
        int cambio = UnityEngine.Random.Range(1, 4);
        if(cambio == 1)
        {
            body = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Renderer color = body.GetComponent<Renderer>();
            color.material.color = Color.green;
            Debug.Log("Soy un Zombie de color" + " Verde");
        }
        if(cambio == 2)
        {
            body = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Renderer color = body.GetComponent<Renderer>();
            color.material.color = Color.cyan;
            Debug.Log("Soy un Zombie de color" + " Cyan");
        }
        else
        {
            body = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Renderer color = body.GetComponent<Renderer>();
            color.material.color = Color.magenta;
            Debug.Log("Soy un Zombie de color" + " Mangeta");
        }

        
        float x = UnityEngine.Random.Range(-10, 10);
        float z = UnityEngine.Random.Range(-10, 10);
        body.transform.position = new Vector3(x, 0, z);
    }
}