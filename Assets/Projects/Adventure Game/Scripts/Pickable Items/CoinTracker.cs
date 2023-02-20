using TMPro;
using UnityEngine;

namespace AdventureGame
{
    public class CoinTracker : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI _coinsLeftTextMesh;
        [SerializeField] TextMeshProUGUI _coinsCollectedTextMesh;
        private string _coinsLeftText = "Coins left to collect: ";
        private string _coinsCollectedText = "Coins collected: ";
        private int _availableCoins = 0;
        private int _collectedCoins = 0;

        private void Start()
        {
            UpdateCoinUI();

            GameManager.Instance.CoinManager.OnDropped += IncreaseCoinsTracker;
            GameManager.Instance.CoinManager.OnCollected += DecreaseCoinsTracker;
        }

        private void IncreaseCoinsTracker()
        {
            _availableCoins++;
            _coinsLeftTextMesh.text = _coinsLeftText + _availableCoins;
        }

        private void UpdateCoinUI()
        {
            _coinsLeftTextMesh.text = _coinsLeftText + _availableCoins;
            _coinsCollectedTextMesh.text = _coinsCollectedText + _collectedCoins;
        }

        private void DecreaseCoinsTracker(bool isCollected)
        {
            _availableCoins--;
            if(isCollected)
            _collectedCoins++;
            UpdateCoinUI();
        }

        private void OnDestroy()
        {
            GameManager.Instance.CoinManager.OnDropped -= IncreaseCoinsTracker;
            GameManager.Instance.CoinManager.OnCollected -= DecreaseCoinsTracker;
        }
    }

}
