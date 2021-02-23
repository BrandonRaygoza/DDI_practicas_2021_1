using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findStudent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string [] students = {"Brandon","Cristina","Juan","Pedro","Michael","Mechel"};
        string target = "Brandon";

        Debug.Log("Sin ordenar: "+"\n");
        printList(students);

        /*El método de ordenamiento que utiliza c# depende del tamaño del arreglo (n), puede ser: 
        n<= 16 ->       Insertionsort   -> complejidad de tiempo: O(n)
        n > 2*log^n->   Heapsort        -> complejidad de tiempo: O(n log n)
        Ultimo recurso: Quicksort       -> complejidad de tiempo: O(n Log n)*/
        Array.Sort(students);               /*Ordena los elementos del arreglo por orden alfabetico (toma el valor ascii)*/
        Debug.Log("Ordenados: "+"\n");  
        printList(students);            

        if(find_student(students,target))
            Debug.Log("Inscrito");
        else
            Debug.Log("No inscrito");
    }

    /*Funcion que utilizar busqueda binaria para encontrar un elemento dentro del arreglo ya ordenado

    Complejidad de tiempo del algoritmo: O(Log n)*/
    private bool find_student(string[] students, string target){

        int index = Array.BinarySearch(students,target);

        if(index < 0)       /*Si no encontro el elemento: (-1)*/
            return false;
        else
            return true;
    }

    void printList(string[] students){
        for(int i = 0; i<students.Length; i++){
            Debug.Log("Output: "+ students[i]);
        }
    }

}
