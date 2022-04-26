using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class PowerupManager : MonoBehaviour
{
  
  [SerializeField]
  private GameObject[] powerupArray;

  private int nbPowerups;


  private void Awake()
  {
    Init();
  }


  private void Init()
  {
    nbPowerups = powerupArray.Length;
  }


  private int GetRandomPowerupIndex()
  {
    return Random.Range(0, nbPowerups);
  }
  
  
  
  
  
}
