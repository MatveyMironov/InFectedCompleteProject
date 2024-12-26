using System;
using UnityEngine;

namespace GameSystem
{
    public interface IQuitInputListener
    {
        public event Action OnQuitInputRecieved;
    }
}