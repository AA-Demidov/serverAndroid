using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerAndroid
{
    public partial class Form1 : Form
    {
        public struct message // объявляем структуру для массива
        {
            public string NAME;
            public string UUID;
            public string RSSI;
        } 
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;
        private void Form1_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer(); 
            server.Delimiter = 0x13;//enter
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;
        }

        public void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            lstStatus.Invoke((MethodInvoker)delegate () //получение сообщения
            {
                //lstStatus.Items.Add(e.MessageString); // заполняем lstStatus
                txtStatus.Text += e.MessageString; // заполняем lstStatus
                e.ReplyLine(string.Format("You said: {0}", e.MessageString));
            });
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //старт сервера
            //txtStatus.Text += "Server running";
            btnStart.BackColor = Color.GreenYellow;//кнопка стоп - зеленая
            btnStop.BackColor = Color.IndianRed;//кнопка стоп - зеленая
            btnStop.Enabled = true;//кнопка стоп - неактивна
            btnStart.Enabled = false;//кнопка старт - активна
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(txtHost.Text);
            server.Start(ip, Convert.ToInt32(txtPort.Text));// запускаем сервер по заданному айпи и порту
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)// если запущен останавливаем
            {
                server.Stop();// выключаем сервер
                btnStop.BackColor = Color.GreenYellow; //кнопка стоп - зеленая
                btnStart.BackColor = Color.IndianRed;//кнопка старт - красная
                btnStop.Enabled = false; //кнопка стоп - неактивна
                btnStart.Enabled = true;//кнопка старт - активна
                // txtStatus.Text += "Server stopped";
            }

        }

        public void btnScan_Click(object sender, EventArgs e)
        {
            message[] infoMess = new message[1000]; // объявление массив структуры для хранения данных с телефона и выделить память для 1000 структур типа message
            string tempstr = ""; // временная переменная дл сохранения инфорация ДО нахождения пробела
            int tempfr = -1;// переменнная для подсчета фрагментов, всего их 3 как и пробелов в одном сообщение
            string tempNAME = ""; // временная переменная для хранения имени владельца МУ (мобильного устройства)
            string tempUUID = "";// временная переменная для хранения айди метки
            string str = txtStatus.Text;// переменная для поиска пробелов
            int temp=-1; //временная переменная для заполнения массива
            int tempSR=0;//переменная для среднего значения RSSI
            int Summ5 = 0;//переменная для суммы последних 5 элементов
            string strUUID = ""; // строка для идентификации метки и позиционирования МУ
            string tempstrUUID = ""; // строка для нахождения символов индефикатора

            lst1room.Items.Clear();
            lst2room.Items.Clear();
            lst3room.Items.Clear();
            lst4room.Items.Clear();

            for (int i = 0; i < str.Length; i++) // перебираем строку получаемого сообщения от телефона
            {
                if (str[i] == ' ') //поиск пробела
                {
                    tempfr += 1;// прошли один фрагмент

                    if (tempfr == 0) // 0 фрагмент имя устройства
                        tempNAME = tempstr; //заполняем временную переменную name 

                    if (tempfr == 1) // 1 фрагмент uuid устройства
                        tempUUID = tempstr;

                    if (tempfr == 2)// 2 фрагмент уровень сигнала rssi устройства до маяка
                    {
                        temp += 1;//следующая ячейка массива
                        infoMess[temp].NAME = tempNAME; //заполняем структуру массива
                        infoMess[temp].UUID = tempUUID;
                        infoMess[temp].RSSI = tempstr;
                        tempfr = -1;//скидываем счетчик фрагмента
                    }

                    tempstr = ""; //обнуляем временную строку
                }
                else// пока не нашли пробела
                {
                    tempstr += str[i];// заполянем временную строку
                }
            }

           lstStatus.Items.Clear();// очищаем listbox

            for (int j = 0; j < temp; j++) //перебираем массив
            {
                lstStatus.Items.Add(j + " | " + infoMess[j].NAME + " | " + infoMess[j].UUID + " | " + infoMess[j].RSSI);//заполянем listbox данными из массива
            }

            for (int i = temp - 4; i < temp; i++) //перебираем массив
            {
                Summ5 += Convert.ToInt32(infoMess[i].RSSI); // нахождение среднего уровня сигнала
                tempSR = Summ5 / 5; // нахождение среднего уровня сигнала
            }

            for (int i = temp - 4; i < temp; i++) //перебираем массив
            {
                strUUID = infoMess[i].UUID; //fda50693a4e24fb1afcfc6eb07640001

            for (int j = 28; j < 32; j++)// поиск в конце UUID 
            {
                tempstrUUID += strUUID[j];// заполнение временной переменной
            }

            if (tempstrUUID == "0001") //если  сходится конец uuid с номером комнаты значит мы в комнате
            {
                if (tempSR < -30) //проверка среднего уровня сигнала что бы не было ошибок
                {
                        lst1room.Items.Add(infoMess[i].NAME);
                }
            }

                if (tempstrUUID == "0002") //если  сходится конец uuid с номером комнаты значит мы в комнате
                {
                    if (tempSR < -30) //проверка среднего уровня сигнала что бы не было ошибок
                    {
                        lst2room.Items.Add(infoMess[i].NAME);
                    }
                }

                if (tempstrUUID == "0003") //если  сходится конец uuid с номером комнаты значит мы в комнате
                {
                    if (tempSR < -30) //проверка среднего уровня сигнала что бы не было ошибок
                    {
                        lst3room.Items.Add(infoMess[i].NAME);
                    }
                }

                if (tempstrUUID == "0004") //если  сходится конец uuid с номером комнаты значит мы в комнате
                {
                    if (tempSR < -30) //проверка среднего уровня сигнала что бы не было ошибок
                    {
                        lst4room.Items.Add(infoMess[i].NAME);
                    }
                }

            }

            //Вывод служебной информации в листбокс
            lstData.Items.Clear();// очищаем listbox службы
            lstData.Items.Add("Кол-во показаний: " + temp); // Количество полученных показаний
            lstData.Items.Add("Среднее: " + tempSR); // Среднее последних 3 элементов







        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}


         
