namespace OOP21_task_cSharp.Gessi
{
    /// <summary>
    /// Disclaimer:
    /// I didn't originally write this class, but now I'm going to write it because I need it and I'm going to do it by simply transcribing (and adapting) the code from Java to C#.
    /// Class that has the dimension of a single images (tile image).
    /// </summary>
    public class ImgTileSize
    {
        private const int CELL_SIZE = 80;
        private ImgTileSize() { }

        /// <summary>
        /// The image size.
        /// </summary>
        /// <returns>image size</returns>
        public static int GetTileSize()
        {
            return CELL_SIZE;
        }
    }
}