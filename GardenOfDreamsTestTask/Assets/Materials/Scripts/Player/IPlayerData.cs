using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerData
{
    float GetHealth();
    void SetHealth(int value);

    float GetWeight();
    void SetWeight(float value);

    float GetHeadArmor();
    void SetHeadArmor(int value);

    float GetBodyArmor();
    void SetBodyArmor(int value);

    int GetMoney();
    void SetMoney(int value);
}
