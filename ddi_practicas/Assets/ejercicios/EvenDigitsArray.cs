using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvenDigitsArray : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        int[] nums = {10,12,345,2,6,7896};
        
        Array.Sort(nums);
        Debug.Log("Numeros con digitos par: "+evenDigitsOfNumberInArray_1(nums));
    }

    /*Evita realizar modulo de cada elemento, y solo cuenta aquellos valores menos a una base con digitos 
    impar (e.j, cualquiera menor a 100 (base con digitos impar) pero mayor o igual a 10 es contada).
    Es necesario que el arreglo este ordenado*/
    int evenDigitsOfNumberInArray_1(int[] nums){
        int basex = 10, counter = 0;

        for(int i = 0; i<nums.Length; i++){
            if(nums[i] >= basex){               //eleva la base base (e.j 10*10)
                basex*=10;
            }

            if(numberOfDigits(basex)%2 != 0){   //Si la base tiene digitos impar, cuenta todos los que estan debajo
                if(nums[i]<basex){              //e.j, base = 100, del 11 al 99 son digitos par
                    counter++;
                }
            }
        }

        return counter;
    }

    int evenDigitsOfNumberInArray_2(int[] nums){
        int counter=0;

        for(int i = 0; i<nums.Length; i++){
            if(numberOfDigits(nums[i])%2 == 0){
                counter ++;
            }
        }

        return counter;
    }


    int numberOfDigits(int num){
        int i = 0;
        while((num / 10) > 0){
            num = num/10;
            i++;
        }

        return i+1;
    }

    
}
