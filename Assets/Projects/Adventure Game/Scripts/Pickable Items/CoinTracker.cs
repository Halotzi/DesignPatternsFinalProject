using TMPro;
using UnityEngine;

namespace AdventureGame
{
    public class CoinTracker : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI _trackerText;
        private string eggLeftText = "Egg left to collect: ";
        private int _availableCoins = 0;

        private void Start()
        {
            _trackerText.text = eggLeftText + _availableCoins;
            GameManager.Instance.CoinManager.OnDropped += IncreaseCoinsTracker;
            GameManager.Instance.CoinManager.OnCollected += DecreaseCoinsTracker;
        }

        private void IncreaseCoinsTracker()
        {
            _availableCoins++;
            _trackerText.text = eggLeftText + _availableCoins;
        }

        private void DecreaseCoinsTracker()
        {
            _availableCoins--;
            _trackerText.text = eggLeftText + _availableCoins;
        }

        private void OnDestroy()
        {
            GameManager.Instance.CoinManager.OnDropped -= IncreaseCoinsTracker;
            GameManager.Instance.CoinManager.OnCollected -= DecreaseCoinsTracker;
        }
    }

}
