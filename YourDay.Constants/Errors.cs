using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.Constants
{
    public class Errors
    {
        public const string RegexLoginError = "E-mail введен неправильно.";
        public const string UserAlreadyExist = "Пользователь с таким e-mail уже зарегистрирован.";
        public const string ConfirmPasswordError = "Пароли не совпадают.";
        public const string EventCardTitleEmpty = "( длина должна быть больше 5 символов )";
        public const string EventCardDescriptionEmpty = "( длина должна быть больше 25 символов )";
    }
}
