namespace Luxor.Common
{
    public class EntityClassesValidation
    {
        public static class Employee
        {
            public const int EmployeeFirstNameMaxLength = 50;
            public const int EmployeeLastNameMaxLength = 50;
            public const int EmployeePositionMaxLength = 60;
            public const int EmployeePhoneNumberMaxLength = 15;
            public const int EmployeeEmailMaxLength = 100;
            public const int EmployeeAddressMaxLength = 200;
        }
        public static class Feedback
        {
            public const int FeedbackCommentMaxLength = 500;
        }
        public static class Guest
        {
            public const int GuestFirstNameMaxLength = 50;
            public const int GuestLastNameMaxLength = 50;
            public const int GuestPhoneNumberMaxLength = 15;
            public const int GuestPasswordMaxLength = 25;
            public const int GuestEmailMaxLength = 100;
            public const int GuestAddressMaxLength = 200;
        }
        public static class Room
        {
            public const int RoomNumberMaxLength = 5;
            public const int RoomDescriptionMaxLength = 300;
        }
        public static class Service
        {
            public const int ServiceNameMaxLength = 50;
            public const int ServiceDescriptionMaxLength = 300;
        }
    }
}
