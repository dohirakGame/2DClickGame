using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private bool _isOpen;
    [SerializeField] private bool _isFullStack;
    //[SerializeField] private bool _isOccupied;
	[SerializeField] private bool _isClosed;

	private void Awake()
	{
		SetOpenState(true);
		SetFullStackState(false);
		//SetOccupiedState(false);
	}

	public bool GetOpenState()
	{
        return _isOpen;
	}
    public void SetOpenState(bool value)
	{
        _isOpen = value;
	}

    public bool GetFullStackState()
	{
        return _isFullStack;
	}
    public void SetFullStackState(bool value)
	{
        _isFullStack = value;
	}

    /*public bool GetOccupiedState()
	{
        return _isOccupied;
	}
    public void SetOccupiedState(bool value)
	{
        _isOccupied = value;
	}*/

	public bool GetClosedState()
	{
		return _isClosed;
	}
	public void SetClosedState(bool value)
	{
		_isClosed = value;
	}
}
