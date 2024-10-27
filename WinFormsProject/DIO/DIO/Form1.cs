using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace ESP8266ControlApp
{
    public partial class Form1 : Form
    {
        // Ініціалізація послідовного порту
        private SerialPort serialPort;

        public Form1()
        {
            InitializeComponent();
            InitializeSerialPort();
        }

        // Налаштування порту COM13
        private void InitializeSerialPort()
        {
            serialPort = new SerialPort("COM13", 115200);
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.Handshake = Handshake.None;

            // Обробка події отримання даних з порту
            serialPort.DataReceived += SerialPort_DataReceived;

            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка підключення до порту: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Подія: Отримання даних з ESP8266
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine();
            Invoke(new Action(() => lblButtonState.Text = $"Button state: {data.Trim()}"));
        }

        // Подія: Увімкнення LED 1
        private void btnLed1On_Click(object sender, EventArgs e)
        {
            SendCommand("LED1_ON");
        }

        // Подія: Вимкнення LED 1
        private void btnLed1Off_Click(object sender, EventArgs e)
        {
            SendCommand("LED1_OFF");
        }

        // Подія: Увімкнення LED 2
        private void btnLed2On_Click(object sender, EventArgs e)
        {
            SendCommand("LED2_ON");
        }

        // Подія: Вимкнення LED 2
        private void btnLed2Off_Click(object sender, EventArgs e)
        {
            SendCommand("LED2_OFF");
        }

        // Подія: Перевірка стану кнопки
        private void btnCheckButtonState_Click(object sender, EventArgs e)
        {
            SendCommand("CHECK_BUTTON");
        }

        // Відправка команди на ESP8266
        private void SendCommand(string command)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.WriteLine(command);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка відправки команди: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Порт закритий!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Закриття порту при завершенні роботи
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
            base.OnFormClosing(e);
        }
    }
}
