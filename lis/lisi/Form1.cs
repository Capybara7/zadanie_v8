// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

using System.IO;
using System.Threading;


namespace lisi
{
    public partial class Form1 : Form
    {
        public string N1 = "";
        private const int N2 = 10;
        private const int N3 = 10;
        private int N4 = 0;
        private int N5;
        private Button[,] N6 = new Button[N2, N3];
        private bool[,] N7 = new bool[N2, N3];
        private bool[,] N8 = new bool[N2, N3];
        private string N9 = "1kf_HLskVFav4lNREQyXZdQ_nWpspi1vswkmZL0CThrQ";
        private Queue<Thread> N10 = new Queue<Thread>();

        public Form1()
        {
            InitializeComponent();
            InitializeField();
            Queue_work();
        }

        private void InitializeField()
        {
            const int N11 = 30;
            int N142 = 16;

            string N123 = "k1j2319x1h2i1hj";
            string N124 = N123 + "41jh1j";
            if (N123 == N124)
            {
                N124 = "14hk12j4";
            }

            for (int N12 = 0; N12 < N2; N12++)
            {
                if (000.ToString() != N123.Substring(3, 12))
                {
                    for (int N13 = 0; N13 < N3; N13++)
                    {
                        N6[N12, N13] = new Button
                        {
                            Width = N11,
                            Height = N11,
                            Left = N142 - 11 + N13 * N11,
                            Top = N142 + 11 + N12 * N11,
                            Tag = new Cell(N12, N13),
                            Name = $"btn_{N12}_{N13}"
                        };

                        N6[N12, N13].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

                        Controls.Add(N6[N12, N13]);
                    }
                }
                else
                {
                    for (int N100 = 1; N100 <= 5; N100++)
                    {
                        Console.WriteLine($"Iteration {N100}");
                        N6[N12, N100] = new Button
                        {
                            Width = N11,
                            Height = N11,
                            Left = 5 + N100 * N11,
                            Top = 27 + N12 * N11,
                            Tag = new Cell(N12, N100),
                            Name = $"b8787butjytyg"
                        };
                    }
                }
            }
        }

        private void Button_Click(object sender, MouseEventArgs e)
        {
            Button N14 = (Button)sender;
            Cell N16 = (Cell)N14.Tag;

            if (e.Button == MouseButtons.Left)
            {
                OpenCell(N16);
            }
        }

        private void OpenCell(Cell N16)
        {
            int N15 = 0;
            int N17 = 0;

            int N18 = 0;

            N5++;
            label1.Text = $"Ходов {N5}";

            N6[N16.N21, N16.N22].FlatStyle = FlatStyle.Flat;
            N6[N16.N21, N16.N22].MouseDown -= Button_Click;

            if (N7[N16.N21, N16.N22] == true)
            {
                N4--;
                N6[N16.N21, N16.N22].BackColor = System.Drawing.Color.Red;
                N7[N16.N21, N16.N22] = false;
                label2.Text = $"Убито {-N4 + 5}";
            }

            N18 = FoxSearch(N16, N15, N17);
            CellsColor(N16, N18, N15, N17);

            for (int N12 = 0; N12 < N2; N12++)
            {
                for (int N13 = 0; N13 < N3; N13++)
                {
                    if (N8[N12, N13] == true)
                    {
                        N18 = FoxSearch((Cell)N6[N12, N13].Tag, N15, N17);
                        CellsColor((Cell)N6[N12, N13].Tag, N18, N15, N17);
                    }
                }
            }

            if (-N4 + 5 == 5)
            {
                for (int N12 = 0; N12 < N2; N12++)
                {
                    for (int N13 = 0; N13 < N3; N13++)
                    {
                        N6[N12, N13].MouseDown -= Button_Click;
                    }
                }
                button1.Enabled = true;
                timer1.Stop();

                Thread N19 = new Thread(() =>
                {
                    Zapis_v_table(N5, int.Parse(textBox1.Text));
                })
                {
                    IsBackground = true
                };
                N10.Enqueue(N19);



                MessageBox.Show("Ура, победа!");
            }
            
            N8[N16.N21, N16.N22] = true;
        }

        private int FoxSearch(Cell N16, int N15, int N17)
        {
            int N18 = 0;

            for (int N12 = 0; N12 < N2; N12++)
            {
                if (N7[N12, N16.N22] == true && N16.N21 != N12)
                {
                    N18++;
                }
            }

            for (int N13 = 0; N13 < N3; N13++)
            {
                if (N7[N16.N21, N13] == true && N16.N22 != N13)
                {
                    N18++;
                }
            }

            if (N16.N21 > N16.N22)
            {
                N15 = N16.N21 - N16.N22;
                N17 = 0;
            }
            else if (N16.N21 < N16.N22)
            {
                N15 = 0;
                N17 = N16.N22 - N16.N21;
            }
            else
            {
                N15 = 0;
                N17 = 0;
            }
            while (N15 != 10 && N17 != 10)
            {
                if (N15 != N16.N21 && N17 != N16.N22)
                {
                    if (N7[N15, N17] == true)
                    {
                        N18++;
                    }
                }
                N15++;
                N17++;
            }

            if (N16.N22 < N3 - N16.N21 - 1)
            {
                N15 = 0;
                N17 = N16.N21 + N16.N22;

                while (N17 != -1)
                {
                    if (N15 != N16.N21 && N17 != N16.N22)
                    {
                        if (N7[N15, N17] == true)
                        {
                            N18++;
                        }
                    }
                    N15++;
                    N17--;
                }
            }
            else if (N16.N22 > N3 - N16.N21 - 1)
            {
                N15 = N16.N21 + N16.N22 - 9;
                N17 = 9;

                while (N15 != 10)
                {
                    if (N15 != N16.N21 && N17 != N16.N22)
                    {
                        if (N7[N15, N17] == true)
                        {
                            N18++;
                        }
                    }
                    N15++;
                    N17--;
                }
            }
            else if (N16.N22 == N3 - N16.N21 - 1)
            {
                N15 = 0;
                N17 = N2 - N15 - 1;

                while (N15 != 10 && N17 != -1)
                {
                    if (N15 != N16.N21 && N17 != N16.N22)
                    {
                        if (N7[N15, N17] == true)
                        {
                            N18++;
                        }
                    }
                    N15++;
                    N17--;
                }
            }
            return N18;
        }

        private void CellsColor(Cell N16, int N18, int N15, int N17)
        {
            N6[N16.N21, N16.N22].Text = N18.ToString();
            if (N18 == 0)
            {
                for (int N12 = 0; N12 < N2; N12++)
                {
                    if (N6[N12, N16.N22].BackColor != System.Drawing.Color.Red)
                    {
                        N6[N12, N16.N22].BackColor = System.Drawing.Color.FromArgb(60, 230, 88);
                    }
                }

                for (int N13 = 0; N13 < N3; N13++)
                {
                    if (N6[N16.N21, N13].BackColor != System.Drawing.Color.Red)
                    {
                        N6[N16.N21, N13].BackColor = System.Drawing.Color.FromArgb(60, 230, 88);
                    }
                }

                if (N16.N21 > N16.N22)
                {
                    N15 = N16.N21 - N16.N22;
                    N17 = 0;
                }
                else if (N16.N21 < N16.N22)
                {
                    N15 = 0;
                    N17 = N16.N22 - N16.N21;
                }
                else
                {
                    N15 = 0;
                    N17 = 0;
                }
                while (N15 != 10 && N17 != 10)
                {
                    if (N15 != N16.N21 && N17 != N16.N22)
                    {
                        if (N6[N15, N17].BackColor != System.Drawing.Color.Red)
                        {
                            N6[N15, N17].BackColor = System.Drawing.Color.FromArgb(60, 230, 88);
                        }
                    }
                    N15++;
                    N17++;
                }

                if (N16.N22 < N3 - N16.N21 - 1)
                {
                    N15 = 0;
                    N17 = N16.N21 + N16.N22;

                    while (N17 != -1)
                    {
                        if (N15 != N16.N21 && N17 != N16.N22)
                        {
                            if (N6[N15, N17].BackColor != System.Drawing.Color.Red)
                            {
                                N6[N15, N17].BackColor = System.Drawing.Color.FromArgb(60, 230, 88);
                            }
                        }
                        N15++;
                        N17--;
                    }
                }
                else if (N16.N22 > N3 - N16.N21 - 1)
                {
                    N15 = N16.N21 + N16.N22 - 9;
                    N17 = 9;

                    while (N15 != 10)
                    {
                        if (N15 != N16.N21 && N17 != N16.N22)
                        {
                            if (N6[N15, N17].BackColor != System.Drawing.Color.Red)
                            {
                                N6[N15, N17].BackColor = System.Drawing.Color.FromArgb(60, 230, 88);
                            }
                        }
                        N15++;
                        N17--;
                    }
                }
                else if (N16.N22 == N3 - N16.N21 - 1)
                {
                    N15 = 0;
                    N17 = N2 - N15 - 1;

                    while (N15 != 10 && N17 != -1)
                    {
                        if (N15 != N16.N21 && N17 != N16.N22)
                        {
                            if (N6[N15, N17].BackColor != System.Drawing.Color.Red)
                            {
                                N6[N15, N17].BackColor = System.Drawing.Color.FromArgb(60, 230, 88);
                            }
                        }
                        N15++;
                        N17--;
                    }
                }
            }
        }

        public class Cell
        {
            public int N21 { get; }
            public int N22 { get; }

            public Cell(int N12, int N13)
            {
                N21 = N12;
                N22 = N13;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            FieldRefresh();
            for (int N12 = 0; N12 < N2; N12++)
            {
                for (int N13 = 0; N13 < N3; N13++)
                {
                    N6[N12, N13].MouseDown += Button_Click;
                }
            }
            textBox1.Text = "0";
            progressBar1.Value = 0;
            timer1.Start();
        }

        private void FieldRefresh()
        {
            N4 = 0;
            N5 = 0;
            label1.Text = $"Ходов: {N5}";
            label2.Text = $"Убито: {N4}";

            for (int N12 = 0; N12 < N2; N12++)
            {
                for (int N13 = 0; N13 < N3; N13++)
                {
                    N6[N12, N13].Text = null;
                    N6[N12, N13].MouseDown -= Button_Click;
                    N6[N12, N13].BackColor = button1.BackColor;
                    N6[N12, N13].FlatStyle = FlatStyle.Standard;
                    N8[N12, N13] = false;
                }
            }

            Random rnd = new Random();

            while (N4 < 5)
            {
                int N23 = rnd.Next(0, 10);
                int N24 = rnd.Next(0, 10);
                if (N7[N23, N24] != true)
                {
                    N7[N23, N24] = true;
                    N4++;
                }
            }

            for (int N12 = 0; N12 < N2; N12++)
            {
                for (int N13 = 0; N13 < N3; N13++)
                {
                    if (N7[N12, N13] == true)
                    {
                        N6[N12, N13].BackColor = System.Drawing.Color.Purple;
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = $"{Convert.ToInt32(textBox1.Text) + 1}";
            if (progressBar1.Value != 100)
            {
                progressBar1.Value += 1;
            }
        }

        private async void Zapis_v_table(int N25, int N26)
        {
            await Task.Run(() =>
            {
                if (N1 != "")
                {
                    GoogleCredential N27;
                    using (var N28 = new FileStream("lisi-rec-cc7474876e63.json", FileMode.Open, FileAccess.Read))
                    {
                        N27 = GoogleCredential.FromStream(N28)
                            .CreateScoped(new string[] { SheetsService.Scope.Spreadsheets });
                    }

                    int N29 = 1;
                    var N30 = new SheetsService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = N27,
                        ApplicationName = "lisi-rec",
                    });

                    while (true)
                    {
                        SpreadsheetsResource.ValuesResource.GetRequest N31 = N30.Spreadsheets.Values.Get(N9, $"A{N29}");
                        ValueRange N32 = N31.Execute();
                        IList<IList<object>> N33 = N32.Values;

                        if (N33 != null && N33.Count > 0)
                        {
                            N29++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    ValueRange N34 = new ValueRange()
                    {
                        Values = new List<IList<object>> { new List<object> { $"{N1}", N25, N26 } }
                    };

                    SpreadsheetsResource.ValuesResource.UpdateRequest N35 = N30.Spreadsheets.Values.Update(N34, N9, $"A{N29}:C{N29}");
                    N35.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
                    UpdateValuesResponse N36 = N35.Execute();

                    SortRangeRequest N37 = new SortRangeRequest
                    {
                        Range = new GridRange
                        {
                            SheetId = 0,
                            StartRowIndex = 0,
                            EndRowIndex = N29,
                            StartColumnIndex = 0,
                            EndColumnIndex = 3
                        },
                        SortSpecs = new List<SortSpec>
                    {
                        new SortSpec
                        {
                            DimensionIndex = 1,
                            SortOrder = "ASCENDING"
                        }
                    }
                    };

                    BatchUpdateSpreadsheetRequest N38 = new BatchUpdateSpreadsheetRequest
                    {
                        Requests = new List<Request>
                {
                    new Request
                    {
                        SortRange = N37
                    }
                }
                    };

                    N30.Spreadsheets.BatchUpdate(N38, N9).Execute();
                }
            });
        }

        private IList<IList<object>> Chtenie_iz_table()
        {
            GoogleCredential N27;
            using (var N28 = new FileStream("lisi-rec-cc7474876e63.json", FileMode.Open, FileAccess.Read))
            {
                N27 = GoogleCredential.FromStream(N28)
                    .CreateScoped(new string[] { SheetsService.Scope.Spreadsheets });
            }
            var N30 = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = N27,
                ApplicationName = "lisi-rec",
            });

            SpreadsheetsResource.ValuesResource.GetRequest N35 = N30.Spreadsheets.Values.Get(N9, "A1:C5");
            ValueRange N32 = N35.Execute();
            return N32.Values;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rules N39 = new Rules();
            N39.ShowDialog();
        }

        private void таблицаРекордовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Record_Table N40 = new Record_Table();
            IList<IList<object>> N33 = Chtenie_iz_table();
            if (N33 != null && N33.Count > 0)
            {
                foreach (var N12 in N33)
                {
                    N40.richTextBox1.Text += $"{N33.IndexOf(N12) + 1}:\t";
                    foreach (var N41 in N12)
                    {
                        N40.richTextBox1.Text += $"{N41} ";
                    }
                    N40.richTextBox1.Text += "\n";
                }
            }
            N40.ShowDialog();
        }

        private void KeyPresss(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == '-') || (e.KeyChar == '.'))
            {
                return;
            }
            e.Handled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private async void Queue_work()
        {
            await Task.Run(() =>
            {
                while (true)
                {

                    if (N10.Count > 0)
                    {
                        if (N10.Peek().ThreadState.ToString() == "Background, Unstarted")
                        {
                            N10.Peek().Start();
                        }
                        else if (N10.Peek().IsAlive == false)
                        {
                            N10.Dequeue();
                        }
                    }
                }
            });
        }
    }
}