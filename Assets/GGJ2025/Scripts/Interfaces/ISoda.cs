using UnityEngine;


public enum SodaType
{
    RAMUNE,
    MONSTER,
    SELTZER,
    SODA4
}

public enum SodaState
{
    NEUTRAL
}
public interface ISoda
{
   string Name
    {
        get;
        set;
    }

    SodaState State
    {
        get;
        set;
    }

    SodaType Type
    {
        get;
        set;
    }
}
