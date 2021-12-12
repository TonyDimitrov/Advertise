namespace Advertise.Property.Constants
{
    public static class ValidationConstants
    {
        // Advetise 
        public const int AdTitleMaxLen = 150;
        public const int AdTitleMinLen = 2;
              
        public const int AdContactPersonMaxLen = 150;
        public const int AdContactPersonMinLen = 2;
              
        public const int AdContactPhoneMaxLen = 20;
        public const int AdContactPhoneMinLen = 5;

        // Property
        public const int PropertyDescriptionMaxLen = 500;
        public const int PropertyDescriptionMinLen = 2;

        public const int PropertyPriceMaxLen = 10_000_000;
        public const int PropertyPriceMinLen = 1;

        public const int PropertyDepositMaxLen = 10_000_000;
        public const int PropertyDepositMinLen = 1;

        public const int PropertyLeaseMaxLen = 2;
        public const int PropertyLeaseMinLen = 500;

        public const int PropertyLocationMaxLen = 500;
        public const int PropertyLocationMinLen = 2;

        public const int PropertyCountyMaxLen = 50;
        public const int PropertyCountyMinLen = 2;

        public const int PropertyTownMaxLen = 50;
        public const int PropertyTownMinLen = 2;

        // User
        public const int UserNameMaxLen = 50;
        public const int UserNameMinLen = 2;

        public const int UserPasswordMaxLen = 50;
        public const int UserPasswordMinLen = 2;

        public const int UserAddressMaxLen = 150;
        public const int UserAddressMinLen = 2;

        public const int UserPhoneNumberMaxLen = 150;
        public const int UserPhoneNumberMinLen = 2;
    }
}
