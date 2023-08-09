namespace Assets.Scripts.Base.Gameplay
{
    public enum GameState
    {
        Gameplay = 10,              // regular state: player moves, can perform actions
        Pause = 20,                 // pause menu is opened, the whole game world is frozen
        Inventory = 30,             // when inventory UI is open
        Dialogue = 40,
        Cutscene = 50,
        LocationTransition = 60,    // when the character steps into LocationExit trigger, transition and control is removed from the player
        Combat = 70,                // player can't open Inventory or initiate dialogues, but can pause the game
    }
}