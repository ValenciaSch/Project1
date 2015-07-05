using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WcfServiceLibrary1;
using WindowsForms_X_x_O.ServiceReference1;
using System.Threading;
using System.Collections;

namespace WindowsForms_X_x_O
{
    public partial class Form1 : Form
    {

        Service1Client client;
      //  Statistika st;
        public int NamberButtonClick { get; set; }//
        public int NamberMove { get; set; }//номер хода игрока
        public string NamePlayer { get; set; }
        public string NameOpponent { get; set; }

        public string NamePlayer_X;
        public string NameOpponent_O;
        public bool StatistikaForm1 { get; set; }

        public Button btn;

        public string[] Table_Game = new string[9];
        public string[] name2Logina = new string[2];

        public List<Player> Players_Win = new List<Player>(); //Список Побед
        public List<string> stringPlayers_Win = new List<string>(); //Список Побед

        //   public  string [] name2Logina

        public bool flag = true; //можно поставить знак Х, только один раз!!!
        public bool flag1 = false;// первый ход делает противник=false, true - ничего не выполняем
        public bool flag2 = true;

        //   public bool flag1 = false;
        public string rezaltGame1 { get; set; }

        public Form1()
        {
            InitializeComponent();

            client = new Service1Client();
            NamberMove = -1;
            NamberButtonClick = -1;
            button11.Enabled = false;
            StatistikaForm1 = false;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }


        //Меню
       

        private void сКомпьютеромToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //Computer_Game newForm = new Computer_Game();
            Computer_Game newForm = new Computer_Game(this);
            newForm.Show();

        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)//очищаем таблицу
            {
                Table_Game[i]="0";
            }

            //  name2Logina = new string[2];
            button1.Text =" ";
            button2.Text =" ";
            button3.Text =" ";
            button4.Text =" ";
            button5.Text =" ";
            button6.Text =" ";
            button7.Text =" ";
            button8.Text =" ";
            button9.Text = " ";

                 listBox1.Items.Add("Новая игра");
                 if (name2Logina[1] == NamePlayer)
                 { MessageBox.Show("MMM");



  button1.Enabled = false;
                     button2.Enabled = false;
                     button3.Enabled = false;
                     button4.Enabled = false;
                     button5.Enabled = false;
                     button6.Enabled = false;
                     button7.Enabled = false;
                     button8.Enabled = false;
                     button9.Enabled = false;

                     button11.Enabled = false;

                     MessageBox.Show("MMM1111-ждет хода");


                     listBox1.Items.Add(" Первым ходит");
                     listBox1.Items.Add(" Противник");

                   

                     //       MessageBox.Show(" Ждем хода противника2222");
                     Thread client_thread = new Thread(stepOpponent11111);
                     client_thread.IsBackground = true;
                     client_thread.Start(NameOpponent);
                 }
                 else
                 {
                     button11.Enabled = true;

                     button1.Enabled = true;
                     button2.Enabled = true;
                     button3.Enabled = true;
                     button4.Enabled = true;
                     button5.Enabled = true;
                     button6.Enabled = true;
                     button7.Enabled = true;
                     button8.Enabled = true;
                     button9.Enabled = true;
                 }
        }
            

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(" >>>Статистика<<<");          

            Players_Win.Clear();
            Players_Win.AddRange(client.GetAllPlayerWin());

         //   ArrayList myList = new ArrayList();


           // stringPlayers_Win.Clear();

            //foreach (Player p in Players_Win)
            //{
            //   // myList.Add(p.Login,p.Count_Win);
            //    stringPlayers_Win.Add (p.Login+": "+p.Count_Win);
            //}
            foreach (Player p in Players_Win)
            {
                listBox1.Items.Add(p.Login + ":" + p.Count_Win);
            }
            listBox1.Items.Add(" >>>>>><<<<<<");


            //StatistikaForm1 = true;
            //Statistika newSt = new Statistika();
            //newSt.Show();

        }


        //>>>>>>>>>>Начинаем Игру!!!!<<<<<<<<<<<<<


        private void button10_Click(object sender, EventArgs e) //Регистация Логина в Сети
        {
            if (textBox1.Text != "")
            {
                NamePlayer = textBox1.Text;
                if (client.Login(textBox1.Text))
                {
                    button10.Enabled = false;
                    textBox1.Enabled = false;
                    button11.Enabled = false;

                    //  button11.IsEnabled = true;
                    listBox1.Items.Add(" Login:" + NamePlayer);
                    listBox1.Items.Add("Поиск соперника");



                    try
                    {
                        Thread client_thread = new Thread(ScanLogin);
                        client_thread.IsBackground = true;
                        client_thread.Start(NamePlayer);
                        //   MessageBox.Show("Pbota Stard!!!");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Сервер не работает");
                        // MessageBox.Show(ex.Message); //ex; //e.err
                    }



                }
                else
                {
                    MessageBox.Show("Такой login уже имеется, придумайте новый.");

                }
            }
            else { MessageBox.Show("Пустой login ..."); }

        }



        public void ScanLogin(object sender) //Делегат для фонового потока обработки  Для получения 2х играков
        {
            string MMM = (string)sender;
       //     MessageBox.Show(MMM + "ScanLogin");
            bool flag1 = true;
            while (flag1)
            {

                name2Logina = client.GetAllPlayerGame222(MMM);

                if (name2Logina[0] == MMM)
                { // MessageBox.Show(MMM);

                    NamePlayer = name2Logina[0];
                    NameOpponent = name2Logina[1];
                    NamePlayer_X = "X";
                    NameOpponent_O = "O";
                    listBox1.Items.Add(NamePlayer + " : X");
                    listBox1.Items.Add(NameOpponent + " : O");
                    button11.Enabled = true;

                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = true;
                    button8.Enabled = true;
                    button9.Enabled = true;

                    flag1 = false;
                    //  return;
                    //MessageBox.Show("Противник: " + NameOpponent + " : O");
                }
                if (name2Logina[1] == MMM)
                { // MessageBox.Show("MMM");

                    NamePlayer = name2Logina[1];
                    NameOpponent = name2Logina[0];
                    NamePlayer_X = "O";
                    NameOpponent_O = "X";

                    listBox1.Items.Add(NamePlayer + " : 0");
                    listBox1.Items.Add(NameOpponent + " : X");
                    listBox1.Items.Add(" Первым ходит");
                    listBox1.Items.Add(" Противник");                   
                    flag1 = false;

                    try
                    {

                        //       MessageBox.Show(" Ждем хода противника2222");
                        Thread client_thread = new Thread(stepOpponent11111);
                        client_thread.IsBackground = true;
                        client_thread.Start(NameOpponent);

                    }
                    catch (Exception ex)
                    {
                       MessageBox.Show("Сервер не работает");
                    }

                    // return;
                    //    stepOpponent11111(NameOpponent);

                    //MessageBox.Show("Противник: " + NameOpponent + " : O");
                    //MessageBox.Show(" Ждем хода противника");

                }


                Thread.Sleep(1000);
                //  MessageBox.Show("Pbota333");
            } // MessageBox.Show(MMM + "ScanLogin2222");

            //  MessageBox.Show("Pbota End!!!");
        }


        private void button1_Click(object sender, EventArgs e)//Нажатие игрового поля
        {
            Button btn = (Button)sender;//отслеживаем по id  на какую кнопку нажали


            NamberButtonClick = Namber_Click(btn);


            if (Table_Game[NamberButtonClick] != "X" && Table_Game[NamberButtonClick] != "O")
            {
                if (flag)
                {
                    btn.Text = NamePlayer_X;
                    flag = false;

                }
            }

            else
            {
                MessageBox.Show("Эта ячейка занята");
                NamberButtonClick = -1;
            }
        }



        public int Namber_Click(Button bt)//отслеживем по нажатой  Номер кнопки
        {
            switch (bt.Name)
            {
                case "button1": NamberButtonClick = 0; break;
                case "button2": NamberButtonClick = 1; break;
                case "button3": NamberButtonClick = 2; break;
                case "button4": NamberButtonClick = 3; break;
                case "button5": NamberButtonClick = 4; break;
                case "button6": NamberButtonClick = 5; break;
                case "button7": NamberButtonClick = 6; break;
                case "button8": NamberButtonClick = 7; break;
                case "button9": NamberButtonClick = 8; break;
            }
            return NamberButtonClick;
        }


        private void button11_Click(object sender, EventArgs e)//Отправка ХОда!!!!
        {


            //отправка хода на Сервер
            if (NamberButtonClick != -1)
            {
                flag = true;
                client.SendCoord(NamePlayer, NamberButtonClick);//оправляем координаты серверу
                Table_Game[NamberButtonClick] = NamePlayer_X;
                button11.Enabled = false;


                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;




                Win_Draw_Game();//проверка игры на Выиграш, Ничья, Проигрыш
                bool gamePlayer = End_Game(NamePlayer, rezaltGame1);

                if (gamePlayer) //если игра продолжаеться, то Ход противника!!!!
                {
                    //  MessageBox.Show("Ждем хода Соперника");
                    //   stepOpponent11111(NameOpponent);


                    try
                    {
                        Thread client_thread = new Thread(stepOpponent11111);
                        client_thread.IsBackground = true;
                        client_thread.Start(NameOpponent);
                        //MessageBox.Show("Pbota Stard!!!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show( "Сервер не работает");
                    }

                }
            }
        }




        public void stepOpponent11111(object name)//ход Оппонента
        {
            string nameOppon = (string)name;

            // string nameOppon = (string)sender;
            flag2 = true;
            int date1 = DateTime.Now.Minute;
            //   MessageBox.Show("stepOpponent11111");
            while (flag2)
            {
                //получение ответ с Сервера
                string[] Opponent = client.SendCoordOpponent();
                //MessageBox.Show("client.SendCoordOpponent()");
                if (Opponent[0] == nameOppon)//если Имя соотвествует нашему Противнику
                {
                    // MessageBox.Show("Имя соотвествует нашему Противнику");
                    //MessageBox.Show(Opponent[0]);
                    //MessageBox.Show(Opponent[1]);
                    int NamberButtonOOO = Convert.ToInt32(Opponent[1]);
                    Table_Game[NamberButtonOOO] = NameOpponent_O;

                    switch (NamberButtonOOO)
                    {
                        case 0: button1.Text = NameOpponent_O; break;
                        case 1: button2.Text = NameOpponent_O; break;
                        case 2: button3.Text = NameOpponent_O; break;
                        case 3: button4.Text = NameOpponent_O; break;
                        case 4: button5.Text = NameOpponent_O; break;
                        case 5: button6.Text = NameOpponent_O; break;
                        case 6: button7.Text = NameOpponent_O; break;
                        case 7: button8.Text = NameOpponent_O; break;
                        case 8: button9.Text = NameOpponent_O; break;

                    }


                    //    MessageBox.Show(Opponent[0] + "2222222");

                    if ((date1 + 2) == DateTime.Now.Minute)//ждем 2 минуты , если Противник не походил, то он пропускает Ход.
                    {

                        MessageBox.Show(nameOppon + "пропускет ход ");
                        button11.Enabled = true;
                        return;
                    }


                    Win_Draw_Game();

                    if (End_Game(nameOppon, rezaltGame1))
                        
                    {button11.Enabled = true;//проверка,  конец или продолжение игры

                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = true;
                    button8.Enabled = true;
                    button9.Enabled = true;
                    
                    
                    
                    }

                    flag2 = false;
                    Thread.Sleep(1000);
                }

            } //MessageBox.Show("stepOpponent11111--2222");
        }





        //победа, проигрыш, ничья
        //win, lose, draw
        public string Win_Draw_Game()
        {
            rezaltGame1 = "Next";
            string Name;
            int count = 1;
            foreach (string s in Table_Game)
            {
                if (s == "O" || s == "X")
                    count++;
            }
            if (count == 9)
            {
                rezaltGame1 = "Draw";
                listBox1.Items.Add("Ничья");
                MessageBox.Show("Ничья");
                return rezaltGame1;
            }

            for (int i = 0; i < 7; i = i + 3)//проверка по горизонтали
            {
                if ((Table_Game[i] == "O" && Table_Game[i + 1] == "O" && Table_Game[i + 2] == "O") || (Table_Game[i] == "X" && Table_Game[i + 1] == "X" && Table_Game[i + 2] == "X"))
                {
                    Name = Table_Game[i];
                    rezaltGame1 = "Win!!!";
                    listBox1.Items.Add(Name + "  Победил!!!");
                    MessageBox.Show(Name + " Победил!!");
                    return rezaltGame1;
                }
            }

            for (int i = 0; i < 3; i++)//проверка по вертикали
            {
                if ((Table_Game[i] == "O" && Table_Game[i + 3] == "O" && Table_Game[i + 6] == "O") || (Table_Game[i] == "X" && Table_Game[i + 3] == "X" && Table_Game[i + 6] == "X"))
                {
                    Name = Table_Game[i];
                    rezaltGame1 = "Win!!!";
                    listBox1.Items.Add(Name + "  Победил!!!");
                    MessageBox.Show(Name + " Победил!!");
                    return rezaltGame1;
                }
            }

            if ((Table_Game[0] == "O" && Table_Game[4] == "O" && Table_Game[8] == "O") || (Table_Game[0] == "X" && Table_Game[4] == "X" && Table_Game[8] == "X")

               || (Table_Game[2] == "O" && Table_Game[4] == "O" && Table_Game[6] == "O") || (Table_Game[2] == "X" && Table_Game[4] == "X" && Table_Game[6] == "X")) //по диагонали
            {
                {
                    Name = Table_Game[0];
                    rezaltGame1 = "Win!!!";
                    listBox1.Items.Add(Name + "  Победил!!!");
                    MessageBox.Show(Name + " Победил!!");
                    return rezaltGame1;
                }
            }


            return rezaltGame1;
        }


        //окончание игры  
        public bool End_Game(string NameLogin, string rezaltGame)
        {
            if (rezaltGame1 == "Win!!!")
            {
                client.Win_Lose_Draw(NameLogin, rezaltGame);//отправляем на Сервер имя победителя               
                // rezaltGame1 = "next";
                button11.Enabled = false;
                return false;
            }
            else
            {
                if (rezaltGame1 == "Next") return true;
                else return false;

            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           // this.Close();
        }




    }
}
