using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void Attack()
    {
        _player.TakeDamage(10f);
    }

    public void ToCure()
    {
        _player.Heal(10f);
    }
}
