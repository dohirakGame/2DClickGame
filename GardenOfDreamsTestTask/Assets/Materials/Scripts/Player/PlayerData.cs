using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour, IPlayerData
{
    public float maxWeight;

    private float _healthPoint;
    private float _weight;
    private float _headArmor;
    private float _bodyArmor;
    private int _money;

	private void Start()
	{
        SetHealth(100);
        SetWeight(15);
        SetHeadArmor(15);
        SetBodyArmor(15);
        SetMoney(50);
        HubUpdater hub = FindObjectOfType<HubUpdater>();
        hub.UpdateHub();
	}

	public float GetHealth()
	{
        return _healthPoint;
	}
    public void SetHealth(int value)
	{
        _healthPoint = value;
	}


    public float GetWeight()
    {
        return _weight;
    }
    public void SetWeight(float value)
    {
        _weight = value;
    }


    public float GetHeadArmor()
    {
        return _headArmor;
    }
    public void SetHeadArmor(int value)
    {
        _headArmor = value;
    }


    public float GetBodyArmor()
    {
        return _bodyArmor;
    }
    public void SetBodyArmor(int value)
    {
        _bodyArmor = value;
    }


    public int GetMoney()
    {
        return _money;
    }
    public void SetMoney(int value)
    {
        _money = value;
    }
}
