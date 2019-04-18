using UnityEngine;

namespace Characters {
    public interface IDamagable 
    {
        void getDamage(GameObject damageDealer, float damage);
        void die(GameObject damageDealer);
    }
}
