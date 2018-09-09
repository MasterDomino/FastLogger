namespace FastLogging
{
    public static class Extensions
    {
        #region Methods

        public static string RemoveBefore(this string value, char character)
        {
            int index = value.LastIndexOf(character);
            if (index > 0)
            {
                value = value.Substring(index + 1);
            }
            return value;
        }

        #endregion
    }
}