using UnityEngine;

// TODO : delay 변수 타입에 소숫점이 자주 사용되지 않으면 나중에 int로 바꿈
// IMPORTANT : _ID 변수 타입은 원레 int형. _ID가 "2,147,483,647" 까지 커지지 않을거 같으니 "0 ~ 65,535" 까지 나타낼수 있는 ushort 사용함



public class CToad : MonoBehaviour
{
    protected const ushort _ID = 101;
    [SerializeField] protected int iHp = 50;
    [SerializeField] protected int attackDamage = 3;
    [SerializeField] protected int collisionDamage = 30;
    [SerializeField] protected float delay = 2;
}

public class CBeak : MonoBehaviour
{
    protected const ushort _ID = 102;
    [SerializeField] protected int iHp = 19;
    [SerializeField] protected int attackDamage = 15;
    [SerializeField] protected int collisionDamage = 19;
    [SerializeField] protected float delay = 1;
}

public class CCrap : MonoBehaviour
{
    protected const ushort _ID = 103;
    [SerializeField] protected int iHp = 32;
    [SerializeField] protected int attackDamage = 9;
    [SerializeField] protected int collisionDamage = 25;
    [SerializeField] protected float delay = 0.7f;
}

public class CTeemo : MonoBehaviour
{
    protected const ushort _ID = 204;
    [SerializeField] protected int iHp = 15;
    [SerializeField] protected int collisionDamage = 20;
}

public class CTiber : MonoBehaviour
{
    protected const ushort _ID = 205;
    [SerializeField] protected int iHp = 35;
    [SerializeField] protected int collisionDamage = 40;
}