namespace Characters {
    public interface IDamagable 
    {
        void getDamage(LivinEntity damageDealer, float damage);
        void die(LivinEntity damageDealer);
    }
}
