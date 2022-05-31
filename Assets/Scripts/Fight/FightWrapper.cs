using UnityEngine;

namespace Fight
{
    public abstract class FightWrapper : MonoBehaviour, IFight
    {
        public abstract int GetNumber();
    }
}