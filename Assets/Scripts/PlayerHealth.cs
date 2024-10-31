using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI winHealthText;
    [SerializeField] private TextMeshProUGUI failHealthText;

    public int Health { private get; set; }

    private bool _canDecreaseHp = true;

    private void Start()
    {
        healthText.text = winHealthText.text = failHealthText.text = Health + " HP";

        if (PlayerPrefs.GetInt("InfiniteHP", 0) == 1)
        {
            _canDecreaseHp = false;
            healthText.text = "∞ HP";
        }
    }

    public void DecreaseHealth()
    {
        if (!_canDecreaseHp) return;
        Health -= 1;
        healthText.text = winHealthText.text = failHealthText.text = Health + " HP";

        if (Health == 0)
        {
            gameController.Fail();
        }
    }
}
