using UnityEngine;
using UnityEngine.UI;

public class HubUpdater : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Image weightBar;
    [SerializeField] private Image headArmorBar;
    [SerializeField] private Image bodyArmorBar;
    [SerializeField] private PlayerData player;

    public void UpdateHub()
	{
        healthBar.fillAmount = player.GetHealth() / 100;
        weightBar.fillAmount = player.GetWeight() / 100;
        headArmorBar.fillAmount = player.GetHeadArmor() / 100;
        bodyArmorBar.fillAmount = player.GetBodyArmor() / 100;
    }
}
