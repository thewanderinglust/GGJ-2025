using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    [SerializeField] private int m_fizzToLose = 10;
    [SerializeField] private int m_buzzToWin = 15;
    private int m_buzzCurrent;
    private int m_fizzCurrent;

    public int Fizz
    {
        get
        {
            return m_fizzCurrent;
        }
        set
        {
            m_fizzCurrent = value;
            Debug.Log("New Fizz: " + m_fizzCurrent);
        }
    }

    public int Buzz
    {
        get
        {
            return m_buzzCurrent;
        }
        set
        {
            m_buzzCurrent = value;
            Debug.Log("New Buzz: " + m_buzzCurrent);
        }
    }
}
