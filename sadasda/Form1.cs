using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sadasda
{
    public partial class Form1 : Form
    {
        private int schet = 0;
        public String capthcatext;
        public Form1()
        {

            InitializeComponent();
            pictureBox1.Hide();
            textBox3.Hide();
            button3.Hide();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=EgorLaptop\MSSQLSERVER03;Initial Catalog =ИС_тех_контроля;Integrated Security=True";

            string username = textBox1.Text;
            string password = textBox2.Text;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [Данные сотрудников ОТК] WHERE email = @email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", username);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    string fio = reader["name"].ToString();
                    Class1.fio = fio;
                    string dbPassword = reader["password"].ToString();
                   
                    if (password == dbPassword)
                    {
                        if (Class1.access == 1) 
                        {
                            if (schet > 0)
                            {

                                if (textBox3.Text == capthcatext)
                                {
                                    
                                    Class1.fio = reader["name"].ToString();
                                    string position = reader["position"].ToString();
                                    Class1.position = position;
                                    Class1.position = "Менеджер";
                                    if (Class1.position == "Менеджер") 
                                    {
                                        Form2 менеджер = new Form2();
                                        менеджер.Show();
                                        Hide();
                                    }
                                    if (Class1.position == "Лаборант" || Class1.position == "Контролёр")
                                    {
                                        Form3 лаборант_контролер = new Form3();
                                        лаборант_контролер.Show();
                                        Hide();
                                    }
                                    if (Class1.position == "Администратор" || Class1.position == "Начальник ОТК")
                                    {
                                        Form4 администратор_начальник_отк = new Form4();
                                        администратор_начальник_отк.Show();
                                        Hide();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Ошибка должности");
                                    }

                                }
                               


                            }
                            else
                            {
                               
                                
                                string position = reader["position"].ToString();
                                Class1.position = position;
                                
                                if (Class1.position == "Менеджер")
                                {
                                    Form2 менеджер = new Form2();
                                    менеджер.Show();
                                    Hide();
                                }
                                if (Class1.position == "Лаборант" || Class1.position == "Контролёр")
                                {
                                    Form3 лаборант_контролер = new Form3();
                                    лаборант_контролер.Show();
                                    Hide();
                                }
                                if (Class1.position == "Администратор" || Class1.position == "Начальник ОТК")
                                {
                                    Form4 администратор_начальник_отк = new Form4();
                                    администратор_начальник_отк.Show();
                                    Hide();

                                }
                               
                            }
                        }
                        else
                        {
                            MessageBox.Show("Доступ был заблокирован на пол часа");
                        }
                        

                    }
                    else
                    {

                        schet += 1;
                        MessageBox.Show("Неправильный пароль");
                        if (schet > 0)
                        {
                            pictureBox1.Show();
                            textBox3.Show();
                            pictureBox1.Image = this.CreateImage(146, 74);
                            button3.Show();
                        }

                    }
                }
                else
                {
                    schet += 1;
                    MessageBox.Show("Неправильный логин");
                    
                    
                    
                    if (schet > 0)
                    {
                        pictureBox1.Show();
                        textBox3.Show();
                        pictureBox1.Image = this.CreateImage(146, 74);
                        button3.Show();
                    }

                }
            }





        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '\0';
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, args) =>
            {
                textBox2.PasswordChar = '*';
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();

        }


        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = 10;
            int Ypos = 10;

            //Добавим различные цвета ддя текста
            Brush[] colors = {
Brushes.Black,
Brushes.Red,
Brushes.RoyalBlue,
Brushes.Green,
Brushes.Yellow,
Brushes.White,
Brushes.Tomato,
Brushes.Sienna,
Brushes.Pink };

            //Добавим различные цвета линий
            Pen[] colorpens = {
Pens.Black,
Pens.Red,
Pens.RoyalBlue,
Pens.Green,
Pens.Yellow,
Pens.White,
Pens.Tomato,
Pens.Sienna,
Pens.Pink };

            //Делаем случайный стиль текста
            FontStyle[] fontstyle = {
FontStyle.Bold,
FontStyle.Italic,
FontStyle.Regular,
FontStyle.Strikeout,
FontStyle.Underline};

            //Добавим различные углы поворота текста
            Int16[] rotate = { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5, 6, -6 };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((Image)result);

            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);

            //Делаем случайный угол поворота текста
            g.RotateTransform(rnd.Next(rotate.Length));

            //Генерируем текст
            string text;
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];
            capthcatext = text;
            //Нарисуем сгенирируемый текст
            g.DrawString(text,
            new Font("Arial", 25, fontstyle[rnd.Next(fontstyle.Length)]),
            colors[rnd.Next(colors.Length)],
            new PointF(Xpos, Ypos));

            //Добавим немного помех
            /////Линии из углов
            g.DrawLine(Pens.Black,
                       new Point(0, 0),
                       new Point(Width - 1, Height - 1));
            g.DrawLine(Pens.Black,
                       new Point(0, Height - 1),
                       new Point(Width - 1, 0));
            //Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);
            Console.WriteLine(result);
            return result;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(146, 74);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
