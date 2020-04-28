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

            for (int j = 0; j < infoMess.Length; j++) //перебираем массив
            {
                lstStatus.Items.Add(j + " | " + infoMess[j].NAME + " | " + infoMess[j].UUID + " | " + infoMess[j].RSSI);//заполянем listbox данными из массива
            }




        }
    }
}


         
