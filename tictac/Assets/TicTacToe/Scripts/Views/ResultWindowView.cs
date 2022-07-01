using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Scripts.Views
{
    public class ResultWindowView : MonoBehaviour
    {
        [SerializeField] private Text resultText;
        [SerializeField] private Button okButton;

        public Action OkClicked;

        private void Start()
        {
            okButton.onClick.AddListener(OnOkButtonClicked);
        }

        public void SetState(GameState _state)
        {
            resultText.text = _state switch
            {
                GameState.resultWin => "You Win!",
                GameState.resultLose => "You Lose!",
                GameState.resultDraw => "Draw!",
            };
        }

        private void OnOkButtonClicked()
        {
            OkClicked?.Invoke();
        }
    }
}