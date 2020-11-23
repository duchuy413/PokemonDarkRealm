using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    void Start()
    {
        for (int i = 0; i < 200; i++)
        {
            GameObject poke = DGameSystem.LoadPool("PokeFollow", new Vector3(Random.Range(-1, 1), Random.Range(-1, 1)));
            poke.GetComponent<DStatPokeProvider>().pokeId = Random.Range(1, 850);
        }
    }

}
