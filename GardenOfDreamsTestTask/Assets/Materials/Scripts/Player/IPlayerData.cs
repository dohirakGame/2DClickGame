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
    void SetHeadArmor(float value);

    float GetBodyArmor();
    void SetBodyArmor(float value);

    int GetMoney();
    void SetMoney(int value);
}
