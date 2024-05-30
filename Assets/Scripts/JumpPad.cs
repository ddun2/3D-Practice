using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody playerRb;
    public float jumpPower;

    void Start()
    {
        controller = CharacterManager.Instance.Player.controller;
        playerRb = CharacterManager.Instance.Player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRb.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }
}
