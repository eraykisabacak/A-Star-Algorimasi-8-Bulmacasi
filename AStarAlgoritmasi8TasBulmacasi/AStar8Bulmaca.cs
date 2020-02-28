using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStarAlgoritmasi8TasBulmacasi
{
    public partial class AStar8Bulmaca : Form
    {
        public AStar8Bulmaca()
        {
            InitializeComponent();
        }

        int[,] baslangicDurumu;
        public static int[,] amacDurumu;
        int selected_depth = 0;
        bool found = false;
        int Max_Depth = 20;

        node node = new node();

        void print_path(int[,] state,string action)
        {
            int[,] currect_state = state;

            if(action == "right")
            {
                currect_state = node.left(currect_state);
                node.actions.Add("right");
            }
            else if(action == "left")
            {
                currect_state = node.right(currect_state);
                node.actions.Add("left");
            }
            else if(action == "up")
            {
                currect_state = node.down(currect_state);
                node.actions.Add("up");
            }
            else if(action == "down")
            {
                currect_state = node.up(currect_state);
                node.actions.Add("down");
            }

            while (!node.match_array(currect_state, baslangicDurumu))
            {
                string currect_action = node.get_action(currect_state);

                if (currect_action == "right")
                {
                    currect_state = node.left(currect_state);
                    node.actions.Add("right");
                }
                else if (currect_action == "left")
                {
                    currect_state = node.right(currect_state);
                    node.actions.Add("left");
                }
                else if (currect_action == "up")
                {
                    currect_state = node.down(currect_state);
                    node.actions.Add("up");
                }
                else if (currect_action == "down")
                {
                    currect_state = node.up(currect_state);
                    node.actions.Add("down");
                }
            }

            for (int a = node.actions.Count - 1; a >= 0; a--)
            {

                if (node.actions[a] == "right")
                {
                    currect_state = node.right(currect_state);
                }

                else if (node.actions[a] == "left")
                {
                    currect_state = node.left(currect_state);
                }
                else if (node.actions[a] == "up")
                {
                    currect_state = node.up(currect_state);
                }
                else if (node.actions[a] == "down")
                {
                    currect_state = node.down(currect_state);
                }

                print_state(currect_state);
            }
        }

        void print_state(int[,] state)
        {
            string to_print = "";

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    to_print += state[j, i] + " ";
                }
                to_print += "\r\n";
            }
            txtSonuc.Text += to_print + Environment.NewLine;
        }

        private void txtBaslangic_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void btnCoz_Click(object sender, EventArgs e)
        {
                txtSonuc.Text = "";
                txtActions.Text = "";
                selected_depth = 0;
                found = false;
                Max_Depth = 20;
                baslangicDurumu = new int[3, 3];
                amacDurumu = new int[3, 3];
                node.FrontHere.Clear();
                node.CheckedList.Clear();
                node.actions.Clear();

                string[] bSayilar = txtBaslangic.Text.Split(',');
                string[] aSayilar = txtAmac.Text.Split(',');

                if (aSayilar.Length < 9 || bSayilar.Length < 9 || aSayilar.Contains("") || bSayilar.Contains(""))
                {
                    MessageBox.Show("Lütfen 9 Sayı Giriniz ve ',' ile ayırınız ");
                    return;
                }

                int count = 0;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        baslangicDurumu[i, j] = int.Parse(bSayilar[count++]);
                    }
                }

                count = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        amacDurumu[i, j] = int.Parse(aSayilar[count++]);
                    }
                }

                node start = new node()
                {
                    state = baslangicDurumu,
                    depth = 0
                };

                node.FrontHere.Add(start);


                node get_state()
                {
                    node what = new node();
                    int index = 0;
                    int selected_index = 0;
                    int min_f = Max_Depth + 9;
                    foreach (node nd in node.FrontHere)
                    {
                        if (nd.depth + node.h(nd.state) < min_f)
                        {
                            min_f = nd.depth + node.h(nd.state);
                            what.state = nd.state;
                            what.depth = nd.depth;
                            what.action = nd.action;
                            selected_index = index;
                        }
                        index++;
                    }

                   // node.FrontHere.RemoveAt(selected_index);

                    return what;
                }

                // [true,false]
                print_state(baslangicDurumu);

                while (node.FrontHere.Count != 0 && !found && selected_depth <= Max_Depth)
                {
                    node best_result = get_state();
                    if (node.match_array(best_result.state, amacDurumu))
                    {
                        print_path(best_result.state, best_result.action);
                        found = true;
                        MessageBox.Show("FOUND");
                        printUI(baslangicDurumu);
                        startTable();
                    }
                    else
                    {
                        if (node.canRight(best_result.state) && !node.wasChecked(node.right(best_result.state)))
                        {
                            node data = new node();
                            data.depth = best_result.depth + 1;
                            data.state = node.right(best_result.state);
                            data.action = "right";

                            node.FrontHere.Add(data);
                        }

                        if (node.canLeft(best_result.state) && !node.wasChecked(node.left(best_result.state)))
                        {
                            node data = new node();
                            data.depth = best_result.depth + 1;
                            data.state = node.left(best_result.state);
                            data.action = "left";

                            node.FrontHere.Add(data);
                        }

                        if (node.canDown(best_result.state) && !node.wasChecked(node.down(best_result.state)))
                        {
                            node data = new node();
                            data.depth = best_result.depth + 1;
                            data.state = node.down(best_result.state);
                            data.action = "down";

                            node.FrontHere.Add(data);
                        }

                        if (node.canUp(best_result.state) && !node.wasChecked(node.up(best_result.state)))
                        {
                            node data = new node();
                            data.depth = best_result.depth + 1;
                            data.state = node.up(best_result.state);
                            data.action = "up";

                            node.FrontHere.Add(data);
                        }

                        selected_depth = best_result.depth;
                        node.CheckedList.Add(best_result);
                    }
                    if (selected_depth > Max_Depth)
                    {
                        MessageBox.Show("Can't Solve!");
                        return;
                    }
                }
            
        }

        void printUI(int[,] state)
        {
            int a = 0;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Button btn = new Button();
                    btn.Name = "button" + a.ToString();
                    btn.Text = state[i,j].ToString();
                    btn.Size = new System.Drawing.Size(75,85);
                    btn.BackColor = Color.Red;
                    btn.ForeColor = Color.White;
                    int size = 20;
                    btn.Font = new Font(btn.Font.FontFamily, size);
                    btn.Location = new Point(78 + (j * 81), 181 + (i * 91));
                    this.Controls.Add(btn);
                    a++;
                }
            }
        }

        int zeroLocation1;
        int zeroLocation2;
        

        void startTable()
        {
            zeroLocation1 = node.zero_position(baslangicDurumu);
            zeroLocation2 = node.zero_position(baslangicDurumu, false);

            for(int i = node.actions.Count - 1; i >= 0; i--)
            {
                MessageBox.Show(node.actions[i]);
                if (node.actions[i] == "left")
                {
                    leftUI(zeroLocation1, zeroLocation2);
                }
                else if(node.actions[i] == "right")
                {
                    rightUI(zeroLocation1, zeroLocation2);
                }
                else if(node.actions[i] == "up")
                {
                    upUI(zeroLocation1, zeroLocation2);
                }
                else if(node.actions[i] == "down")
                {
                    downUI(zeroLocation1, zeroLocation2);
                }
                txtActions.Text += node.actions[i] + " ";
                System.Threading.Thread.Sleep(1000);
            }            
        }
        
        void rightUI(int i , int j)
        {
            int a = numberUI(i, j);
            
            Button zero = this.Controls.Find("button" + a,true).FirstOrDefault() as Button;

            Button number = this.Controls.Find("button" + (a + 1), true).FirstOrDefault() as Button;
            zeroLocation2 = j + 1;
            zero.Text = number.Text;
            number.Text = "0";
        }

        void leftUI(int i, int j)
        {
            int a = numberUI(i, j);

            Button zero = this.Controls.Find("button" + a, true).FirstOrDefault() as Button;

            Button number = this.Controls.Find("button" + (a - 1), true).FirstOrDefault() as Button;
            zeroLocation2 = j - 1;
            zero.Text = number.Text;
            number.Text = "0";
        }

        void upUI(int i, int j)
        {
            int a = numberUI(i, j);

            Button zero = this.Controls.Find("button" + a, true).FirstOrDefault() as Button;

            Button number = this.Controls.Find("button" + (a - 3), true).FirstOrDefault() as Button;
            zeroLocation1 = i - 1;
            zero.Text = number.Text;
            number.Text = "0";
        }

        void downUI(int i, int j)
        {
            int a = numberUI(i, j);

            Button zero = this.Controls.Find("button" + a, true).FirstOrDefault() as Button;

            Button number = this.Controls.Find("button" + (a + 3), true).FirstOrDefault() as Button;
            zeroLocation1 = i + 1;
            zero.Text = number.Text;
            number.Text = "0";
        }

        int numberUI(int i,int j)
        {
            int a = 0;
            if (i == 0 && j < 3)
            {
                a = j;
            }
            else if (i == 1)
            {
                a = j + 3;
            }
            else if (i == 2)
            {
                a = j + 6;
            }
            return a;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
