using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.Rendering.Universal;

public class DGameSystem : MonoBehaviour
{
    public int START_MONEY = 300;

    public static GameObject player;
    public static List<GameObject> poolObjects;
    public static List<string> poolNames;
    public static int money;
    public static TextMeshProUGUI moneyValue;
    public static GameObject canvasCommon;
    public static GameObject canvasDialog;
    public static GameObject networkMenu;
    public static GameObject canvasShop;
    public static GameObject canvasControl;
    public static DInteractButton interactButton;
    public static DInventory inventory;
    public static Joystick joystick;
    public static DShop shop;
    public static Light2D globalLight;
    public static DMapGenerator mapGenerator;
    public static Camera cameraMain;
    public static DCamera cameraScript;
    public static DEffector effector;
    public static CustomNetworkManager networkManager;
    public static DPokemonSystem pokemonSystem;
    public static GameObject pokemonControl;
    public static GameObject pokemonEnemy;

    private void Awake()
    {
        moneyValue = GameObject.Find("MoneyValue").GetComponent<TextMeshProUGUI>();
        canvasCommon = GameObject.Find("CanvasCommon");
        canvasDialog = GameObject.Find("CanvasDialog");
        networkMenu = GameObject.Find("NetworkMenu");
        canvasShop = GameObject.Find("CanvasShop");
        canvasControl = GameObject.Find("CanvasControl");
        interactButton = GameObject.Find("InteractButton").GetComponent<DInteractButton>();
        joystick = GameObject.Find("Joystick").GetComponent<Joystick>();
        shop = GameObject.Find("Shop").GetComponent<DShop>();
        shop.CreateShop();
        globalLight = GameObject.Find("GlobalLight").GetComponent<Light2D>();
        mapGenerator = GameObject.Find("MapGenerator").GetComponent<DMapGenerator>();
        cameraMain = GameObject.Find("MainCamera").GetComponent<Camera>();
        cameraScript = GameObject.Find("MainCamera").GetComponent<DCamera>();
        effector = GameObject.Find("Effector").GetComponent<DEffector>();
        networkManager = GameObject.Find("NetworkManager").GetComponent < CustomNetworkManager > ();
        pokemonSystem = GameObject.Find("PokemonSystem").GetComponent<DPokemonSystem>();
        pokemonControl = GameObject.Find("PokemonControl");
        pokemonEnemy = GameObject.Find("PokemonEnemy");
        //pokemonControl.SetActive(false);

        poolObjects = new List<GameObject>();
        poolNames = new List<string>();
        canvasDialog.SetActive(false);
        canvasShop.SetActive(false);

        DStat stat = new DStat();
    }

    private void Start()
    {
        money = 0;
        AddMoney(START_MONEY);

        networkManager.StartHost();
    }

    public static Vector3 GoToTargetVector(Vector3 current, Vector3 target, float speed)
    {
        float distanceToTarget = Vector3.Distance(current, target);
        Vector3 vectorToTarget = target - current;
        return vectorToTarget = vectorToTarget * speed / distanceToTarget;
    }

    public static GameObject LoadPool(string poolName, Vector3 position)
    {
        for (int i = 0; i < poolNames.Count; i++)
        {
            if (string.Compare(poolNames[i], poolName) == 0 && poolObjects[i].activeSelf == false)
            {
                poolObjects[i].SetActive(true);
                poolObjects[i].transform.position = position;
                return poolObjects[i];
            }
        }

        GameObject obj = Instantiate(Resources.Load<GameObject>(poolName) as GameObject, position, Quaternion.identity);
        poolNames.Add(poolName);
        poolObjects.Add(obj);
        return obj;
    }

    public static void AddMoney(int amount)
    {
        money += amount;
        moneyValue.text = money.ToString();
    }

    public static bool SpendMoney(int amount)
    {
        if (money < amount) return false;

        money -= amount;
        moneyValue.text = money.ToString();
        return true;
    }

    public static void RegistPlayer(GameObject playerObj)
    {
        player = playerObj;
        inventory = playerObj.GetComponent<DInventory>();
        playerObj.GetComponent<DMovement>().data = LoadStat("camdu");
    }

    public static DStat LoadStat(string statName)
    {

        Sprite[] sprites = Resources.LoadAll<Sprite>(statName);

        Sprite up = sprites[0];
        Sprite up1 = sprites[2];
        Sprite up2 = sprites[10];
        Sprite down = sprites[5];
        Sprite down1 = sprites[8];
        Sprite down2 = sprites[11];
        Sprite left = sprites[6];
        Sprite left1 = sprites[3];
        Sprite left2 = sprites[9];
        Sprite right = sprites[1];
        Sprite right1 = sprites[4];
        Sprite right2 = sprites[7];

        DStat stat = new DStat();

        stat.stand_up = new Sprite[] { up };
        stat.stand_down = new Sprite[] { down };
        stat.stand_left = new Sprite[] { left };
        stat.stand_right = new Sprite[] { right };

        stat.go_up = new Sprite[] { up, up1, up, up2 };
        stat.go_down = new Sprite[] { down, down1, down, down2 };
        stat.go_left = new Sprite[] { left, left1, left, left2 };
        stat.go_right = new Sprite[] { right, right1, right, right2 };

        stat.run_up = new Sprite[] { up, up1, up, up2 };
        stat.run_down = new Sprite[] { down, down1, down, down2 };
        stat.run_left = new Sprite[] { left, left1, left, left2 };
        stat.run_right = new Sprite[] { right, right1, right, right2 };

        return stat;
    }

    public static void SwitchControlToPlayer()
    {
        player.SetActive(true);
        cameraScript.MoveTo(player.transform);
        cameraScript.target = player;
        pokemonControl.SetActive(false);
    }

    public static void SwitchControlToPokemon() 
    {
        pokemonControl.SetActive(true);
        cameraScript.MoveTo(pokemonControl.transform);
        cameraScript.target = pokemonControl;
        player.SetActive(false);
    }

}
