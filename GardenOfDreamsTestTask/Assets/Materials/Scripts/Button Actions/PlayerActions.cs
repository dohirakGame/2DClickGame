using UnityEngine;

public class PlayerActions : IActionable
{
    public void UseAction(ActionButton button)
	{
		switch (button)
		{
			case ActionButton.Shoot:
				Shoot();
				break;
			case ActionButton.AddAmmo:
				AddAmmo();
				break;
			case ActionButton.AddItem:
				AddItem();
				break;
			case ActionButton.RemoveItem:
				RemoveItem();
				break;
			default:
				Debug.Log("Invalid Button");
				break;
		}
	}

	private void Shoot()
	{
		ShootAction action = new ShootAction();
		action.ActionShoot();
	}
	private void AddAmmo()
	{
		AddAmmoAction action = new AddAmmoAction();
		action.ActionAddAmmo();
	}
	private void AddItem()
	{
		AddItemAction action = new AddItemAction();
		action.ActionAddItem();
	}
	private void RemoveItem()
	{
		RemoveItemAction action = new RemoveItemAction();
		action.ActionRemoveItem();
	}
}
