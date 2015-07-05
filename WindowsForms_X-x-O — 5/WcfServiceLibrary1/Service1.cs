using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]//Сервер сохраняет все вхождения клиента!!!
    public class Service1 : IService1
    {
        public List<Player> Players = new List<Player>();
        public List<Player> Players_Win = new List<Player>();
        public bool _isAuthorize;
        public Player _player;
        public string[] Coord_Player = new string[2];
        public string[] Player_2 = new string[2];

        public bool Login(string login)//проверка Логина и  регистрация
        {
            if (Players.FindIndex(x => x.Login == login) >= 0)//Если такой login есть, отменяем вставку
            {
                _player = Players.Find(x => x.Login == login);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Return {0}", _player.Login);
                Console.ResetColor();
                return false;
            }
            else
            {
                _player = new Player(login);
                Players.Add(_player);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login {0}  Lenth {1}", login, Players.Count);
                Console.WriteLine(">>>>>AllPlayer<<<<<<");
                Console.ResetColor();
            }
            _isAuthorize = true;
            return true;
        }

      


        public string[] GetAllPlayerGame222(string login)//получаем 2х игроков для Игры
        {
            Console.WriteLine("получаем 2 игрока для Игры2222<<<<<<<<");
            Console.WriteLine("Login {0}  ", login);

            Console.WriteLine(" Login ------");
            int t = Players.FindIndex(x => x.Login == login);//Номер индекса Игрока
            Console.WriteLine("Players_Win.IndexOf(_player) {0}", t);

            int Count = Players.Count;//длинна Списка
            Console.WriteLine("Players.Count(): {0}", Count);


            if ((t + 1) % 2 == 0)
            {


                Player_2[0] = login;
                Player_2[1] = Players[t - 1].Login;
                Console.WriteLine("(t + 1) % 2 == 0 Login {0}  : {1}", Player_2[0], Player_2[1]);


            }
            else
            {
                Console.WriteLine("ghh");
                if ((t + 1) % 2 != 0)
                {

                    if (Count % 2 == 0)
                    {
                        Player_2[0] = Players[t + 1].Login;
                        Player_2[1] = login;
                        Console.WriteLine("(t + 1) % 2 != 0 && Count%2==0  Login {0}  : {1}", Player_2[1], Player_2[0]);

                    }

                    else
                    {
                        Console.WriteLine("error");
                        Player_2[0] = "error";
                        Player_2[1] = "error";

                    }
                }
            } return Player_2;
        }

      

        public void SendCoord(string Player, int Namber)// отправка   координаты Серверу
        {
            Console.WriteLine(">>>>>>> получение координаты  Серверу <<<<<<<");
            Coord_Player[0] = Player;
            Coord_Player[1] = Convert.ToString(Namber);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} SendCoord : ({1})", Player, Namber);
            Console.ResetColor();


        }

        public string[] SendCoordOpponent()// получение координаты Сопернику
        {

            Console.WriteLine(">>>>>>> отправка координаты Сопернику <<<<<<<");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} SendCoordOpponent : ({1})", Coord_Player[0], Coord_Player[1]);
            Console.ResetColor();

            return Coord_Player;
        }



        //победа, проигрыш, ничья
        //win, lose, draw

        public void Win_Lose_Draw(string login, string resultGame)//Создаем статистику
        {
            _player = new Player(login, 1);
            if (resultGame == "Win!!!")
            { //int namber= Players_Win.IndexOf(x => x.login == login) ;

                int t = Players_Win.IndexOf(_player);
                // int indexl = racers.IndexOf(mario);

                if (t == -1)
                {
                    Players_Win.Add(_player);
                }
                else //если, такой пользователь существует, то увеличиваем количество Побед на 1
                {
                    int namber = Players_Win[t].Count_Win;
                    namber++;
                    Players_Win[t].Count_Win = namber;
                }

            }

        }

        public List<Player> GetAllPlayerWin()//список играков, которые выйграли
        {
            Players_Win.Sort((x1, x2) => x1.Count_Win.CompareTo(x2.Count_Win));//Сортировка по количеству побед

            // teachers.Sort((teacher1, teacher2) =>
            //teacher1.Name.CompareTo(teacher2.Name));  
            foreach (Player ll in Players_Win)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("{0} GetAllPlayers : {1}", _player.Login, _player.Count_Win);
                Console.ResetColor();
            }

            return Players_Win;
        }


    }
}
