using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class FishSpawner : MonoBehaviour
{
    
    
    void Awake()
    {
        for (int i = 0; i < fishTypes.Length; i++)
        {
            int num = 0;
            while (num < fishTypes[i].fishCount)
            {
                Fish fish = Instantiate<Fish>(fishPrefab);
                fish.Type = fishTypes[i];
                fish.ResetFish();
                num++;
            }
        }    
    }

    void Update()
    {
        
    }
    [SerializeField]
    private Fish fishPrefab;
    [SerializeField]
    private Fish.FishType[] fishTypes;


}
