using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HubUpdater : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthBarText;
    [SerializeField] private Image weightBar;
    [SerializeField] private TextMeshProUGUI weightBarText;
    [SerializeField] private Image headArmorBar;
    [SerializeField] private TextMeshProUGUI headArmorBarText;
    [SerializeField] private Image bodyArmorBar;
    [SerializeField] private TextMeshProUGUI bodyArmorBarText;
    [SerializeField] private PlayerData player;
    [SerializeField] private TextMeshProUGUI money;

    public void UpdateHub()
	{
        healthBar.fillAmount = player.GetHealth() / 100;
        weightBar.fillAmount = player.GetWeight() / player.maxWeight;
        headArmorBar.fillAmount = player.GetHeadArmor() / 100;
        bodyArmorBar.fillAmount = player.GetBodyArmor() / 100;

        healthBarText.text = $"Здоровье: {player.GetHealth()}";
        weightBarText.text = $"Вес: {player.GetWeight()}/{player.maxWeight}";
        headArmorBarText.text = $"Броня головы: {player.GetHeadArmor()}";
        bodyArmorBarText.text = $"Броня тела: {player.GetBodyArmor()}";
        money.text = $"Деньги: {player.GetMoney()}";
    }
}
