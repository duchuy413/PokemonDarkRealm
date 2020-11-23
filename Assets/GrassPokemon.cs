using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPokemon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<DWildPokemonSystem>().EnterGrass();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<DWildPokemonSystem>().ExitGrass();
        }
    }

}
