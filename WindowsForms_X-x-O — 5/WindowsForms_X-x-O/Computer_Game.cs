using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_X_x_O
{
    public partial class Computer_Game : Form
    {
      public Form1 form;
   
        public int NamberPlayer { get; set; }
        public int NamberComputer { get; set; }
        public int NamberMoveG { get; set; }
        public int NamberButtonClick { get; set; }
        public int Number { get; set; }
        //public bool StatistikaComputer { get; set; }

        public string[] NameGame = { "Победа Компьютера", " Победа Игрока", "Ничья" }; //Список Побед
        public int[] CountGame = {0,0,0};



        public int iTurn;    //если 0 – первый ход у игрока, иначе начинает игру компьютер
        public int iPict;    //если 0 – пользователь играет крестиками, иначе - ноликами
        public int GameStatus;    //0-ход игрока, 1 – компьютера, 2 – начало новой игры
        public int[] a = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };   //если 0 – клетка пустая, 1 – занял компьютер, 2 - игрок
        public bool Timer1 = false;


        public string[] Table_Computer = new string[9];
        
      
        public Computer_Game()
        {
            InitializeComponent();


            //listBox1.Visible = false;//статистика


            //  form.Visible = false; //делает окно не видемым
            //StatistikaComputer = false;
            NamberPlayer = -1;
            NamberComputer = -1;
            NamberMoveG = -1;
            //   NamberButtonClick = -1;
            iPict = 0;    //по умолчанию игрок играет крестиками
            iTurn = 0;    //и имеет право первого хода
            GameStatus = iTurn;    //игровой статус – ход игрока  
            //form.Close();

        }

        public Computer_Game(Form1 f)
        {
            this.form = f;
            //this.form = from1;

            InitializeComponent();


            //listBox1.Visible = false;//статистика


            //  form.Visible = false; //делает окно не видемым
            //StatistikaComputer = false;
            NamberPlayer = -1;
            NamberComputer = -1;
            NamberMoveG = -1;
            //   NamberButtonClick = -1;
            iPict = 0;    //по умолчанию игрок играет крестиками
            iTurn = 0;    //и имеет право первого хода
            GameStatus = iTurn;    //игровой статус – ход игрока  
            //form.Close();

        }

        //Меню
        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)//Новая игора, обнуляем все значения
        {
            Table_Computer = new string[9];
            NamberPlayer = -1;
            NamberComputer = -1;
            NamberMoveG = -1;

            button1.Text = " ";
            button2.Text = " ";
            button3.Text = " ";
            button4.Text = " ";
            button5.Text = " ";
            button6.Text = " ";
            button7.Text = " ";
            button8.Text = " ";
            button9.Text = " ";

           // clickBatton = false;
            Timer1 = false;
            for (int i = 0; i < 9;i++ ) //обнуляем таблицу            
                {
                    a[i] = 0;                   
                }
            label1.Text = "Новая игра";

        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.Close();
            this.Close();
           
        }


        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //StatistikaComputer = true;
            Statistics newSt = new Statistics(this);
            newSt.Show();


            //listBox1.Items.Clear();
            //listBox1.Visible = true;


            //listBox1.Items.Add(" >>>Статистика<<<");
            ////for (int i = 0; i < 3; i++)
            ////{
            ////    listBox1.Items.Add("dfrtr");
            ////    listBox1.Items.Add(NameGame[i].ToString() + ": " + CountGame[i].ToString());
            ////}
            //Thread.Sleep(9000);

            //listBox1.Visible = false;
        }

        private void поСетиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.Visible = true;
            this.Close();
        }



        /*Ход игрока
        Игрок ходит, нажимая левой кнопкой мыши на свободную ячейку поля.
        Отслеживаем наджатие кнопки по Имени. Делаем проверку, если кнопку пустая заносим значение "х", иначе игнарируем нажатие.
        */
        private void button1_Click(object sender, EventArgs e)
        {



            Button btn = (Button)sender;//отслеживаем по id  на какую кнопку нажали

            //if (btn.Name == "button1")     NamberButtonClick = 0;
            //string a = btn.Name;
            //  MessageBox.Show(btn.Name);
            NamberPlayer = Namber_Click(btn);


            if (a[NamberPlayer] != 1 && a[NamberPlayer] != 2)//проверяем клeтку, если она пустая заносим значение  button "X"
            {
                NamberMoveG = NamberPlayer;
                btn.Text = "X";
                //         MessageBox.Show("X");


                /* Если клетка свободна, то занимаем ее, затем проводим проверку на победу. Если возвращается значение 0, то есть продолжение игры,
           * то передаем ход компьютеру и включаем таймер. Если же игра закончена, то обрабатываем окончание игры.*/


                if (NamberMoveG != -1) a[NamberMoveG] = 2;    //записываем ход Игрока  в таблицу  2= "X";


                //проводим проверку на победу
                if (Checking() == 0)
                {
                    GameStatus = 1;//Ход компьютера
                    Timer1Timer(GameStatus);

                    // Timer1=true;
                }
                else Victory(Checking());

                if (Checking() == 0)
                {
                    GameStatus = 0;//ход игрока
                    Timer1Timer(GameStatus);

                }


            }

            else
            {
                MessageBox.Show(a[NamberPlayer].ToString());
                MessageBox.Show("Эта ячейка занята");
                NamberPlayer = -1;
            }


        }


        //отслеживем, какую нажали  кнопку  и возвращаем номер ячейки в массиве a[NamberButtonClick], где будет занесено значение хода
        public int Namber_Click(Button bt)
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


        /* Проверка на победу
Проверяем строки, столбцы и диагонали поля. Если все три клетки заняты одним значком, 
       то возвращаем чью-нибудь победу, если все клетки заняты, но все линии не содержат трех одинаковых значков, то ничья. 
       В противном случае – продолжаем игру.*/

        public int Checking()     //1 – победа компьютера, 2 -игрока
        {
            int p;
            for (p = 0; p < 9; p = p + 3)    //проверка строк
            {
                if ((a[p] == 1) && (a[p + 1] == 1) && (a[p + 2] == 1))
                    return 1;
                else
                    if ((a[p] == 2) && (a[p + 1] == 2) && (a[p + 2] == 2))
                        return 2;
            }
            for (p = 0; p < 3; p++)        //проверка столбцов
            {
                if ((a[p] == 1) && (a[p + 3] == 1) && (a[p + 6] == 1))
                    return 1;
                else if ((a[p] == 2) && (a[p + 3] == 2) && (a[p + 6] == 2))
                    return 2;
            }
            //проверка диагоналей
            if ((a[0] == 1) && (a[4] == 1) && (a[8] == 1)) return 1;
            if ((a[0] == 2) && (a[4] == 2) && (a[8] == 2)) return 2;
            if ((a[2] == 1) && (a[4] == 1) && (a[6] == 1)) return 1;
            if ((a[2] == 2) && (a[4] == 2) && (a[6] == 2)) return 2;
            for (p = 0; p < 9; p++)
                if (a[p] == 0) return 0;         //игр не закончена
            return 3;                         //игра закончена - ничья
        }

        /*  Работа таймера
         Таймер нам нужен для отслеживания текущего статуса игры. 
          Если статус равен 2, то начинается новая игра. 
          Если статус равен 0, то выводим в статусбар сообщение о ходе игрока и останавливаем таймер, пока игрок не сделает ход. 
          Если статус равен 1 (то есть ход компьютера), то делаем его ход и передаем ход игроку (меняем статус), 
          проводим проверку, если она возвращает 0, то игра продолжается, если – то вызываем функцию для обработки победы или ничьей.*/

        public void Timer1Timer(int GameStatus)
        {

            if (GameStatus == 0)
            {
                label1.Text = "Ход игрока";
                Timer1 = false;
            }
            if (GameStatus == 1)
            {
                //   MessageBox.Show("Ход компьютера");
                label1.Text = "Ход компьютера";
                int tem = Step();        //функция хода компьютера


                switch (tem)//присвоение кнопки Хода Компьютера
                {
                    case 0: button1.Text = "O"; break;
                    case 1: button2.Text = "O"; break;
                    case 2: button3.Text = "O"; break;
                    case 3: button4.Text = "O"; break;
                    case 4: button5.Text = "O"; break;
                    case 5: button6.Text = "O"; break;
                    case 6: button7.Text = "O"; break;
                    case 7: button8.Text = "O"; break;
                    case 8: button9.Text = "O"; break;

                }




                GameStatus = 0;        //переход хода игроку
                if (Checking() != 0)    //если игра закончена, то есть проверка возвращает не ноль
                {
                    Victory(Checking());  //вызываем функцию победы - окончание игры
                }
            }
        }


        /* Окончание игры
        Выключаем таймер, пишем информацию в сообщения и статусбар.*/

        public void Victory(int v)
        {
            int t;
            //  Form1->Timer1->Enabled=false;
            if (v == 1)
            {
                t = CountGame[0];//считаем колличество Побед
                CountGame[0] = t + 1;

                MessageBox.Show("Победа компьютера");
                label1.Text = "Победа компьютера";
            }
            else if (v == 2)
            {
                t = CountGame[1];
                CountGame[1] = t + 1;

                MessageBox.Show("Вы победили");
                label1.Text = "Победа игрока";
            }
            else if (v == 3)
            {
                t = CountGame[2];
                CountGame[2] = t + 1;

                MessageBox.Show("Ничья");
                label1.Text = "Ничья";

            }
        }


        /*  Определение критической ситуации
         Проверка на наличие линии с двумя занятыми клетками и одной свободной.
         В функцию передается переменная n – значение, которым может быть элемент массива.
         Эта функция вызывается во время хода компьютера.*/

        public int Varning(int n)
        {        //есть ли линия с двумя занятыми клетками и одной пустой
            //если есть – то передается номер пустой клетки
            //если нет, то возврат -1
            for (int p = 0; p < 9; p = p + 3)
            {
                if ((a[p] == n) && (a[p + 1] == n) && (a[p + 2] == 0))
                    return p + 2;
                else if ((a[p] == n) && (a[p + 1] == 0) && (a[p + 2] == n))
                    return p + 1;
                else if ((a[p] == 0) && (a[p + 1] == n) && (a[p + 2] == n))
                    return p;
            }
            for (int p = 0; p < 3; p++)
            {
                if ((a[p] == n) && (a[p + 3] == n) && (a[p + 6] == 0))
                    return p + 6;
                else if ((a[p] == n) && (a[p + 3] == 0) && (a[p + 6] == n))
                    return p + 3;
                else if ((a[p] == 0) && (a[p + 3] == n) && (a[p + 6] == n))
                    return p;
            }
            if ((a[0] == n) && (a[4] == n) && (a[8] == 0)) return 8;
            if ((a[0] == n) && (a[4] == 0) && (a[8] == n)) return 4;
            if ((a[0] == 0) && (a[4] == n) && (a[8] == n)) return 0;
            if ((a[2] == n) && (a[4] == n) && (a[6] == 0)) return 6;
            if ((a[2] == n) && (a[4] == 0) && (a[6] == n)) return 4;
            if ((a[2] == 0) && (a[4] == n) && (a[6] == n)) return 2;
            return -1;
        }

        /*  Ход компьютера
           Компьютер решает, куда бы ему сходить.
         * Если есть одна свободная клетка в линии с двумя занятыми им же, то он ее занимает и побеждает.
         * Если есть свободная клетка в линии, занятой игроком, то он ее занимает и не дает победить игроку.
         * Если свободна средняя кнопка, то он ее занимает, как самую выгодную позицию.
         * Следующая позиция – угловая клетка, позволяет контролировать три линии. И, если больше некуда податься, то занимает среднюю боковую клетку.
         * После установки значок крестика или нолика рисуется на форме.*/

        public int Step()
        {
            int number;
            number = Varning(1);//есть ли линия с двумя занятыми компьютером //клетками
            if (number != -1)//если есть, занимает свободную клетку и побеждает
            {
                //MessageBox.Show("если есть, занимает свободную клетку и побеждает");
                //MessageBox.Show(number.ToString() );
                a[number] = 1;
                //  Form1->im1->Canvas->Draw(xPos[number]+7,yPos[number]+7,compIcon);
                return number;
            }
            if (GameStatus != 0)
            {
                // MessageBox.Show("есть ли линия с двумя занятыми игроком клеткамил");
                number = Varning(2);    //есть ли линия с двумя занятыми игроком клетками
                if (number != -1)   //если есть, занимает свободную клетку, чтобы не победил
                //игрок
                {
                    //MessageBox.Show("если есть, занимает свободную клетку, чтобы не победил");
                    //MessageBox.Show(number.ToString());
                    a[number] = 1;
                    //  Form1->im1->Canvas->Draw(xPos[number]+7,yPos[number]+7,compIcon);
                    return number;
                }
                if (a[4] == 0)    //если свободна средняя клетка – занять ее
                {
                    //MessageBox.Show("если свободна средняя клетка – занять ее");
                    //MessageBox.Show(4.ToString());
                    a[4] = 1;
                    //  Form1->im1->Canvas->Draw(xPos[4]+7,yPos[4]+7,compIcon);
                    return 4;
                }
                for (int p = 0; p < 9; p = p + 2)    //занять свободную угловую клетку
                {
                    if (a[p] == 0)
                    {
                        //MessageBox.Show("занять свободную угловую клетку");
                        //MessageBox.Show(p.ToString());
                        a[p] = 1;
                        //  Form1->im1->Canvas->Draw(xPos[p]+7,yPos[p]+7,compIcon);
                        return p;
                    }
                }
                for (int p = 0; p < 9; p++)    //занять любую свободную клетку
                {
                    // MessageBox.Show("занять любую свободную клетку");
                    if (a[p] == 0)
                    {
                        //MessageBox.Show("занять любую свободную клетку11111");
                        //MessageBox.Show(p.ToString());
                        a[p] = 1;
                        // Form1->im1->Canvas->Draw(xPos[p]+7,yPos[p]+7,compIcon);
                        return p;
                    }
                }
            }
            return number;
        }

        //private void Computer_Game_FormClosed(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //   // this.Close();
        //  //  Form4_Closed(object sender, EventArgs e)
        //}
        //private void Computer_Game_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    // this.Close();

        //}
        //void Form4_Closed(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

    }
}
