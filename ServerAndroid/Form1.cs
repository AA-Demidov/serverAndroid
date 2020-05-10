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

        int tempPositionsAnton = 0; //предыдущая позиция МУ Антона            
        int tempPositionsUlyana = 0; //предыдущая позиция МУ Ульяны

        public void btnScan_Click(object sender, EventArgs e)
        {
            message[] MassСommon = new message[1000]; // для хранения данных со всех приходящих телефонов
            message[] MassAnton = new message[1000]; // для хранение данных с мобильного устройства абонента с именем Антон
            message[] MassUlyana = new message[1000]; // для мобильного хранение данных с устройства абонента с именем Ульяна

            string tempstr = ""; // временная переменная дл сохранения инфорация ДО нахождения пробела
            int tempfr = -1;// переменнная для подсчета фрагментов, всего их 3 как и пробелов в одном сообщение

            string tempNAME = ""; // временная переменная для хранения имени владельца МУ (мобильного устройства)
            string tempUUID = "";// временная переменная для хранения айди метки
            string str = txtStatus.Text;// переменная для поиска пробелов

            int tempMassСommon = -1; //подсчет количества эллементов общего массива
            int tempMassAnton = -1; //подсчет количества эллементов массива Антона
            int tempMassUlyana = -1; //подсчет количества эллементов массива Ульяна

            int tempSRmassAnton = 0; ;//переменная для среднего значения RSSI
            int tempSRmassUlyana = 0;//переменная для среднего значения RSSI
            int Summ5 = 0;//переменная для суммы последних 5 элементов

            int tempAntonUUID = 0; // для подсчета проверки последних трех UUID
            int tempUlyanaUUID = 0; // для подсчета проверки последних трех UUID

            string strUUID = ""; // строка для идентификации метки и позиционирования МУ
            string tempstrUUID = ""; // строка для нахождения символов индефикатора

            lst1room.Items.Clear();
            lst2room.Items.Clear();
            lst3room.Items.Clear();
            lst4room.Items.Clear();
            lstData.Items.Clear();// очищаем listbox службы
            lstStatus.Items.Clear();// очищаем listbox
            lstAnton.Items.Clear();
            lstUlyana.Items.Clear();

            // заполнение общего массива структур

            for (int i = 0; i < str.Length; i++) // перебираем строку получаемого сообщения от телефона и заполняем массив структур общих данных
            {
                if (str[i] == ' ') //поиск пробела
                {
                    tempfr += 1;// прошли один фрагмент

                    if (tempfr == 0) // 0 фрагмент имя устройства
                        tempNAME = tempstr; //заполняем временную переменную name 

                    if (tempfr == 1) // 1 фрагмент uuid устройства
                    {
                        if (tempstr == "fda50693a4e24fb1afcfc6eb07640001") // находим UUID заменяем его на последний элементв в строке
                            tempUUID = Convert.ToString(tempstr[31]);

                        if (tempstr == "fda50693a4e24fb1afcfc6eb07640002")
                            tempUUID = Convert.ToString(tempstr[31]);

                        if (tempstr == "fda50693a4e24fb1afcfc6eb07640003")
                            tempUUID = Convert.ToString(tempstr[31]);

                        if (tempstr == "fda50693a4e24fb1afcfc6eb07640004")
                            tempUUID = Convert.ToString(tempstr[31]);

                    }


                    if (tempfr == 2)// 2 фрагмент уровень сигнала rssi устройства до маяка
                    {
                        tempMassСommon += 1;//следующая ячейка массива

                        MassСommon[tempMassСommon].NAME = tempNAME;
                        MassСommon[tempMassСommon].UUID = tempUUID;
                        MassСommon[tempMassСommon].RSSI = tempstr;

                        lstStatus.Items.Add(MassСommon[tempMassСommon].NAME + " | " + MassСommon[tempMassСommon].UUID + " Метка" + " | " + MassСommon[tempMassСommon].RSSI);//заполянем listbox общем массивом

                        tempfr = -1;//скидываем счетчик фрагмента
                        
                    }

                    tempstr = ""; //обнуляем временную строку
                }
                else// пока не нашли пробела
                {
                    tempstr += str[i];// заполянем временную строку
                }

            }

            lstData.Items.Add("Кол-во общих показаний: " + tempMassСommon); // Количество полученных показаний

            //
            //идентификация и заполнение массивов
            //
            for (int i = 0; i < tempMassСommon; i++)
            {
                if (MassСommon[i].NAME == "Антон")// поиск в общем массиве в структуре Имя == Антон, если находим заполняем массив под пользователя Антон
                {
                    tempMassAnton += 1;//следующая ячейка массива

                    MassAnton[tempMassAnton].NAME = MassСommon[i].NAME;
                    MassAnton[tempMassAnton].UUID = MassСommon[i].UUID;
                    MassAnton[tempMassAnton].RSSI = MassСommon[i].RSSI;

                    lstAnton.Items.Add(MassAnton[tempMassAnton].NAME + " | " + MassAnton[tempMassAnton].UUID + " Метка" + " | " + MassAnton[tempMassAnton].RSSI);//заполянем listbox данными из массива Антон

                    
                }

                if (MassСommon[i].NAME == "Ульяна")// поиск в общем массиве в структуре Имя == Ульяна, если находим заполняем массив под пользователя Ульяна
                {
                    tempMassUlyana += 1;//следующая ячейка массива

                    MassUlyana[tempMassUlyana].NAME = MassСommon[i].NAME;
                    MassUlyana[tempMassUlyana].UUID = MassСommon[i].UUID;
                    MassUlyana[tempMassUlyana].RSSI = MassСommon[i].RSSI;

                    lstUlyana.Items.Add(MassUlyana[tempMassUlyana].NAME + " | " + MassUlyana[tempMassUlyana].UUID + " Метка" + " | " + MassUlyana[tempMassUlyana].RSSI);//заполянем listbox данными из массива Ульяна

                }
            }

            if (tempMassAnton > 0)// проверка на пустоту массива
            {
                Summ5 = 0;
                for (int i = tempMassAnton - 3; i < tempMassAnton; i++) //нахождение среднего увроня сигнала массива Антон
                {
                    Summ5 += Convert.ToInt32(MassAnton[i].RSSI); // нахождение среднего уровня сигнала
                }
                tempSRmassAnton = Summ5/3; // нахождение среднего уровня сигнала

                lstData.Items.Add("Средний RSSI " + MassAnton[tempMassAnton].NAME + ": " + tempSRmassAnton);
                lstData.Items.Add("Кол-во показаний " + MassAnton[tempMassAnton].NAME + ": " + tempMassAnton); // Количество полученных показаний от Антона

                //Позиционирование Антона

                for (int i = tempMassAnton - 3; i < tempMassAnton; i++) //
                {
                    if (MassAnton[i].UUID == "1" && tempSRmassAnton > -70) //если  сходится конец uuid с номером комнаты значит мы в комнате
                    {
                        tempAntonUUID += 1; //проверяем последние 3 значения если каждое совпадение с UUID +1

                        if (tempAntonUUID == 3)//если 3 последних UUID идентичны заносим имя абонента в листбокс
                        {
                            if (tempPositionsAnton == 0)
                            {
                                btnTest.Location = new Point(355, 340); // устанвливаем объект на карте по координатам
                                btnTest.Visible = true; // делаем объект видимым
                            }

                            tempPositionsAnton = 1;// обозначаем нынешнюю позицию
                            lst1room.Items.Add(MassAnton[i].NAME); 
                        }
                    }

                    if (MassAnton[i].UUID == "2" && tempSRmassAnton > -70) //если  сходится конец uuid с номером комнаты значит мы в комнате
                    {
                        tempAntonUUID += 1;//проверяем последние 3 значения если каждое совпадение с UUID +1
                        if (tempAntonUUID == 3)//если 3 последних UUID идентичны заносим имя абонента в листбокс
                        {
                            if(tempPositionsAnton ==0)
                            {
                                btnTest.Location = new Point(689, 180); // устанвливаем объект на карте по координатам
                                btnTest.Visible = true; // делаем объект видимым
                            }

                            //анимация из 1к2
                            if (tempPositionsAnton==1)
                            {
                                System.Timers.Timer myTimer = new System.Timers.Timer(500.0);
                                myTimer.Elapsed += new System.Timers.ElapsedEventHandler(MT1_2);
                                myTimer.Start();
                            }


                            tempPositionsAnton = 2;// обозначаем нынешнюю позицию
                            lst2room.Items.Add(MassAnton[i].NAME);
                        } 
                    }

                    if (MassAnton[i].UUID == "3" && tempSRmassAnton > -70) //если  сходится конец uuid с номером комнаты значит мы в комнате
                    {
                        tempAntonUUID += 1;//проверяем последние 3 значения если каждое совпадение с UUID +1

                        if (tempAntonUUID == 3)//если 3 последних UUID идентичны заносим имя абонента в листбокс
                        {
                            if (tempPositionsAnton == 0)
                            {
                                btnTest.Location = new Point(600, 340); // устанвливаем объект на карте по координатам
                                btnTest.Visible = true; // делаем объект видимым
                            }



                            tempPositionsAnton = 3;// обозначаем нынешнюю позицию
                            lst3room.Items.Add(MassAnton[i].NAME);
                        }
                    }

                    if (MassAnton[i].UUID == "4" && tempSRmassAnton > -70) //если  сходится конец uuid с номером комнаты значит мы в комнате
                    {
                        tempAntonUUID += 1;//проверяем последние 3 значения если каждое совпадение с UUID +1

                        if (tempAntonUUID == 3)//если 3 последних UUID идентичны заносим имя абонента в листбокс
                        {
                            if (tempPositionsAnton == 0)
                            {
                                btnTest.Location = new Point(780, 340); // устанвливаем объект на карте по координатам
                                btnTest.Visible = true; // делаем объект видимым
                            }

                            tempPositionsAnton = 4;// обозначаем нынешнюю позицию
                            lst4room.Items.Add(MassAnton[i].NAME);

                        }
                    }
                }
            }

            if (tempMassUlyana > 0)// проверка на пустоту массива
            {
                Summ5 = 0;
                for (int i = tempMassUlyana - 3; i < tempMassUlyana; i++) //нахождение среднего увроня сигнала массива Антон
                {
                    Summ5 += Convert.ToInt32(MassUlyana[i].RSSI); // нахождение среднего уровня сигнала
                }

                tempSRmassUlyana = Summ5 / 3; // нахождение среднего уровня сигнала

                lstData.Items.Add("Средний RSSI " + MassUlyana[tempMassUlyana].NAME + ": " + tempSRmassUlyana);
                lstData.Items.Add("Кол-во показаний " + MassUlyana[tempMassUlyana].NAME + ": " + tempMassUlyana); // Количество полученных показаний от Ульяны

                //
                //позиционирование ульяны
                //
                for (int i = tempMassUlyana - 4; i < tempMassUlyana; i++) //
                {
                    if (MassUlyana[i].UUID == "1" && tempSRmassUlyana > -70) //если  сходится конец uuid с номером комнаты значит мы в комнате
                    {
                        tempUlyanaUUID += 1;//проверяем последние 3 значения если каждое совпадение с UUID +1

                        if (tempUlyanaUUID == 3)//если 3 последних UUID идентичны заносим имя абонента в листбокс
                        {
                            tempPositionsUlyana = 1;
                            lst1room.Items.Add(MassUlyana[i].NAME);
                        }
                    }

                    if (MassUlyana[i].UUID == "2" && tempSRmassUlyana > -70) //если  сходится конец uuid с номером комнаты значит мы в комнате
                    {
                        tempUlyanaUUID += 1;//проверяем последние 3 значения если каждое совпадение с UUID +1

                        if (tempUlyanaUUID == 3)//если 3 последних UUID идентичны заносим имя абонента в листбокс
                        {
                            tempPositionsUlyana = 2;
                            lst2room.Items.Add(MassUlyana[i].NAME);
                        }
                            
                    }

                    if (MassUlyana[i].UUID == "3" && tempSRmassUlyana > -70) //если  сходится конец uuid с номером комнаты значит мы в комнате
                    {
                        tempUlyanaUUID += 1;//проверяем последние 3 значения если каждое совпадение с UUID +1

                        if (tempUlyanaUUID == 3)//если 3 последних UUID идентичны заносим имя абонента в листбокс
                        {
                            tempPositionsUlyana = 3;
                            lst3room.Items.Add(MassUlyana[i].NAME);
                        }
                    }

                    if (MassUlyana[i].UUID == "4" && tempSRmassUlyana > -70) //если  сходится конец uuid с номером комнаты значит мы в комнате
                    {
                        tempUlyanaUUID += 1;//проверяем последние 3 значения если каждое совпадение с UUID +1

                        if (tempUlyanaUUID == 3)//если 3 последних UUID идентичны заносим имя абонента в листбокс
                        {
                            tempPositionsUlyana = 4;
                            lst4room.Items.Add(MassUlyana[i].NAME);
                        }
                    }
                }
            }
        }

        //
        // ТЕСТ АНИМАЦИИ КНОПКИ
        //
        /*
         * 1-2
         * 1-3
         * 1-4
         * 2-1
         * 2-3
         * 2-4
         * 3-1
         * 3-2
         * 3-4
         * 4-1
         * 4-2
         * 4-3
         * 
         */
        private void btnTest_Click(object sender, EventArgs e)
        {

        }

        void MT1_2(object sender, System.Timers.ElapsedEventArgs e) // из 1 (cиний) в 2 (красную)
        {
            if (btnTest.Location.X == 355 && btnTest.Location.Y > 180)
            {
                btnTest.Invoke((Action)(() => {
                    btnTest.Location = new Point(btnTest.Location.X, btnTest.Location.Y - 40);
                }));
            }

            if (btnTest.Location.X < 690 && btnTest.Location.Y == 180) 
            {
                btnTest.Invoke((Action)(() => {
                    btnTest.Location = new Point(btnTest.Location.X + 67, btnTest.Location.Y);
                }));
            }
        }
        void MT1_3(object sender, System.Timers.ElapsedEventArgs e) // из 1 (синий) в 3 (зеленую)
        {
            if (btnTest.Location.X == 355 && btnTest.Location.Y > 180)
            {
                btnTest.Invoke((Action)(() => {
                    btnTest.Location = new Point(btnTest.Location.X, btnTest.Location.Y - 40);
                }));
            }

            if (btnTest.Location.X < 600 && btnTest.Location.Y == 180)
            {
                btnTest.Invoke((Action)(() => {
                    btnTest.Location = new Point(btnTest.Location.X + 67, btnTest.Location.Y);
                }));
            }

            if (btnTest.Location.X == 600 && btnTest.Location.Y < 340)
            {
                btnTest.Invoke((Action)(() => {
                    btnTest.Location = new Point(btnTest.Location.X, btnTest.Location.Y+40);
                }));
            }
        }
        void MT1_4(object sender, System.Timers.ElapsedEventArgs e) // из 1 (синий) в 4 (фиолет)
        {
            if (btnTest.Location.X == 355 && btnTest.Location.Y > 180)
            {
                btnTest.Invoke((Action)(() => {
                    btnTest.Location = new Point(btnTest.Location.X, btnTest.Location.Y - 40);
                }));
            }

            if (btnTest.Location.X < 780 && btnTest.Location.Y == 180)
            {
                btnTest.Invoke((Action)(() => {
                    btnTest.Location = new Point(btnTest.Location.X + 67, btnTest.Location.Y);
                }));
            }

            if (btnTest.Location.X == 780 && btnTest.Location.Y < 340)
            {
                btnTest.Invoke((Action)(() => {
                    btnTest.Location = new Point(btnTest.Location.X, btnTest.Location.Y+40);
                }));
            }
        }
        void MT2_1(object sender, System.Timers.ElapsedEventArgs e) // из 2 (красная) в 1 (синий)
        {
            if (btnTest.Location.X > 355 && btnTest.Location.Y == 180)
            {
                btnTest.Invoke((Action)(() => {
                    btnTest.Location = new Point(btnTest.Location.X - 67, btnTest.Location.Y);
                }));
            }

            if (btnTest.Location.X == 355 && btnTest.Location.Y < 340)
            {
                btnTest.Invoke((Action)(() => {
                    btnTest.Location = new Point(btnTest.Location.X, btnTest.Location.Y+40);
                }));
            }
        }
        void MT2_3(object sender, System.Timers.ElapsedEventArgs e) // из 2 (красная) в 3 (зеленая)
        {
            if (btnTest.Location.X > 600 && btnTest.Location.Y == 180)
            {
                btnTest.Invoke((Action)(() => {
                    btnTest.Location = new Point(btnTest.Location.X - 67, btnTest.Location.Y);
                }));
            }

            if (btnTest.Location.X == 600 && btnTest.Location.Y < 340)
            {
                btnTest.Invoke((Action)(() => {
                    btnTest.Location = new Point(btnTest.Location.X, btnTest.Location.Y + 40);
                }));
            }
        }
        void MT2_4(object sender, System.Timers.ElapsedEventArgs e) // из 2 (красная) в 4 (фиолет)
        {
            if (btnTest.Location.X < 780 && btnTest.Location.Y == 180)
            {
                btnTest.Invoke((Action)(() => {
                    btnTest.Location = new Point(btnTest.Location.X + 67, btnTest.Location.Y);
                }));
            }

            if (btnTest.Location.X == 780 && btnTest.Location.Y < 340)
            {
                btnTest.Invoke((Action)(() => {
                    btnTest.Location = new Point(btnTest.Location.X, btnTest.Location.Y + 40);
                }));
            }
        }




        private void button6_Click(object sender, EventArgs e)
        {
            btnTest.Visible = true;
            for(int i=0;i<10;i++)
            {
                if (btnTest.Location.X == 355 && btnTest.Location.Y > 180)
                {
                    btnTest.Invoke((Action)(() => {
                        btnTest.Location = new Point(btnTest.Location.X, btnTest.Location.Y - 40);
                    }));
                }
            }
        }
    }
}



         
