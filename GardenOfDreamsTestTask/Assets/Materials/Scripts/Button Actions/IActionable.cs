public enum ActionButton
{
	Shoot,
	AddAmmo,
	AddItem,
	RemoveItem
}

public interface IActionable
{
	void UseAction(ActionButton button);
}
