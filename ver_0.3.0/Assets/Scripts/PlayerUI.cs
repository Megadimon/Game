using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject HPBar; // Ўкала здоровь€
    public GameObject FuelBar;
    private Player _player; // —сылка на игрока
    private Image _fillHPBar;
    private Image _fillFuelBar;

    private void Start()
    {
        _player = GetComponent<Player>();
        if (HPBar != null)
        {
            _fillHPBar = HPBar.transform.Find("Fill").GetComponent<Image>();
        }
        if (FuelBar != null)
        {
            _fillFuelBar = FuelBar.transform.Find("Fill").GetComponent<Image>();
        }
    }

    private void Update()
    {
        if (_fillHPBar != null)
        {
            _fillHPBar.fillAmount = Mathf.MoveTowards(_fillHPBar.fillAmount, Mathf.Clamp01(_player._currentHealth / _player.Health), Time.deltaTime / 2);
        }
        if (_fillFuelBar != null)
        {
            _fillFuelBar.fillAmount = Mathf.MoveTowards(_fillFuelBar.fillAmount, Mathf.Clamp01(_player._currentFuel / _player.FuelOfPlayer), Time.deltaTime / 2);
        }
    }
}
