using Assets.Scripts.Base.Gameplay;
using Assets.Scripts.Base.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Assets.Scripts.Base
{
	[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
	public class InputReader : DescriptionBaseSO, GameInput.IGameplayActions, IInputReader
	{
		//TODO MITO -> Continue checking from link
		//https://github.com/UnityTechnologies/open-project-1/blob/608eac98df29cd97821a6115cd52dfb9027345b1/UOP1_Project/Assets/Scripts/Events/ScriptableObjects/BoolEventChannelSO.cs#L10
		[Space]
		
		[SerializeField]
		private GameStateSO _gameStateManager;

		// Assign delegate{} to events to initialise them with an empty delegate
		// so we can skip the null check when we use them

		// Gameplay
		public event UnityAction<float> MoveEvent = delegate { };
		public event UnityAction ActionEvent = delegate { };

		private GameInput _gameInput;

		private void OnEnable()
		{
			ConfigureInput();
		}

		private void ConfigureInput()
		{
			if (_gameInput != null)
			{
				return;
			}

			_gameInput = new GameInput();
			_gameInput.Gameplay.SetCallbacks(this);
		}

		private void OnDisable()
		{
			DisableAllInput();
		}

		private void DisableAllInput()
		{
			_gameInput.Gameplay.Disable();
		}

		public void OnAction(InputAction.CallbackContext context)
		{
			// Interaction is only possible when in gameplay GameState
			if (_gameStateManager.CurrentGameState == GameState.Gameplay && context.phase == InputActionPhase.Performed)
			{
				ActionEvent.Invoke();
			}
		}

		public void OnMove(InputAction.CallbackContext context)
		{
			var movementValue = context.ReadValue<float>();
			MoveEvent.Invoke(movementValue);
		}
	}
}