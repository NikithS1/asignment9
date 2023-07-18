using System;

namespace UserRegistration
{
    // Custom exception for validation errors
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("User Registration");
                Console.WriteLine("------------------");

                // Prompt the user to enter their name
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();

                // Prompt the user to enter their email
                Console.Write("Enter your email: ");
                string email = Console.ReadLine();

                // Prompt the user to enter their password
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                // Validate the user input
                ValidateRegistrationData(name, email, password);

                // If input is valid, display success message and registration details
                Console.WriteLine("\nUser registration success!");
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Email: " + email);
                Console.WriteLine("Password: " + password);
            }
            catch (ValidationException ex)
            {
                // Catch and display the validation exception message
                Console.WriteLine("\nValidation error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Catch and display other exceptions
                Console.WriteLine("\nAn error occurred: " + ex.Message);
            }
        }

        static void ValidateRegistrationData(string name, string email, string password)
        {
            // Check for missing or empty values
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Name is required.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ValidationException("Email is required.");

            if (string.IsNullOrWhiteSpace(password))
                throw new ValidationException("Password is required.");

            // Validate name length
            if (name.Length < 6)
                throw new ValidationException("Name must have at least 6 characters.");

            // Validate password length
            if (password.Length < 8)
                throw new ValidationException("Password must have at least 8 characters.");
        }
    }
}
