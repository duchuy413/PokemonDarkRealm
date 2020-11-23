using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DStatPokeProvider : MonoBehaviour
{
    public int pokeId = 100;
    public bool isShiny = false;
    public bool isAlola = false;

    void Awake()
    {
        DStat stat = DGameSystem.pokemonSystem.LoadStat(pokeId, isShiny, isAlola);

        if (GetComponent<DMovement>() != null)
            GetComponent<DMovement>().data = stat;
        if (GetComponent<DBattle>() != null)
            GetComponent<DBattle>().stat = stat;
        if (GetComponent<DFollow>() != null)
            GetComponent<DFollow>().data = stat;
    }

    public DStat LoadStat(int pokeId)
    {
        string num3 = "";
        if (pokeId < 10)
            num3 = "00" + pokeId.ToString();
        else if (pokeId < 100)
            num3 = "0" + pokeId.ToString();
        else
            num3 = pokeId.ToString();

        Sprite[] sprites;
        if (isShiny)
            sprites = Resources.LoadAll<Sprite>(num3 + "s");
        else
            sprites = Resources.LoadAll<Sprite>(num3);

        Sprite down1 = sprites[0];
        Sprite down2 = sprites[1];
        Sprite down3 = sprites[2];
        Sprite down4 = sprites[3];

        Sprite left1 = sprites[4];
        Sprite left2 = sprites[5];
        Sprite left3 = sprites[6];
        Sprite left4 = sprites[7];

        Sprite right1 = sprites[8];
        Sprite right2 = sprites[9];
        Sprite right3 = sprites[10];
        Sprite right4 = sprites[11];

        Sprite up1 = sprites[11];
        Sprite up2 = sprites[12];
        Sprite up3 = sprites[13];
        Sprite up4 = sprites[14];

        //Sprite up1 = Resources.Load<Sprite>("pokeup1 (" + pokeId + ")");
        //Sprite up2 = Resources.Load<Sprite>("pokeup2 (" + pokeId + ")");

        //Sprite down1 = Resources.Load<Sprite>("pokedown1 (" + pokeId + ")");
        //Sprite down2 = Resources.Load<Sprite>("pokedown2 (" + pokeId + ")");

        //Sprite left1 = Resources.Load<Sprite>("pokeleft1 (" + pokeId + ")");
        //Sprite left2 = Resources.Load<Sprite>("pokeleft2 (" + pokeId + ")");

        //Sprite right1 = Resources.Load<Sprite>("pokeright1 (" + pokeId + ")");
        //Sprite right2 = Resources.Load<Sprite>("pokeright2 (" + pokeId + ")");

        DStat stat = new DStat();

        stat.stand_up = new Sprite[] { up1 };
        stat.stand_down = new Sprite[] { down1 };
        stat.stand_left = new Sprite[] { left1 };
        stat.stand_right = new Sprite[] { right1 };

        stat.go_up = new Sprite[] {  up1, up2, up3, up4 };
        stat.go_down = new Sprite[] { down1, down2, down3, down4 };
        stat.go_left = new Sprite[] {  left1, left2, left3, left4 };
        stat.go_right = new Sprite[] { right1, right2, right3, right4 };

        stat.run_up = new Sprite[] { up1, up2, up3, up4 };
        stat.run_down = new Sprite[] { down1, down2, down3, down4 };
        stat.run_left = new Sprite[] { left1, left2, left3, left4 };
        stat.run_right = new Sprite[] { right1, right2, right3, right4 };

        stat.attack_up = new Sprite[] { up1, up2, up3, up4 };
        stat.attack_down = new Sprite[] { down1, down2, down3, down4 };
        stat.attack_left = new Sprite[] { left1, left2, left3, left4 };
        stat.attack_right = new Sprite[] { right1, right2, right3, right4 };

        stat.speed = 0.5f;
        stat.attackObjectName = "Attack";
        stat.attackRange = 0.2f;

        return stat;
    }
}
