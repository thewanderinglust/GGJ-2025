using UnityEngine;

public enum CardState
{
    DECK,
    HAND,
    PLAY,
    DISCARD,
    DEAD
}

public enum CardSuit
{
    NONE
}

public interface ICard
{

    int DefaultFizz
    {
        get;
    }

    int DefaultBuzz
    {
        get;
    }

    int FizzModifier
    {
        get;
        set;
    }

    int BuzzModifier
    {
        get;
        set;
    }

    CardState State
    {
        get;
        set;
    }
    
    CardSuit Suit
    {
        get;
        set;
    }

    CardManager Manager
    {
        set;
    }

    void OnPlay();

    void OnEnterHand();

    void OnDiscard();

}
