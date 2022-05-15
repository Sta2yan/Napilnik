class Weapon
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

    public void Fire(Player player)
    {
        if (CanFire == false)
            throw new InvalidOperationException();

        if (player == null)
            throw new ArgumentNullException(nameof(player));

        Bullets -= BulletOnShoot;
        player.Damage(this);
    }
}

class Player
{
    public Player(int health)
    {
        if (health <= 0)
            throw new ArgumentOutOfRangeException(nameof(health));

        Health = health;
    }

    public int Health { get; private set; }

    public void Damage(Weapon weapon)
    {
        if (Health < weapon.Damage)
            throw new ArgumentOutOfRangeException(nameof(Health));

        Health -= weapon.Damage;
    }
}

class Bot
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