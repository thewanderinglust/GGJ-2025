using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IPlayer
{
    [SerializeField] private int m_fizzToLose = 10;
    [SerializeField] private int m_buzzToWin = 15;

    [SerializeField] private Slider m_fizzSlider;
    [SerializeField] private Slider m_buzzSlider;

    public int FizzToLose { get { return m_fizzToLose; } }
    public int BuzzToWin { get { return m_buzzToWin; } }

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
            m_fizzSlider.value = GetSliderValue(m_fizzCurrent, m_fizzToLose);
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
            m_buzzSlider.value = GetSliderValue(m_buzzCurrent, m_buzzToWin);
        }
    }

    private void Awake()
    {
        m_buzzSlider.value = 0.0f;
        m_fizzSlider.value = 0.0f;
    }

    public float GetSliderValue(float a_current, float a_target)
    {
        float calc = a_current / a_target;

        if (calc > 1.0)
            calc = 1.0f;
        else if (calc < 0.0f)
            calc = 0.0f;
        return calc;
    }
}
