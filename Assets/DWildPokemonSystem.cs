using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DWildPokemonSystem : MonoBehaviour
{
    public ParticleSystem grassEffect;
    public Rigidbody2D rb2d;

    public bool isInGrass = false;

    float count;
    float SPAWN_POKEMON_RATE = 3f;

    private void Start()
    {
        grassEffect.Stop();
    }

    public void EnterGrass()
    {
        isInGrass = true;
        grassEffect.Play();
    }

    public void ExitGrass()
    {
        isInGrass = false;
        grassEffect.Stop();
    }

    private void Update()
    {
        if (!isInGrass)
            return;

        if (rb2d.velocity != Vector2.zero)
        {
            count += Time.deltaTime;
            if (count > SPAWN_POKEMON_RATE)
            {
                count = 0;
                StartCoroutine(WildPokemonAppear());
            }
        }
    }

    public IEnumerator WildPokemonAppear()
    {
        rb2d.velocity = Vector2.zero;
        GetComponent<DControlByJoystick>().enabled = false;

        GameObject effect = DGameSystem.LoadPool("BlackScreenEffect", transform.position);
        effect.transform.SetParent(DGameSystem.cameraMain.transform);

        yield return new WaitForSeconds(2);
        //DGameSystem.SwitchControlToPokemon();

        DGameSystem.pokemonControl.SetActive(true);
        DGameSystem.cameraScript.MoveTo(DGameSystem.pokemonEnemy.transform);
        DGameSystem.cameraScript.target = DGameSystem.pokemonEnemy;
        
        DScriptDialog dialog = new DScriptDialog();
        dialog.sentences = new List<string> { "A wild pokemon appeared!" };
        DGamePauser.StartScripts(new DScriptDialog[] { dialog });

        yield return new WaitForSeconds(2);

        dialog = new DScriptDialog();
        dialog.sentences = new List<string> { "Go my pokemon!" };
        DGamePauser.StartScripts(new DScriptDialog[] { dialog });

        DGameSystem.cameraScript.target = DGameSystem.pokemonControl;
        yield return new WaitForSeconds(1);
        DGamePauser.state = DGamePauser.STATE.FREE;
    }
}
