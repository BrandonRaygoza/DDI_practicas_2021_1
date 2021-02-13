using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ejercicio1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] nums = new int[] {8,1,2,2,3};
        int[] output = countLessThan(nums);

        string result = "[" + string.Join(",", output) + "]";
        Debug.Log("Output: "+result);
    }

    /*
    O(n): Este algoritmo en el mejor de los casos a si como los optimos tiene un orden lineal.
    O(n^2): En el peor de los casos, el algoritmo se comporta de forma cuadratica.
    Asumo que este el orden de mi algoritmo pues hago uso de un método de ordenamiento (bubblesort).
    */
    private int[] countLessThan(int[] nums){

        int[] original = new int[nums.Length];
        int[] output = new int[nums.Length];

        /*Respaldo de los valores originales*/
        for(int i = 0; i<nums.Length; i++){
            original[i]=nums[i];
        }

        /*Ordenar (Bubblesort)*/
        nums = bubbleSort(nums);

        /*Generar arreglo con la cuenta de los elementos menores al valor en su misma pos*/
        for(int i=0; i<nums.Length; i++){
            for(int j = 0; j<nums.Length; j++){
                if(original[i] == nums[j]){
                    output[i]=j;
                    break;
                }
            }
        }

        return output;
    }

    private int[] bubbleSort(int[] array){
        
        for(int i = 0; i<array.Length-1; i++){
            for(int j = 0; j<array.Length-i-1; j++){ /*-i, porque se eleva el elemento mas grande hasta el final del arreglo.*/
                if(array[j+1]<array[j]){              /*Por eso por cada pasada, se ira haciendo mas "pequeño" el arrelgo para reducir la busqueda,*/
                    int swap = array[j+1];           /*pues los elementos del final, ya estan acomodados como los mas grandes*/
                    array[j+1]=array[j];
                    array[j]=swap;
                }
            }  
        }

        return array;
    }
}
