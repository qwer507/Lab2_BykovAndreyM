namespace TestRegUser
{
    [TestFixture]
    public class MaskPasswordTests
    {
        [TestCase("Ййуа1!")]
        public void ValidPassword(string password)
        {
            string result = ConsoleApp1.RegistrationNewUser.MaskPassword(password);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Not.EqualTo("***"));
        }

        [TestCase(null)]
        [TestCase("")]
        public void NullOrEmptyPassword(string? password)
        {
            string result = ConsoleApp1.RegistrationNewUser.MaskPassword(password);

            Assert.That(result, Is.EqualTo("***"));
        }

        [TestCase("Ййуа1!")]
        public void SamePassword(string password)
        {
            string hash1 = ConsoleApp1.RegistrationNewUser.MaskPassword(password);
            string hash2 = ConsoleApp1.RegistrationNewUser.MaskPassword(password);

            Assert.That(hash1, Is.EqualTo(hash2));
        }

        [TestCase("Ййуа1!", "Йкцпм2!")]
        public void DifferentPasswords(string password1, string password2)
        {
            string hash1 = ConsoleApp1.RegistrationNewUser.MaskPassword(password1);
            string hash2 = ConsoleApp1.RegistrationNewUser.MaskPassword(password2);

            Assert.That(hash1, Is.Not.EqualTo(hash2));
        }
    }

    [TestFixture]
    public class LoginTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void NullOrEmptyLogin(string? login)
        {
            string password = "Айайуайуа1!";
            string passwordRepeat = "Айайуайуа1!";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, passwordRepeat)[1];

            Assert.That(result, Is.EqualTo("Логин не может быть пустым."));
        }

        [TestCase("Arty")]
        public void ShortLogin(string login)
        {
            string password = "Айайуайуа1!";
            string passwordRepeat = "Айайуайуа1!";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, passwordRepeat)[1];

            Assert.That(result, Is.EqualTo("Логин должен содержать минимум 5 символов."));
        }

        [TestCase("Русский")]
        [TestCase("aerwfefq@")]
        [TestCase("rwfrwf vrwvwrv")]
        public void LoginWithInvalidChars(string login)
        {
            string password = "Айайуайуа1!";
            string passwordRepeat = "Айайуайуа1!";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, passwordRepeat)[1];

            Assert.That(result, Is.EqualTo("Логин может содержать только латиницу, цифры и знак подчеркивания."));
        }

        [TestCase("admin")]
        public void ReservedLogin(string login)
        {
            string password = "Айайуайуа1!";
            string passwordRepeat = "Айайуайуа1!";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, passwordRepeat)[1];

            Assert.That(result, Is.EqualTo("Данный логин занят. Пожалуйста, выберите другой."));
        }

        [TestCase("rgevberb@mail.ru")]
        [TestCase("rge123b@bk.ru")]
        public void ValidEmailLogin(string login)
        {
            string password = "Айайуайуа1!";
            string passwordRepeat = "Айайуайуа1!";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, passwordRepeat)[1];

            Assert.That(result, Is.Empty);
        }

        [TestCase("+7-123-456-7890")]
        [TestCase("+5-123-455-7531")]
        public void ValidPhoneLogin(string login)
        {
            string password = "Айайуайуа1!";
            string passwordRepeat = "Айайуайуа1!";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, passwordRepeat)[1];

            Assert.That(result, Is.Empty);
        }

        [TestCase("adffaFfr_1")]
        [TestCase("Asdfghj")]
        public void ValidLogin(string login)
        {
            string password = "Айайуайуа1!";
            string passwordRepeat = "Айайуайуа1!";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, passwordRepeat)[1];

            Assert.That(result, Is.Empty);
        }
    }

    [TestFixture]
    public class PasswordTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void NullOrEmptyPassword(string? password)
        {
            string login = "Asdfghj";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, password)[1];

            Assert.That(result, Is.EqualTo("Пароль не может быть пустым."));
        }

        [TestCase("кар")]
        public void ShortPassword(string password)
        {
            string login = "Asdfghj";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, password)[1];

            Assert.That(result, Is.EqualTo("Пароль должен содержать минимум  7 символов."));
        }

        [TestCase("grtgwrgwwrg")]
        [TestCase("капупкупу пеупукеп1!")]
        public void PasswordWithInvalidChars(string password)
        {
            string login = "Asdfghj";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, password)[1];

            Assert.That(result, Is.EqualTo("Пароль может содержать только кириллицу, цифры и спецсимволы."));
        }

        [TestCase("пуепруеруер1!")]
        public void PasswordNoUpperCase(string password)
        {
            string login = "Asdfghj";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, password)[1];

            Assert.That(result, Is.EqualTo("Пароль должен содержать минимум одну букву в верхнем регистре."));
        }

        [TestCase("АКАПЦПЦКП1!")]
        public void PasswordNoLowerCase(string password)
        {
            string login = "Asdfghj";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, password)[1];

            Assert.That(result, Is.EqualTo("Пароль должен содержать минимум одну букву в нижнем регистре."));
        }

        [TestCase("Йуайуайуайу!")]
        public void PasswordNoDigit(string password)
        {
            string login = "Asdfghj";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, password)[1];

            Assert.That(result, Is.EqualTo("Пароль должен содержать минимум одну цифру."));
        }

        [TestCase("Йуайуайуайуа1")]
        public void PasswordNoSpecialSymbol(string password)
        {
            string login = "Asdfghj";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, password)[1];

            Assert.That(result, Is.EqualTo("Пароль должен содержать минимум один спецсимвол."));
        }

        [TestCase("Ячсячмячм1!", "Кацацкацк1!")]
        public void DifferentPasswords(string password1, string password2)
        {
            string login = "Asdfghj";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password1, password2)[1];

            Assert.That(result, Is.EqualTo("Введены разные пароли."));
        }

        [TestCase("Ячсячмячм1!")]
        public void CorrectPassword(string password)
        {
            string login = "Asdfghj";

            string result = ConsoleApp1.RegistrationNewUser.RegisterUser(login, password, password)[1];

            Assert.That(result, Is.Empty);
        }
    }
}