using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] nums={2,7,11,15};
        int target = 9;

        Debug.Log("Sin ordenar: "+"\n");
        printArray(nums);
    }

    void printArray(int[] nums){
        for(int i = 0; i<nums.Length; i++){
            Debug.Log("Output: "+ nums[i]);
        }
    }
}
