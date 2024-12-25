using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject HPBar; // Шкала здоровья
    private Player _player; // Ссылка на игрока
    private Image _fillImage; // Компонент изображения для заполнения шкалы

    private void Start()
    {
        _player = GetComponent<Player>();
        if (HPBar != null)
        {
            _fillImage = HPBar.transform.Find("Fill").GetComponent<Image>();
        }
    }

    private void Update()
    {
        if (_fillImage != null)
        {
            // Обновить шкалу здоровья в зависимости от текущего здоровья игрока
            float _currentFillAmount = Mathf.MoveTowards(_fillImage.fillAmount, Mathf.Clamp01(_player._currentHealth / _player.Health), Time.deltaTime / 2);
            _fillImage.fillAmount = _currentFillAmount;
        }
    }
}
