using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    coin,
    speed,
    slow,
    time
}
public class Coin : MonoBehaviour
{
    [SerializeField] float speedAngle = 2f;
    [SerializeField]
    Material[] colors;
    float[] timeAlives = { 20, 10, 15, 7 };
    public Type type;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speedAngle, 0, 0);
    }
    public void SetType(Type type)
    {
        this.type = type;
        GetComponent<MeshRenderer>().material = colors[(int)type];
        Destroy(gameObject, timeAlives[(int)type]);
    }


}
