using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShips
{
    public class ShipModel 
    {
        private bool _isTravelling;
        private string name;
        private Direction _direction;
        public List<Equipment> equipment;
        public float blockedTime;

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

        public DateTime DateToRelease { get; set; }

        public string Name
        {
            get => name;
            set => name = value;
        }
    }
}