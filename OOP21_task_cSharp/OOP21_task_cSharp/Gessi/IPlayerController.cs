namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Disclaimer:
    /// I didn't originally write this class, but now I'm going to write it because I need it and I'm going to do it by simply transcribing (and adapting) the code from Java to C#.
    /// Manages the player.
    /// </summary>
    public interface IPlayerController
    {
        /// <summary>
        /// Returns the <see cref="IPlayer"/> associated.
        /// </summary>
        /// <returns>the player associated</returns>
        IPlayer GetPlayer();

        /// <summary>
        /// Changes the player's health by an offset value.
        /// </summary>
        /// <param name="offset">the change in health</param>
        void ChangeHP(int offset);

        /// <summary>
        /// Changes the player's money amount by an offset value.
        /// </summary>
        /// <param name="offset">the change in money amount</param>
        void ChangeMoney(int offset);

        /// <summary>
        /// Changes the player's score by an offset value.
        /// </summary>
        /// <param name="offset">the change in score</param>
        void ChangeScore(int offset);
    }
}
