namespace Luxor.Common
{
    public class EntityClassesValidations
    {
        public static class Booking
        {
            public const int BookingAmountMaxLength = 5000;
        }
        public static class Employee
        {
            public const int EmployeeNameMaxLength = 100;
            public const int EmployeePositionMaxLength = 50;
            public const int EmployeeSalaryMaxLength = 1000000;
        }
        public static class Guest
        {
            public const int GuestNameMaxLength = 100;
            public const int GuestEmailMaxLength = 100;
            public const int GuestPhoneMaxLength = 15;
        }
        public static class Room
        {
            public const int RoomNumberMaxLength = 10;
            public const int RoomTypeMaxLength = 50;
            public const int RoomPriceMaxLength = 10000;
        }
        public static class Service
        {
            public const int ServiceNameMaxLength = 100;
            public const int ServicePriceMaxLength = 10000;
        }
        public static class Feedback
        {
            public const int FeedbackCommentMaxLength = 500;
        }
    }
}