namespace MARVEL.COMICS.BUSINESSLOGIC.Constants
{
    public static class Messages
    {
        /// <summary>
        /// Message for internal error without treatment.
        /// </summary>
        public const string InternalErrorWithoutTreatment = "Internal error without treatment. Contact your administrator.";

        #region [ TOKEN ]

        /// <summary>
        /// Message for success in token generation.
        /// </summary>
        public const string SuccessInTokenGeneration = "Access token successfully generated.";

        /// <summary>
        /// Message for failed in token generation.
        /// </summary>
        public const string FailedInTokenGeneration = "Failed to generate authentication token, {0}.";

        #endregion [ TOKEN ]

        #region [ USER ]

        public const string SuccessInUserRegister = "User registered with success.";

        public const string FailedInUserRegister = "User cannot be added. Username not supported.";

        public const string SuccessInUserUpdate = "User updated with success.";

        public const string FailedInUserUpdate = "User cannot be updated. Id not supported.";

        public const string SuccessInUserLogin = "Success in user authentication.";

        public const string FailedInUserLogin = "Username or password incorrect.";

        #endregion [ USER ]
    }
}
