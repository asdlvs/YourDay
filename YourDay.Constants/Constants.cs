using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.Constants
{
    public static class Strings
    {
        public const string City = "Город";
        public const string Rating = "Рейтинг";
        public const string Specialization = "Специализация";
        public const string Feedbacks = "Отзывы";
        public const string Events = "События";
        public const string OnLineStatus = "Статус";
        public const string OnLineStatusOnLine = "<span class=\"online\">Сейчас на сайте</span>";
        public const string OnLineStatusOffLine = "<span class=\"offline\">Нет на сайте</span>";
        public const string OnLineStatusOnLineWithoutColor = "Сейчас на сайте";
        public const string OnLineStatusOffLineWithoutColor = "Нет на сайте";
        //#caabab


        public const string CityLink = "cityLink";
        public const string SubcategoryLink = "subcategoryLink";
        public const string EventCardLink = "eventCardLink";
        public const string EventCardPhotoesLink = "eventCardPhotoesLink";
        public const string EventCardVideosLink = "eventCardVideosLink";
        public const string EventCardCommentsLink = "eventCardCommentsLink";

        public const string AddToEvent = "Добавить к событию";
        public const string SendMessage = "Отправить сообщение";
        public const string AddToFavourites = "Добавить в избранное";
        public const string LoadPrice = "Посмотреть цены";

        public const string ContactInfoTitle = "Контактная информация";
        public const string Telephone = "Телефон";
        public const string Site = "Сайт";
        public const string Mail = "E-mail";
        public const string VK = "В контакте";
        public const string Facebook = "Фейсбук";
        public const string Twitter = "Твиттер";

        public const string DescriptionTitle = "Описание деятельности";
        public const string AdditionalTitle = "Дополнительно";
        public const string Article = "Статьи";
        public const string News = "Новости";

        public const string EventReports = "Отчеты о событиях";

        public const string RegistrationTitle = "Регистрация";
        public const string EMail = "E-mail";
        public const string Pwd = "Пароль";
        public const string ConfirmPwd = "Подтвердите пароль";

        public const string RegistrationComplete = "Goood!!!";

        public const string EventCard = "Карточка события";
        public const string EventCardTitle = "Название события";
        public const string EventCardType = "Тип события";
        public const string Date = "Дата";
        public const string Time = "Время";
        public const string From = "с";
        public const string To = "до";
        public const string EventCardDescription = "Описание события";
        public const string WhoSee = "Кому видно";
        public const string Budjet = "Бюджет";
        public const string Currency = "руб.";
        public const string EventCardSearchCategory = "Категории поиска:";
        public const string AddEventCardCategory = "Добавьте категории агентов";
        public const string ShowPlacementFrom = "Показывать предложения от:";
        public const string EventAgencyWhom = "Event-агенств";
        public const string ContractorsWhom = "Контрагентов";
        public const string MyEvents = "Мои события";

        public const string Orderer = "Заказчик: ";
        public const string Event = "События";
        public const string PaymentStatus = "Статус оплаты";

        public const string NotApprovedText = "Вы не являетесь авторизованным пользователем, поэтому доступный вам функционал урезан.<br /> Для авторизации необхожимо пройти по ссылке, указанной в письме, которое было вам выслано при регистрации. Если вы не получили письмо, мы можем выслать <a href=\"#\" onclick=\"{0};return false;\">его повторно</a>.";


        public static class JS
        {
            public const string AddToEC = "AddToEC";
            public const string AddToFavourite = "AddToFavourite";
            public const string SendMessage = "SendMessage";
            public const string LoadPrice = "LoadPrice";
        }

        public static Dictionary<int, string> WhoSeeDictionary =
            new Dictionary<int, string>() { {1, "Только мне"}, {2 ,"Всем"}};

        public static Dictionary<string, string> ContractorHimselfLeftLinks =
            new Dictionary<string, string>() { 
            {"Каталог заказов", "~/contractor/orders/"},
            {"Статья", "~/contractor/articles/"}//,
            //{"Цены", "~/contractor/prices/"}

            };

        public static List<Tuple<int, string, string>> Days =
            new List<Tuple<int, string, string>>() { 
            new Tuple<int, string, string>(1, "Понедельник", "Пн"),
            new Tuple<int, string, string>(2, "Вторник", "Вт"),
            new Tuple<int, string, string>(3, "Среда", "Ср"),
            new Tuple<int, string, string>(4, "Четверг", "Чт"),
            new Tuple<int, string, string>(5, "Пятница", "Пт"),
            new Tuple<int, string, string>(6, "Суббота", "Сб"),
            new Tuple<int, string, string>(0, "Воскресенье", "Вс")
            };

        public static Dictionary<string, string> ContractorHeaderLinkDictionary = 
            new Dictionary<string,string>(){
            {"События", "/events/"},
            {"Отчеты", "/reps/"},
            {"Сообщения", "/messages/"},
            {"Избранное", "/favourites/"},
            {"Настройки", "/preferences/"}
            };

        public static Dictionary<string, string> SimpleUserHeaderLinkDictionary =
           new Dictionary<string, string>(){
            {"События", "/events/"},
            {"Сообщения", "/messages/"},
            {"Избранное", "/favourites/"},
            {"Настройки", "/preferences/"}
            };

        public static Dictionary<int, string> EventCardCompanyStatuses =
        new Dictionary<int, string>() { 
        {(int)Constants.Enums.EventCardCompanyStatus.Offer, "Заказ"},
        {(int)Constants.Enums.EventCardCompanyStatus.ContractorCancel, "Отменен"},
        //{(int)Constants.Enums.EventCardComanyStatus.UserCancel, "Отменен заказчиком"},
        {(int)Constants.Enums.EventCardCompanyStatus.Payed, "Оплачено"},
        {(int)Constants.Enums.EventCardCompanyStatus.Order, "Не оплачено"}
        };

        public static Dictionary<Type, string> PocoTypesCacheName =
            new Dictionary<Type, string>()
        {
            {typeof(POCO.Contractor), "contractors"},
            {typeof(POCO.SimpleUser), "simpleusers"},
            {typeof(POCO.Category), "categories"},
            {typeof(POCO.EventCard), "eventcards"},
            {typeof(POCO.Article), "articles"},
            {typeof(POCO.News), "news"},
            {typeof(POCO.EventCardCompany), "eventcardcompanies"},
            {typeof(POCO.EventCardType), "eventcardtypes"},
            {typeof(POCO.Comment), "comments"},
            {typeof(POCO.FavouriteItem), "favouriteitems"}
        };

        public static Dictionary<string, string> MessagesTypes =
            new Dictionary<string, string>() 
            { 
                 {"Все", "~/messages/"}
                ,{"Входящие", "~/messages/in/"}
                ,{"Исходящие", "~/messages/out/"}
                //,{"Удаленные", "~/contractor/messages/re/"}
                //,{"in","Спам"}
            };

        public static Dictionary<string, string> ContractorPreferencesMenuItems =
            new Dictionary<string, string>() 
            { 
                {"Личная информация", "~/preferences/"},
                {"Контактная информация", "~/preferences/ci/"},
                {"Описание деятельности", "~/preferences/actdesc/"},
                {"Смена пароля", "~/preferences/pwd/"},
                {"Загрузка аватара", "~/preferences/img/"}
                
            };
        public static Dictionary<string, string> SimpleUserPreferencesMenuItems =
           new Dictionary<string, string>() 
            { 
                {"Личная информация", "~/preferences/"},
                {"Смена пароля", "~/preferences/pwd/"},
                {"Загрузка аватара", "~/preferences/img/"}
                
            };

        public static Dictionary<string, string> BottomProjectLinks =
            new Dictionary<string, string>()
            {
                {"Реклама на сайте", "/adv/"},
                {"О YourDay", "/we/"},
                {"Контактная информация", "/ci/"}
            };
    }
}
