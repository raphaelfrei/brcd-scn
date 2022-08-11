using System.Reflection;

namespace SCN {

    public partial class Form1 : Form {

        private List<string> seriais = new List<string>();

        private List<string> escaneados  = new List<string>();
        private List<string> encontrados  = new List<string>();
        private List<string> nencontrados = new List<string>();

        string character;

        public Form1() {
            InitializeComponent();

        }

        private FileDialog fds = new OpenFileDialog {
            Filter = "",
            Title = "Open Report"

        };

        private void button1_Click(object sender, EventArgs e) {
            fds.Filter = String.Format("CSV File|*.csv");

            fds.DefaultExt = "*.csv";

            fds.ShowDialog();

            textBox1.Text = fds.FileName;

            ScanFile(textBox1.Text);

        }

        private void ScanFile(string filePath) {
            try {

                using (var reader = new StreamReader(filePath)) {

                    int i = 0;

                    while (!reader.EndOfStream) {

                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        seriais.Add(values[0]);
                        //MessageBox.Show(seriais[i]);
                        i++;

                    }

                    textBox2.Text = i.ToString();
                    textBox7.Text = "0";
                    textBox3.Text = "0";
                    textBox4.Text = "0";
                }

               

            } catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e) {

        }

        private void TrackSerial() {
            if (textBox1.Text == "") {
                MessageBox.Show("Please select a file!", "File Not Selected");

                return;
            }

            var result = seriais.Contains(textBox5.Text);

            var result2 = escaneados.Contains(textBox5.Text);

            if (result2) {
                textBox6.BackColor = Color.Blue;
                textBox6.Text = $"Serial \"{textBox5.Text}\" já escaneado!";

                return;

            }

            textBox7.Text = (Convert.ToInt32(textBox7.Text) + 1).ToString();

            if (result) {
                encontrados.Add(textBox5.Text);

                seriais.Remove(textBox5.Text);

                textBox3.Text = (Convert.ToInt32(textBox3.Text) + 1).ToString();

                textBox6.BackColor = Color.Green;
                textBox6.Text = $"Serial \"{textBox5.Text}\" encontrado!";

            } else if (!result) {
                nencontrados.Add(textBox5.Text);

                //seriais.Remove(textBox5.Text);

                textBox4.Text = (Convert.ToInt32(textBox4.Text) + 1).ToString();

                textBox6.BackColor = Color.Red;
                textBox6.Text = $"Serial \"{textBox5.Text}\" não encontrado!";
            }

            escaneados.Add(textBox5.Text);

        }

        private void button2_Click(object sender, EventArgs e) {
            if (textBox5.Text != "")
                TrackSerial();

        }

        private void button3_Click(object sender, EventArgs e) {
            SaveFileDialog fd = new SaveFileDialog {
                Filter = "CSV File|*.csv",
                Title = "Save Report"
            };

            fd.DefaultExt = ".csv";

            fd.ShowDialog();

            try {
                if (fd.FileName != "") {

                    GenerateReport(fd.FileName);

                    MessageBox.Show("File Exported!", "File Export");
         
                }
            }catch(Exception ex) {
                MessageBox.Show($"Error Saving File - {ex}", "Error");

            }
        }

        private void GenerateReport(string filePath) {
            using (StreamWriter sw = new StreamWriter(filePath)) {

                sw.WriteLine("CODIGO,STATUS");

                foreach (var item in encontrados) {
                    sw.Write($"{item}, ENCONTRADO{(char)13}");
                }

                foreach (var item in nencontrados) {
                    sw.Write($"{item}, NAO ENCONTRADO{(char)13}");
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e) {

            if(Convert.ToInt32(e.KeyChar) == 13) {
                TrackSerial();
                textBox5.Text = "";

            }
        }
    }
}