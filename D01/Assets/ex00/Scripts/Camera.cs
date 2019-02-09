using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;
    public playerScript_ex00 getPlayer;

    void Start()
    {
        Player = getPlayer.currentPlayer;
        offset = transform.position - Player.transform.position;
    }
    void Update()
    {
        Player = getPlayer.currentPlayer;
    }

    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
