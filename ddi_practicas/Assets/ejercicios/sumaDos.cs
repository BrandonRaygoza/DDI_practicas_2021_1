using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sumaDos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] nums={21,7,14,25,2,2};
        int target = 21;
        
        Array.Sort(nums);                   //Ordenar arreglo 
        printArray(SumaDos(nums,target));  
    }

    /*Time complexity = O(n^2)*/
    public int[] SumaDos(int[] nums, int target){

        int[] output = new int[2];                  //la salida siempre son dos elementos
        bool flag = false;
        int index = FalseBinarySearch(nums,target); //Encontrar el primer elemento que sea mas grande a mi target

        //buscar numeros que sumen
        for(int i=0; i<index; i++){
            for(int j=i+1; j<index; j++){
                if( (nums[i]+nums[j]) == target && flag == false){
                    output[0]=i;
                    output[1]=j;
                    flag = true;        //para que se quede con el primero que encuentre
                    break;
                }
            }
        }

        return output;
    }

    //Busca el elemento si esta, sino, retorna el ultimo limite inferior
    //esto lo hago para reducir el tamaño del arreglo al momento sumar elementos
    //proc de abajo lo saque de www.geeksforgeeks.com, y le agregue dos ifs
    public int FalseBinarySearch(int[] arr, int x){
        int l = 0, r = arr.Length - 1; 
        while (l <= r) { 
            int m = l + (r - l) / 2; 
  
            // Check if x is present at mid 
            if (arr[m] == x) 
                return m; 
  
            // If x greater, ignore left half 
            if (arr[m] < x) 
                l = m + 1; 
  
            // If x is smaller, ignore right half 
            else
                r = m - 1; 
        } 

        // if we reach here, then element was 
        // not present
        if(l == 0){
            return r;
        }else{
            return l;
        }

    }

    /*Este busca uno por uno un elemento mayor al target*/
    public int FirsIndexGreater(int[] nums, int target){
        int i=0;
        for(i=0; i<nums.Length; i++){
            if(nums[i]>target){
                return i;
            }      
        }  

        return i-1; //si no hubo ninguno mas grande, pues agarra el ultimo elemento
    }

    void printArray(int[] nums){
        for(int i = 0; i<nums.Length; i++){
            Debug.Log("Output: "+ nums[i]);
        }
    }
}
