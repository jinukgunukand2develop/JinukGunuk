using UnityEngine;

// TODO : delay 변수 타입에 소숫점이 자주 사용되지 않으면 나중에 int로 바꿈
// IMPORTANT : _ID 변수 타입은 원레 int형. _ID가 "2,147,483,647" 까지 커지지 않을거 같으니 "0 ~ 65,535" 까지 나타낼수 있는 ushort 사용함


public class CToad : MonoBehaviour
{
    protected ushort _ID = 101;
    protected int iHp = 50;
    protected int attackDamage = 3;
    protected int collisionDamage = 30;
    protected float delay = 2;
}

public class CBeak : MonoBehaviour
{
    protected ushort _ID = 102;
    protected int iHp = 19;
    protected int attackDamage = 15;
    protected int collisionDamage = 19;
    protected float delay = 1;
}

public class CCrap : MonoBehaviour
{
    protected ushort _ID = 103;
    protected int iHp = 32;
    protected int attackDamage = 9;
    protected int collisionDamage = 25;
    protected float delay = 0.7f;
}

public class CTeemo : MonoBehaviour
{
    protected ushort _ID = 204;
    protected int iHp = 15;
    protected int collisionDamage = 20;
}

public class CTiber : MonoBehaviour
{
    protected ushort _ID = 205;
    protected int iHp = 35;
    protected int collisionDamage = 40;
}