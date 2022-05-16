public class Weapon
{
    private readonly int BulletOnShoot;

    public Weapon(int damage, int bullets, int bulletOnShoot = 1)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        if (bullets < 0)
            throw new ArgumentOutOfRangeException(nameof(bullets));

        if (bulletOnShoot < 0)
            throw new ArgumentOutOfRangeException(nameof(bulletOnShoot));

        Damage = damage;
        Bullets = bullets;
        BulletOnShoot = bulletOnShoot;
    }

    public int Bullets { get; private set; }
    public int Damage { get; private set; }
    public bool CanFire => BulletOnShoot <= Bullets;

    public void Fire(IDamageable target)
    {
        if (CanFire == false)
            throw new InvalidOperationException();

        if (target == null)
            throw new ArgumentNullException(nameof(target));

        Bullets -= BulletOnShoot;
        target.Damage(this);
    }
}

<<<<<<< Updated upstream
public class Player
=======
class Player : IDamageable
>>>>>>> Stashed changes
{
    public Player(int health)
    {
        if (health <= 0)
            throw new ArgumentOutOfRangeException(nameof(health));

        Health = health;
    }

    public int Health { get; private set; }
    public bool Dead => Health == 0;

    public void Damage(Weapon weapon)
    {
        if (Dead == true)
            throw new InvalidOperationException(nameof(Health));

        Health -= weapon.Damage;

        if (Health < 0)
            Health = 0;
    }
}

<<<<<<< Updated upstream
public class Bot
=======
interface IDamageable
{
    public void Damage(Weapon weapon);
}

class Bot
>>>>>>> Stashed changes
{
    private readonly Weapon Weapon;

    public Bot(Weapon weapon)
    {
        if (weapon == null)
            throw new ArgumentNullException(nameof(weapon));

        Weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        Weapon.Fire(player);
    }
}