using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarAlgoritmasi8TasBulmacasi
{
    class node
    {
        public int[,] state;
        public string action;
        public int depth;

        public List<node> FrontHere = new List<node>();
        public List<node> CheckedList = new List<node>();
        public List<string> actions = new List<string>();

        public bool canRight(int[,] state)
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
        public bool canLeft(int[,] state)
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
        public bool canUp(int[,] state)
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
        public bool canDown(int[,] state)
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

        public int[,] right(int[,] state)
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

        public int[,] left(int[,] state)
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

        public int[,] up(int[,] state)
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
            what[i - 1, j] = 0;
            return what;
        }

        public int[,] down(int[,] state)
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

        public int zero_position(int[,] state, bool d = true)
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

        public bool wasChecked(int[,] state)
        {
            bool what = false;

            foreach (node nd in CheckedList)
            {
                if (match_array(nd.state, state))
                {
                    what = true;
                }
            }
            return what;
        }

        public bool match_array(int[,] state1, int[,] state2)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state1[i, j] != state2[i, j])
                        return false;
                }
            }
            return true;
        }

        public int h(int[,] state)
        {
            int match = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state[i, j] == AStar8Bulmaca.amacDurumu[i, j]) match++;
                }
            }
            return 9 - match;
        }

        public  string get_action(int[,] state)
        {
            foreach (node nd in CheckedList)
            {
                if (match_array(nd.state, state))
                {
                    return nd.action;
                }
            }
            return "none";
        }
    }
}
