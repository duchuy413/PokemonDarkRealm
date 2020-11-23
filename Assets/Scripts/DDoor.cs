using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class DDoor : NetworkBehaviour
{
    public Transform destination;

    //public float destination_x;
    //public float destination_y;

    private float INTERACT_DISTANCE = 0.1f;

    private void Start()
    {
        transform.GetComponent<SpriteRenderer>().enabled = false;
        destination.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Update()
    {
        if (DGameSystem.player == null)
            return;

        if (Vector3.Distance(transform.position, DGameSystem.player.transform.position) < INTERACT_DISTANCE)
        {
            DGameSystem.cameraScript.MoveTo(destination);
            //DGameSystem.player.transform.position = destination.position;
            //Debug.Log("Destination position is: " + destination.position);
            //Debug.Log("Destination localposition is: " + destination.localPosition);

            ////GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            //Vector3 pos = DGameSystem.cameraMain.transform.position;
            //pos.x = destination.position.x;
            //pos.y = destination.position.y;

            ////DGameSystem.cameraMain.GetComponent<DCamera>().enabled = false;
            ////DGameSystem.cameraMain.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //DGameSystem.cameraMain.transform.position = pos;

            ////DGameSystem.LoadPool("BlackScreenEffect", destination.position);
        }

        //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //foreach (GameObject player in players)
        //{
        //    if (player.GetComponent<NetworkIdentity>().isLocalPlayer)
        //    {
        //        if (Vector3.Distance(transform.position, player.transform.position) < INTERACT_DISTANCE) {
                    
        //            player.transform.position = destination.position;
        //            //GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        //            Vector3 pos = DGameSystem.cameraMain.transform.position;
        //            pos.x = destination.position.x;
        //            pos.y = destination.position.x;

        //            DGameSystem.cameraMain.GetComponent<DCamera>().enabled = false;
        //            DGameSystem.cameraMain.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        //            DGameSystem.cameraMain.transform.position = pos;

        //            //DGameSystem.LoadPool("BlackScreenEffect", destination.position);
        //        }
        //    }
        //}
    }
}
