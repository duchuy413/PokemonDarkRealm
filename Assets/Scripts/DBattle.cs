using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DBattle : MonoBehaviour
{
    public bool showDetail = true; //false if static like grass
    private float HEALTH_BAR_DISTANCE = 0.1f;

    public DStat stat;
    public int level;
    public GameObject attackObj;
    public Transform healthBar;
    public TextMeshPro textName;

    private DBattleStat current;

    private void Start()
    {
        attackObj = Resources.Load<GameObject>("Attack") as GameObject;
        Init();
        LoadLevel(level);
    }

    private void Init()
    {
        if (showDetail)
        {
            //GameObject obj = Resources.Load<GameObject>("HealthBar") as GameObject;
            //GameObject spawn = Instantiate(obj, transform);
            //spawn.transform.position += new Vector3(0, HEALTH_BAR_DISTANCE);
            //healthBar = spawn.transform.Find("Bar");

            textName = GetComponentInChildren<TextMeshPro>();  
        }

    }

    private void LoadLevel(int level)
    {
        current = new DBattleStat();
        current.speed = stat.speed;
        current.baseExp = stat.baseExp;
        current.currentExp = stat.baseExp * Mathf.Pow(1.1f, level);
        current.nextLvlExp = stat.baseExp * Mathf.Pow(1.1f, level + 1);
        current.hp = stat.hp * Mathf.Pow(1.1f, level);
        current.maxhp = stat.hp * Mathf.Pow(1.1f, level);
        current.dame = stat.dame * Mathf.Pow(1.1f, level);
        current.attackRange = stat.attackRange;
        current.visionRange = stat.visionRange;
        current.attackCountDown = stat.attackCountDown;

        if (showDetail)
            textName.text = "lvl" + level.ToString() + "." + stat.characterName;
    }

    public void GetHit(DHitParam hit)
    {
        float calculatedDame = DGameSystem.pokemonSystem.CalculateReceiveDame(hit, stat);

        GameObject flyingtext = DGameSystem.LoadPool("TextDame", transform.position);
        flyingtext.GetComponent<TextMeshPro>().text = Convert.ToInt32(calculatedDame).ToString();

        current.hp -= calculatedDame;
        UpdateHealthBar();

        if (current.hp <= 0)
        {
            DGameSystem.LoadPool("Ghost", transform.position);
            gameObject.SetActive(false);
        }

        Debug.Log(gameObject.name + " get hit from " + hit.owner.name);
    }

    public void ApplyDame(GameObject target)
    {
        DHitParam hit = new DHitParam();
        hit.dame = current.dame;
        hit.owner = gameObject;
        hit.ownerTag = gameObject.tag;
        

        target.SendMessage("GetHit", hit,SendMessageOptions.DontRequireReceiver);
    }

    public void UpdateHealthBar()
    {
        if (showDetail) 
            healthBar.localScale = new Vector3(current.hp / current.maxhp, 1, 1);
    }

    //public void Attack()
    //{
    //    Quaternion quaternion = Quaternion.Euler(0, 0, 0);
    //    switch (GetComponent<DMovement>().Facing)
    //    {
    //        case "up":
    //            quaternion = Quaternion.Euler(0, 0, 90);
    //            break;
    //        case "down":
    //            quaternion = Quaternion.Euler(0, 0, 270);
    //            break;
    //        case "left":
    //            quaternion = Quaternion.Euler(0, 0, 180);
    //            break;
    //        case "right":
    //            quaternion = Quaternion.Euler(0, 0, 0);
    //            break;
    //        default:
    //            quaternion = Quaternion.Euler(0, 0, 0);
    //            break;
    //    }

    //    GameObject attack = DGameSystem.LoadPool("Attack", transform.position);
    //    attack.transform.rotation = quaternion;
    //    DHitParam hitParam = attack.GetComponent<DHitParam>();

    //    hitParam.dame = current.dame;
    //    hitParam.owner = this.gameObject;
    //    hitParam.ownerTag = this.gameObject.tag;
    //    hitParam.type1 = stat.type1;
    //    hitParam.type2 = stat.type2;

    //    if (gameObject.tag == "Player")
    //    {
    //        string facing = GetComponent<DMovement>().Facing;
    //        Sprite[] attacks = GetComponent<DMovement>().ConvertStringToSprites("attack_" + facing);
    //        GetComponent<DAnimator>().spritesheet = attacks;
    //        //GetComponent<DAnimator>().attacking = true;
    //    }
    //}

    public void ExecuteAttack()
    {
        GameObject attackObj = DGameSystem.LoadPool(stat.attackObjectName, transform.position);
        attackObj.transform.rotation = Quaternion.Euler(0, 0, 0);
        DHitParam hitParam = new DHitParam();
        hitParam.dame = current.dame;
        hitParam.owner = gameObject;
        hitParam.ownerTag = gameObject.tag;
        hitParam.type1 = stat.type1;
        hitParam.type2 = stat.type2;

        if (gameObject.CompareTag("Pet"))
            hitParam.targetTags = new List<string> { "Monster" };
        else
            hitParam.targetTags = new List<string> { "Pet" };

        if (gameObject.tag == "Player")
            hitParam.direction = GetComponent<DMovement>().Facing;
        else
        {
            hitParam.target = GetComponent<DFollow>().enemy;
            hitParam.direction = GetComponent<DFollow>().direction;
            if (hitParam.direction == "left")
                attackObj.transform.rotation = Quaternion.Euler(0, 0, 180);
            else
                attackObj.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        attackObj.SendMessage("ReceiveParam", hitParam, SendMessageOptions.DontRequireReceiver);
    }

    
}

