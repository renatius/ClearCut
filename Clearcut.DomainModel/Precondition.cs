namespace Clearcut.DomainModel
{
    public static class Precondition
    {
        public static void Requires(bool condition, string errorMessage)
        {
            if (errorMessage == null)
                throw new DomainException(Properties.Resources.PRECONDITION_ERROR_MESSAGE_CANNOT_BE_NULL);

            if (!condition) throw new DomainException(errorMessage);
        }
    }
}
