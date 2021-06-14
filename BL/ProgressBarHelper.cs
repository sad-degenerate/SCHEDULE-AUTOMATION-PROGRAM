namespace BL
{
    public delegate void ProgressBarChanged(int value);

    public static class ProgressBarHelper
    {
        public static event ProgressBarChanged ProgressBar = null;

        public static void ProgressBarEvent(int value)
        {
            ProgressBar?.Invoke(value);
        }
    }
}