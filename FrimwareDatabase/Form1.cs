using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using Force.Crc32;
using System.Xml.Linq;

namespace FrimwareDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string UploadingFileName;

        private void buttonOpenBinFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bin Files (*.bin)|*.bin|All Files (*.*)|*.*";
            openFileDialog.Title = "Open .bin File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string md5Hash = CalculateMD5(filePath);
                    textBoxCheckSum.Text = md5Hash;
                    buttonAddToDataBase.Visible = true;
                    UploadingFileName = Path.GetFileName(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка вычисления MD5: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxCheckSum.Text = "";
                }
            }
        }

        // Метод для вычисления MD5 хеша файла
        private string CalculateMD5(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                // Вычисляем MD5 хеш файла.
                // Преобразуем хеш в шестнадцатеричную строку и возвращаем ее.
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private void buttonOpenHexFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "HEX Files (*.hex)|*.hex|All files (*.*)|*.*";
            openFileDialog.Title = "Open .bin File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    UploadingFileName = Path.GetFileName(filePath);
                    string fileContent = ReadFileContent(filePath);
                    textBoxFileContent.Text = fileContent;
                    string checksum = CalculateCRC32Checksum(filePath);
                    textBoxCheckSum.Text = "0x" + checksum;
                    buttonAddToDataBase.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Метод для вычисления CRC32 контрольной суммы файла
        private string CalculateCRC32Checksum(string filePath)
        {
            // Вызываем перегруженный метод CalculateCRC32Checksum, передавая файловый поток
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                return CalculateCRC32Checksum(fileStream);
            }
        }

        // Метод для вычисления CRC32 контрольной суммы из потока
        private string CalculateCRC32Checksum(Stream stream)
        {
            // Используем Crc32Algorithm из CRC32.NET
            // Вычисляем CRC32 хеш потока
            // Преобразуем хеш в шестнадцатеричную строку и возвращаем ее
            using (var crc32 = new Crc32Algorithm())
            {
                byte[] hashBytes = crc32.ComputeHash(stream);
                return ByteArrayToHexString(hashBytes);
            }
        }

        // Метод для преобразования массива байтов в шестнадцатеричную строку
        private string ByteArrayToHexString(byte[] bytes)
        {
            // Преобразуем массив байтов в строку шестнадцатеричных значений
            // Удаляем дефисы из строки
            string hex = BitConverter.ToString(bytes);
            return hex.Replace("-", "");
        }

        //  Метод для чтения содержимого файла
        private string ReadFileContent(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка чтения файла: {ex.Message}";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonCreateDataBase_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем диалоговое окно для сохранения файла
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                // Устанавливаем фильтр файлов, чтобы пользователь мог сохранить только XML файлы
                saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "xml";
                saveFileDialog.AddExtension = true;
                saveFileDialog.Title = "Создать новую базу данных";

                // Показываем диалоговое окно и получаем результат
                DialogResult result = saveFileDialog.ShowDialog();

                // Если пользователь нажал кнопку "Сохранить"
                if (result == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Создаем XML документ
                    var xmlDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("FirmWares"));
                    xmlDoc.Save(filePath);
                    MessageBox.Show($"База данных '{Path.GetFileName(filePath)}' успешно создана в '{filePath}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Обрабатываем исключение и выводим сообщение об ошибке
                MessageBox.Show($"Произошла ошибка при создании базы данных: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddToDataBase_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.Title = "Выберите XML файл базы данных";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Загрузка XML файла с использованием XDocument
                    XDocument xmlDoc = XDocument.Load(openFileDialog.FileName);

                    // Валидация данных из textBoxCheckSum
                    if (string.IsNullOrEmpty(textBoxCheckSum.Text))
                    {
                        MessageBox.Show("Поле контрольной суммы не может быть пустым.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string registrationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    XElement newFirmWare = new XElement("FirmWare",
                    new XElement("CheckSum", textBoxCheckSum.Text),
                    new XElement("FileName", UploadingFileName),
                    new XElement("RegistrationDate", registrationDate));

                    // Создание корневого элемента
                    XElement rootElement = xmlDoc.Root;

                    // Добавляем новый элемент
                    if (rootElement != null)
                    {
                        rootElement.Add(newFirmWare); 
                    }
                    else
                    {
                        MessageBox.Show("Корневой элемент 'FirmWares' нен айден в XML файле.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    CheckForDuplicateChecksum(openFileDialog.FileName, textBoxCheckSum.Text);

                    // Сохранение изменений в XML файл
                    xmlDoc.Save(openFileDialog.FileName);

                    //  Оповещение пользователя об успехе
                    MessageBox.Show("Данные успешно добавлены в бауз данных.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Метод для проверки наличия дубликата контрольной суммы в XML-файле
        private void CheckForDuplicateChecksum(string filePath, string checksum)
        {
            try
            {
                // Используем LINQ to XML для поиска элемента<CheckSum> внутри элементов<FirmWare>,
                // который имеет значение, равное переданной контрольной сумме
                XDocument xmlDoc = XDocument.Load(filePath);
                bool checksumExists = xmlDoc.Descendants("FirmWare")
                                              .Elements("CheckSum")
                                              .Any(cs => cs.Value == checksum);

                if (checksumExists)
                {
                    MessageBox.Show($"Контрольная сумма '{checksum}' уже существует в базе данных.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при проверке контрольной суммы: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}

