using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            print("OK");
            Coin coin = collision.gameObject.transform.GetComponent<Coin>();
            switch(coin.type)
            {
                case Type.coin:
                    {
                        controller.controller.AddCoin(1);
                        break;
                    }
                case Type.slow:
                    {
                        controller.SetSpeed(0.8f);
                        break;
                    }
                case Type.speed:
                    {
                        controller.SetSpeed(1.2f);
                        break;
                    }
                case Type.time:
                    {
                        controller.controller.AddTime(10);
                        break;
                    }
            }
            Destroy(collision.gameObject);
        }
    }
}
