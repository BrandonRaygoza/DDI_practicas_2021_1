using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNumber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] nums = {1,2,2,4,4};
        Array.Sort(nums);

        int wea = findNumber(nums);
        Debug.Log("El numero que no se repite es: "+nums[wea]);
    }


    int findNumber(int[] nums){
        int i=0, flag = 0;
        for(i = 0; i<nums.Length-1; i++){

            if( (nums[i] != nums[i+1]) ){   //Pregunta su vecino de adelante

                if(i == 0){                //¿Eres el primer elemento?
                    return i;
                }

                if( (nums[i]!= nums[i-1]) ){    //Pregunta por su vecino de la izquierda
                    return i;
                }
            }
        }

        return i;
    }
}
