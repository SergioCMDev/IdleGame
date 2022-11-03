using System.Collections.Generic;
using Ships;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private bool _isTravelling;
    private Direction _direction;
    public List<Equipment> equipment;


    public bool IsTravelling
    {
        get => _isTravelling;
        set => _isTravelling = value;
    }

    public Direction Direction
    {
        get => _direction;
        set => _direction = value;
    }
}