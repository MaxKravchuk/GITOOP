using System;
using System.Dynamic;
using System.Linq;

namespace CWLib
{
    //Delegate which describes the processing method events
    public delegate void NTEvent();

    public delegate void FREvent();

    public class News : IMainMenu //<-Interface Connection
    {

        private string _UserNick;
        private string _Head;
        private string _Tag;
        private string _Text;
        private string AllText;
        private double _Time;

        public News() { }

        public News(string userNick, string head, string tag, string text,double time)
        {
            _UserNick = userNick;
            _Head = head;
            _Tag = tag;
            _Text = text;
            _Time = time;
            AllText = $"About {head} : " + "< " + _Tag + " >" + "\n" + _Text + "\n" + "At " + _Time + " hours\n" + _UserNick;
        }

        //The event that is raised when an input error
        public event NTEvent NoTextEvent;

        //The event that is raised when the program is first run
        public event FREvent FirstEnterEvent;

        //The class of which the user is an element
        public class ArticleAuthor
        {
            public User UserNick { get; set; }
        }

        //The class of which the news article is an element
        public class Article
        {
            public News NewsArticle { get; set; }
        }

        //Array of users
        public ArticleAuthor[] StorageN = new ArticleAuthor[0];

        //Array of news
        public Article[] StorageA = new Article[0];

        //Checking the event for zero and its subsequent call
        public virtual void OnNTEvent()
        {
            if (NoTextEvent != null)
            {
                NoTextEvent();
            }
        }

        public virtual void OnFREvent()
        {
            if (FirstEnterEvent!= null)
            {
                FirstEnterEvent();
            }

        }

        //Empty string check method
        private bool TextChecker(string CurrentText)
        {
            if (CurrentText == String.Empty)
            {
                return true;
            }
            else return false;
        }

        //Main menu function
        public void Control()
        {
            if (StorageN.Length == 0)
            {
                OnFREvent();
                Registration();
            }
            bool flag = true;
            while (flag)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nThis is main menu\nPress [1] to Create new user\nPress [2] to Create new news\nPress [3] to Search news\nPress [0] to Exit");
                Console.Write("--> ");
                int i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        Registration();
                        break;
                    case 2:
                        NewNews();
                        break;
                    case 3:
                        SearchNewsControl();
                        break;
                }
                if(i!=1&& i != 2 && i != 3 && i != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input\n");
                    Control();
                }
                if (i == 0)
                {
                    flag = false;
                    Console.WriteLine("Session is ended");
                }
                Console.ResetColor();
            }
        }//меню

        //New User Registration Method
        public void Registration()
        {
            Console.ResetColor();
            Console.Write("Please enter your future nickname: ");
            string nick = Console.ReadLine();
            if (nick == "")
            {
                OnNTEvent();
                Console.WriteLine("Try again");
                Registration();
            }
            else
            {
                User _User = new User(nick);
                Array.Resize<ArticleAuthor>(ref StorageN, StorageN.Length + 1);
                StorageN[StorageN.Length - 1] = new ArticleAuthor() {UserNick = _User };
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Welcome {StorageN[StorageN.Length - 1].UserNick.Nick}!");
                Console.ResetColor();
                Console.WriteLine();
            }

        }

        //Methods for adding news
        public void NewNews()
        {
            bool Flag = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("News can add only registered users\nEnter your nickname: ");
            Console.ResetColor();
            string NickCheck = Console.ReadLine();
            string CurrentNick;
            foreach (ArticleAuthor nick in StorageN)
            {
                if ((nick.UserNick.Nick == NickCheck))
                {
                    Flag = true;
                    break;
                }
                else Flag = false;
            }
            if (Flag)
            {
                CurrentNick = NickCheck;
                bool flag = true;
                while (flag)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\nThis is the stage of news entry\n\nSelect a category\n1 - About Sport\t2 - About Cars\nPress 0 to return in main menu");
                    Console.Write("--> ");
                    int Key = Convert.ToInt32(Console.ReadLine());
                    switch (Key)
                    {
                        case 1:
                            SportHead(CurrentNick);
                            break;
                        case 2:
                            CarHead(CurrentNick);
                            break;
                    }
                    if (Key != 1 && Key != 2 && Key != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input\n");
                        Console.ResetColor();
                    }
                    if (Key == 0)
                    {
                        flag = false;
                    }
                    Console.ResetColor();
                }
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nickname was not found\nPress 0 to exit or any number to continue");
                Console.ResetColor();
                int Key = Convert.ToInt32(Console.ReadLine());
                if (Key == 0) Control();
                else NewNews();
            }
   
        }

        //Methods for adding sports news
        private void SportHead(string CurrentNick)
        {
            Console.Write("You have chosen a heading sports\nPlease enter your news tags: ");
            string NewsTag = Console.ReadLine();
            if(TextChecker(NewsTag))
            {
                OnNTEvent();
                Console.WriteLine("If you want to return to main menu PRESS 0\nIf you want to continue PRESS 1");
                int Key = Convert.ToInt32(Console.ReadLine());
                if (Key == 1) SportHead(CurrentNick);
                else Control();
            }
            else
            {
                Console.WriteLine($"Your tags {NewsTag}\nEnter news text");
                string NewsText = Console.ReadLine();
                if(TextChecker(NewsText))
                {
                    OnNTEvent();
                    Console.WriteLine("If you want to return to main menu PRESS 0\nIf you want to continue PRESS 1");
                    int Key = Convert.ToInt32(Console.ReadLine());
                    if (Key == 1) SportHead(CurrentNick);
                    else Control();
                }
                else
                {
                    Console.WriteLine("Enter the time of publication of the news");
                    double NewsTime = Convert.ToDouble(Console.ReadLine());
                    News NewNewsArticle = new News(CurrentNick, "Sport", NewsTag, NewsText, NewsTime);
                    CreateNewNews(NewNewsArticle);
                }
            }
        }

        //Methods for adding сar news
        private void CarHead(string CurrentNick)
        {
            Console.Write("You have chosen a heading cars\nPlease enter your news tags: ");
            string NewsTag = Console.ReadLine();
            if(TextChecker(NewsTag))
            {
                OnNTEvent();
                Console.WriteLine("If you want to return to main menu PRESS 0\nIf you want to continue PRESS 1");
                int Key = Convert.ToInt32(Console.ReadLine());
                if (Key == 1) CarHead(CurrentNick);
                else Control();
            }
            else
            {
                Console.WriteLine($"Your tags {NewsTag}\nEnter news text");
                string NewsText = Console.ReadLine();
                if(TextChecker(NewsText))
                {
                    OnNTEvent();
                    Console.WriteLine("If you want to return to main menu PRESS 0\nIf you want to continue PRESS 1");
                    int Key = Convert.ToInt32(Console.ReadLine());
                    if (Key == 1) CarHead(CurrentNick);
                    else Control();
                }
                else
                {
                    Console.WriteLine("Enter the time of publication of the news");
                    double NewsTime = Convert.ToDouble(Console.ReadLine());
                    News NewNewsArticle = new News(CurrentNick, "Car", NewsTag, NewsText, NewsTime);
                    CreateNewNews(NewNewsArticle);
                }
            }
        }
        private void CreateNewNews(News NewNewsArticle)
        {
            Array.Resize<Article>(ref StorageA, StorageA.Length + 1);
            StorageA[StorageA.Length - 1] = new Article() { NewsArticle = NewNewsArticle };
        }

        //Search menu function
        public void SearchNewsControl()
        {
            bool flag = true;
            while (flag)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nThis is the search stage of the news\tSelect the search parameter(s)");
                Console.WriteLine("Press [1] to search by nick\nPress [2] to search by category\nPress [3] to search by tag\nPress [4] to search by time\nPress [0] to exit");
                Console.Write("--> ");
                int i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        NickSearch();
                        break;
                    case 2:
                        HeadSearch();
                        break;
                    case 3:
                        TagSearch();
                        break;
                    case 4:
                        TimeSearch();
                        break;
                }
                if(i!=0 && i != 1 && i != 2 && i != 3 && i != 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input\n");
                    Console.ResetColor();
                }
                if (i == 0)
                {
                    flag = false;
                }
            }
        }

        //Category search method
        private void HeadSearch()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("This is a news heading search");
                Console.WriteLine("Select the heading\nPress 1 to search Sport news \t\tPress 2 to search Car news\n\tPress 0 to Exit");
                int Key = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                switch (Key)
                {
                    case 1:
                        SearchByHead("Sport");
                        break;
                    case 2:
                        SearchByHead("Car");
                        break;
                }
                Console.ResetColor();
                if (Key == 0) flag = false;
            }
        }
        private void SearchByHead(string head)
        {
            foreach (Article ArticleText in StorageA)
            {
                if (ArticleText.NewsArticle._Head == head)
                {
                    Console.WriteLine($"News suitable for your request\n\n{ArticleText.NewsArticle.AllText}");
                    Console.WriteLine();
                }
            }
        }

        //Nickname search method
        private void NickSearch()
        {
            Console.WriteLine("This is news search by nickname\nEnter your nickname");
            string TempNick = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            if (TextChecker(TempNick))
            {
                OnNTEvent();
                NickSearch();
            }
            else
            {
                SearchByNick(TempNick);
            }
            Console.ResetColor();
        }
        private void SearchByNick(string userNick)
        {
            foreach (Article ArticleText in StorageA)
            {
                if (ArticleText.NewsArticle._UserNick == userNick)
                {
                    Console.WriteLine($"News suitable for your request\n\n{ArticleText.NewsArticle.AllText}");
                    Console.WriteLine();
                }
                // else
                // {
                //   Console.WriteLine("Error");
                // }
            }
        }

        //Tag search method
        private void TagSearch()
        {
            Console.WriteLine("This is news search by tags\nEnter tag(s)");
            string TempTag = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            if (TextChecker(TempTag))
            {
                OnNTEvent();
                TagSearch();
            }
            else
            {
                SearchByTag(TempTag);
            }
            Console.ResetColor();
        }
        private void SearchByTag(string tag)
        {
            foreach (Article ArticleText in StorageA)
            {
                if (ArticleText.NewsArticle._Tag == tag)
                {
                    Console.WriteLine($"News suitable for your request\n\n{ArticleText.NewsArticle.AllText}");
                    Console.WriteLine();
                }
            }
        }

        //Time search method
        private void TimeSearch()
        {
            Console.WriteLine("This is a search for news by publication time\nEnter time");
            double TempTime = Convert.ToDouble(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            SearchByTime(TempTime);
        }
        private void SearchByTime(double time)
        {
            foreach (Article ArticleText in StorageA)
            {
                if (ArticleText.NewsArticle._Time == time)
                {
                    Console.WriteLine($"News suitable for your request\n\n{ArticleText.NewsArticle.AllText}");
                    Console.WriteLine();
                }
            }
        }

    }

}
