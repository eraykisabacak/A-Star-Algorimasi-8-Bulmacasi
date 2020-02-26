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

        List<node> FrontHere = new List<node>();
        List<node> CheckedList = new List<node>();
        static List<string> actions = new List<string>();

        int[,] baslangicDurumu;
        int[,] amacDurumu;
        int selected_depth = 0;
        bool found = false;
        int Max_Depth = 20;

       

        bool canRight(int[,] state)
        {
            for (int i = 0; i < 3; i++)
            {
                if (state[i, 2] == 0)
                {
                    return false;
                }
            }
            return true;
        }
        bool canLeft(int[,] state)
        {
            for (int i = 0; i < 3; i++)
            {
                if (state[i, 0] == 0)
                {
                    return false;
                }
            }
            return true;
        }
        bool canUp(int[,] state)
        {
            for (int i = 0; i < 3; i++)
            {
                if (state[0, i] == 0)
                {
                    return false;
                }
            }
            return true;
        }
        bool canDown(int[,] state)
        {
            for (int i = 0; i < 3; i++)
            {
                if (state[2, i] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        int[,] right(int[,] state)
        {
            int[,] what = new int[,]
            {
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 }
            };

            for (int h = 0; h < 3; h++)
            {
                for (int w = 0; w < 3; w++)
                {
                    what[h, w] = state[h, w];
                }
            }

            //[true,false]
            int i = zero_position(state);
            int j = zero_position(state, false);

            what[i, j] = state[i, j + 1];
            what[i, j + 1] = 0;
            return what;
        }

        int[,] left(int[,] state)
        {
            int[,] what = new int[,]
            {
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 }
            };

            for (int h = 0; h < 3; h++)
            {
                for (int w = 0; w < 3; w++)
                {
                    what[h, w] = state[h, w];
                }
            }

            //[true,false]
            int i = zero_position(state);
            int j = zero_position(state, false);

            what[i, j] = state[i, j - 1];
            what[i, j - 1] = 0;
            return what;
        }

        int[,] up(int[,] state)
        {
            int[,] what = new int[,]
            {
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 }
            };

            for (int h = 0; h < 3; h++)
            {
                for (int w = 0; w < 3; w++)
                {
                    what[h, w] = state[h, w];
                }
            }

            //[true,false]
            int i = zero_position(state);
            int j = zero_position(state, false);

            what[i, j] = state[i - 1, j];
            what[i - 1 , j] = 0;
            return what;
        }

        int[,] down(int[,] state)
        {
            int[,] what = new int[,]
            {
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 }
            };

            for (int h = 0; h < 3; h++)
            {
                for (int w = 0; w < 3; w++)
                {
                    what[h, w] = state[h, w];
                }
            }

            //[true,false]
            int i = zero_position(state);
            int j = zero_position(state, false);

            what[i, j] = state[i + 1, j];
            what[i + 1, j] = 0;
            return what;
        }

        int zero_position(int[,] state, bool d = true)
        {
            int what = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state[i, j] == 0)
                    {
                        if (d)
                            what = i;
                        else
                            what = j;
                    }
                }
            }
            return what;
        }

        bool wasChecked(int[,] state)
        {
            bool what = false;
            
            foreach(node nd in CheckedList)
            {
                if (match_array(nd.state, state))
                {
                    what = true;
                }
            }
            return what;
        }

        bool match_array(int[,] state1, int[,] state2)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (state1[i, j] != state2[i, j])
                        return false;
                }
            }
            return true;
        }

        int h(int[,] state)
        {
            int match = 0;

            for (int j = 0 ; j < 3 ; j++)
            {
                for(int i = 0; i < 3; i++)
                {
                    if (state[j, i] == amacDurumu[j, i]) match++;
                }
            }
            return 9 - match;
        }

        string get_action(int[,] state)
        {
            foreach(node nd in CheckedList)
            {
                if(match_array(nd.state, state))
                {
                    return nd.action;
                }
            }
            return "none";
        }

        void print_path(int[,] state,string action)
        {
            int[,] currect_state = state;

            if(action == "right")
            {
                currect_state = left(currect_state);
                actions.Add("right");
            }
            else if(action == "left")
            {
                currect_state = right(currect_state);
                actions.Add("left");
            }
            else if(action == "up")
            {
                currect_state = down(currect_state);
                actions.Add("up");
            }
            else if(action == "down")
            {
                currect_state = up(currect_state);
                actions.Add("down");
            }

            while (!match_array(currect_state, baslangicDurumu))
            {
                string currect_action = get_action(currect_state);

                if (currect_action == "right")
                {
                    currect_state = left(currect_state);
                    actions.Add("right");
                }
                else if (currect_action == "left")
                {
                    currect_state = right(currect_state);
                    actions.Add("left");
                }
                else if (currect_action == "up")
                {
                    currect_state = down(currect_state);
                    actions.Add("up");
                }
                else if (currect_action == "down")
                {
                    currect_state = up(currect_state);
                    actions.Add("down");
                }
            }

            for (int a = actions.Count - 1; a >= 0; a--)
            {

                if (actions[a] == "right")
                {
                    currect_state = right(currect_state);
                }

                else if (actions[a] == "left")
                {
                    currect_state = left(currect_state);
                }
                else if (actions[a] == "up")
                {
                    currect_state = up(currect_state);
                }
                else if (actions[a] == "down")
                {
                    currect_state = down(currect_state);
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
                FrontHere.Clear();
                CheckedList.Clear();
                actions.Clear();

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

                FrontHere.Add(start);


                node get_state()
                {
                    node what = new node();
                    int index = 0;
                    int selected_index = 0;
                    int min_f = Max_Depth + 9;
                    foreach (node nd in FrontHere)
                    {
                        if (nd.depth + h(nd.state) < min_f)
                        {
                            min_f = nd.depth + h(nd.state);
                            what.state = nd.state;
                            what.depth = nd.depth;
                            what.action = nd.action;
                            selected_index = index;
                        }
                        index++;
                    }

                    FrontHere.RemoveAt(selected_index);

                    return what;
                }

                // [true,false]
                print_state(baslangicDurumu);

                while (FrontHere.Count != 0 && !found && selected_depth <= Max_Depth)
                {
                    node best_result = get_state();
                    if (match_array(best_result.state, amacDurumu))
                    {
                        print_path(best_result.state, best_result.action);
                        found = true;
                        MessageBox.Show("FOUND");
                        printUI(baslangicDurumu);
                        startTable();
                    }
                    else
                    {
                        if (canRight(best_result.state) && !wasChecked(right(best_result.state)))
                        {
                            node data = new node();
                            data.depth = best_result.depth + 1;
                            data.state = right(best_result.state);
                            data.action = "right";

                            FrontHere.Add(data);
                        }

                        if (canLeft(best_result.state) && !wasChecked(left(best_result.state)))
                        {
                            node data = new node();
                            data.depth = best_result.depth + 1;
                            data.state = left(best_result.state);
                            data.action = "left";

                            FrontHere.Add(data);
                        }

                        if (canDown(best_result.state) && !wasChecked(down(best_result.state)))
                        {
                            node data = new node();
                            data.depth = best_result.depth + 1;
                            data.state = down(best_result.state);
                            data.action = "down";

                            FrontHere.Add(data);
                        }

                        if (canUp(best_result.state) && !wasChecked(up(best_result.state)))
                        {
                            node data = new node();
                            data.depth = best_result.depth + 1;
                            data.state = up(best_result.state);
                            data.action = "up";

                            FrontHere.Add(data);
                        }

                        selected_depth = best_result.depth;
                        CheckedList.Add(best_result);
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
            zeroLocation1 = zero_position(baslangicDurumu);
            zeroLocation2 = zero_position(baslangicDurumu, false);
            MessageBox.Show(zeroLocation2 + " " + zeroLocation2);

            for(int i = actions.Count - 1; i >= 0; i--)
            {
                System.Threading.Thread.Sleep(1000);
                MessageBox.Show(i + " " + actions[i]);
                if (actions[i] == "left")
                {
                    leftUI(zeroLocation1, zeroLocation2);
                }
                else if(actions[i] == "right")
                {
                    rightUI(zeroLocation1, zeroLocation2);
                }
                else if(actions[i] == "up")
                {
                    upUI(zeroLocation1, zeroLocation2);
                }
                else if(actions[i] == "down")
                {
                    downUI(zeroLocation1, zeroLocation2);
                }
                txtActions.Text += actions[i] + " ";
               
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
