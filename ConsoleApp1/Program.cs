using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess
{
    class CPE480
    {
        public int[,] postions;
        public int h;
        public string move;
        public double alpha;
        public double beta;
        static int count = 0;
        static string color_stone;

        public CPE480(int[,] postions, double minvalue, double maxvalue)
        {
            this.h = 0;
            this.move = " ";
            this.beta = maxvalue;
            this.alpha = minvalue;
            this.postions = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    this.postions[i, j] = postions[i, j];
            }

        }

        public static string Project(int[][] Position1)
        {
            int [,]arr = new int[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    arr[i, j] = Position1[i][j];
            return Project1(arr);
        }
        public static string Project1(int[,] Position1)
        {
            CPE480 obj = new CPE480(Position1, Double.MinValue, Double.MaxValue);


            if (count == 0)
            {
                count++;

                if (obj.cheack(Position1))
                {
                    color_stone = "white";
                    obj.move = obj.alpha_beta(color_stone);
                }
                else
                {
                    color_stone = "black";
                    obj.move = obj.alpha_beta(color_stone);
                }
            }
            else
            {
                obj.move = obj.alpha_beta(color_stone);
            }











            return obj.move;
        }
        public bool cheack(int[,] position2)
        {
            int[,] start_chess = new int[8, 8] {
                                               {4,0,0,0,0,0,0,4},
                                               {3,3,3,3,3,3,3,3},
                                               {0,0,0,0,0,0,0,0},
                                               {0,0,0,0,0,0,0,0},
                                               {0,0,0,0,0,0,0,0},
                                               {0,0,0,0,0,0,0,0},
                                               {1,1,1,1,1,1,1,1},
                                               {2,0,0,0,0,0,0,2}
            };
            bool flag = true;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (position2[i, j] != start_chess[i, j])
                    {
                        flag = false;
                        break;

                    }
                }
                if (!flag)
                {
                    break;
                }

            }




            return flag;


        }




        public string alpha_beta(string copy_color_stone)
        {
            CPE480[] state_move_white = new CPE480[100];
            int length_white = 0;
            if (copy_color_stone == "white")
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (this.postions[i, j] == 1)
                        {

                            if (j == 0)
                            {

                                if (this.postions[i - 1, j + 1] == 3 || this.postions[i - 1, j + 1] == 4)
                                {
                                    int t1 = this.postions[i - 1, j + 1];

                                    if (i - 1 == 0)
                                    {
                                        this.postions[i - 1, j + 1] = 2;
                                        this.postions[i, j] = 0;
                                    }
                                    else
                                    {
                                        this.postions[i - 1, j + 1] = 1;
                                        this.postions[i, j] = 0;

                                    }
                                    state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                    this.postions[i - 1, j + 1] = t1;
                                    this.postions[i, j] = 1;
                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;
                                        this.move = 'a' + (8 - i).ToString() + 'b' + (8 - i + 1).ToString();
                                        length_white++;
                                    }

                                }




                                if (i == 6)
                                {
                                    if (this.postions[i - 2, j] == 0 && (this.postions[i - 1, j] == 0))
                                    {
                                        int t1 = this.postions[i - 2, j];


                                        if (i - 2 == 0)
                                        {
                                            this.postions[i - 2, j] = 2;
                                            this.postions[i, j] = 0;
                                        }
                                        else
                                        {
                                            this.postions[i - 2, j] = 1;
                                            this.postions[i, j] = 0;

                                        }
                                        state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                        this.postions[i - 2, j] = t1;
                                        this.postions[i, j] = 1;
                                        state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                        if (this.alpha < state_move_white[length_white].beta)
                                        {
                                            this.alpha = state_move_white[length_white].beta;
                                            this.move = 'a' + (8 - i).ToString() + 'a' + (8 - i + 2).ToString();
                                            length_white++;
                                        }




                                    }
                                    if (this.postions[i - 1, j] == 0)
                                    {
                                        int t1 = this.postions[i - 1, j];



                                        this.postions[i - 1, j] = 1;
                                        this.postions[i, j] = 0;


                                        state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                        this.postions[i - 1, j] = t1;
                                        this.postions[i, j] = 1;

                                        state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                        if (this.alpha < state_move_white[length_white].beta)
                                        {
                                            this.alpha = state_move_white[length_white].beta;
                                            this.move = 'a' + (8 - i).ToString() + 'a' + (8 - i + 1).ToString();
                                            length_white++;
                                        }




                                    }

                                }
                                else if (i != 6)
                                {
                                    if (this.postions[i - 1, j] == 0)
                                    {
                                        int t1 = this.postions[i - 1, j];


                                        if (i - 1 == 0)
                                        {
                                            this.postions[i - 1, j] = 2;
                                            this.postions[i, j] = 0;
                                        }
                                        else
                                        {
                                            this.postions[i - 1, j] = 1;
                                            this.postions[i, j] = 0;

                                        }
                                        state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                        this.postions[i - 1, j] = t1;
                                        this.postions[i, j] = 1;

                                        state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                        if (this.alpha < state_move_white[length_white].beta)
                                        {
                                            this.alpha = state_move_white[length_white].beta;
                                            this.move = 'a' + (8 - i).ToString() + 'a' + (8 - i + 1).ToString();
                                            length_white++;
                                        }



                                    }
                                }

                            }
                            else if (j == 7)
                            {

                                if (this.postions[i - 1, j - 1] == 3 || this.postions[i - 1, j - 1] == 4)
                                {
                                    int t1 = this.postions[i - 1, j - 1];

                                    if (i - 1 == 0)
                                    {
                                        this.postions[i - 1, j - 1] = 2;
                                        this.postions[i, j] = 0;
                                    }
                                    else
                                    {
                                        this.postions[i - 1, j - 1] = 1;
                                        this.postions[i, j] = 0;

                                    }
                                    state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                    this.postions[i - 1, j - 1] = t1;
                                    this.postions[i, j] = 1;
                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;
                                        this.move = 'h' + (8 - i).ToString() + 'g' + (8 - i + 1).ToString();
                                        length_white++;
                                    }
                                }
                                if (i == 6)
                                {
                                    if (this.postions[i - 2, j] == 0 && (this.postions[i - 1, j] == 0))
                                    {
                                        int t1 = this.postions[i - 2, j];


                                        if (i - 2 == 0)
                                        {
                                            this.postions[i - 2, j] = 2;
                                            this.postions[i, j] = 0;
                                        }
                                        else
                                        {
                                            this.postions[i - 2, j] = 1;
                                            this.postions[i, j] = 0;

                                        }
                                        state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                        this.postions[i - 2, j] = t1;
                                        this.postions[i, j] = 1;

                                        state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                        if (this.alpha < state_move_white[length_white].beta)
                                        {
                                            this.alpha = state_move_white[length_white].beta;
                                            this.move = 'h' + (8 - i).ToString() + 'h' + (8 - i + 2).ToString();
                                            length_white++;
                                        }
                                    }
                                    if (this.postions[i - 1, j] == 0)
                                    {
                                        int t1 = this.postions[i - 1, j];


                                        if (i - 1 == 0)
                                        {
                                            this.postions[i - 1, j] = 2;
                                            this.postions[i, j] = 0;
                                        }
                                        else
                                        {
                                            this.postions[i - 1, j] = 1;
                                            this.postions[i, j] = 0;

                                        }
                                        state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                        this.postions[i - 1, j] = t1;
                                        this.postions[i, j] = 1;

                                        state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                        if (this.alpha < state_move_white[length_white].beta)
                                        {
                                            this.alpha = state_move_white[length_white].beta;

                                            this.move = 'h' + (8 - i).ToString() + 'h' + (8 - i + 1).ToString();
                                            length_white++;



                                        }
                                    }


                                }
                                else if (i != 6)
                                {
                                    if (this.postions[i - 1, j] == 0)
                                    {
                                        int t1 = this.postions[i - 1, j];


                                        if (i - 1 == 0)
                                        {
                                            this.postions[i - 1, j] = 2;
                                            this.postions[i, j] = 0;
                                        }
                                        else
                                        {
                                            this.postions[i - 1, j] = 1;
                                            this.postions[i, j] = 0;

                                        }
                                        state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                        this.postions[i - 1, j] = t1;
                                        this.postions[i, j] = 1;

                                        state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                        if (this.alpha < state_move_white[length_white].beta)
                                        {
                                            this.alpha = state_move_white[length_white].beta;
                                            this.move = 'h' + (8 - i).ToString() + 'h' + (8 - i + 1).ToString();
                                            length_white++;
                                        }


                                    }
                                }
                            }
                            else if (i == 6)
                            {

                                if (this.postions[i - 1, j + 1] == 3 || this.postions[i - 1, j + 1] == 4)
                                {
                                    int t1 = this.postions[i - 1, j + 1];


                                    this.postions[i - 1, j + 1] = 1;
                                    this.postions[i, j] = 0;


                                    state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                    this.postions[i - 1, j + 1] = t1;
                                    this.postions[i, j] = 1;
                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;

                                        this.move = (char)(97 + j) + (8 - i).ToString() + (char)(97 + j + 1) + ((8 - i) + 1).ToString();
                                        length_white++;


                                    }
                                }
                                if (this.postions[i - 1, j - 1] == 3 || this.postions[i - 1, j - 1] == 4)
                                {
                                    int t1 = this.postions[i - 1, j - 1];


                                    this.postions[i - 1, j - 1] = 1;
                                    this.postions[i, j] = 0;


                                    state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                    this.postions[i - 1, j - 1] = t1;
                                    this.postions[i, j] = 1;
                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;
                                        this.move = (char)(97 + j) + (8 - i).ToString() + (char)(97 + j - 1) + ((8 - i) + 1).ToString();
                                        length_white++;

                                    }
                                }
                                if (this.postions[i - 2, j] == 0 && (this.postions[i - 1, j] == 0))
                                {
                                    int t1 = this.postions[i - 2, j];


                                    this.postions[i - 2, j] = 1;
                                    this.postions[i, j] = 0;


                                    state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                    this.postions[i - 2, j] = t1;
                                    this.postions[i, j] = 1;
                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;

                                        this.move = (char)(97 + j) + (8 - i).ToString() + (char)(97 + j) + ((8 - i) + 2).ToString();
                                        length_white++;
                                    }




                                }
                                if (this.postions[i - 1, j] == 0)
                                {
                                    int t1 = this.postions[i - 1, j];

                                    this.postions[i - 1, j] = 1;
                                    this.postions[i, j] = 0;


                                    state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                    this.postions[i - 1, j] = t1;
                                    this.postions[i, j] = 1;

                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;
                                        this.move = (char)(97 + j) + (8 - i).ToString() + (char)(97 + j) + ((8 - i) + 1).ToString();
                                        length_white++;
                                    }



                                }


                            }
                            else if (i != 6)
                            {
                                if (this.postions[i - 1, j + 1] == 3 || this.postions[i - 1, j + 1] == 4)
                                {
                                    int t1 = this.postions[i - 1, j + 1];

                                    if (i - 1 == 0)
                                    {
                                        this.postions[i - 1, j + 1] = 2;
                                        this.postions[i, j] = 0;
                                    }
                                    else
                                    {
                                        this.postions[i - 1, j + 1] = 1;
                                        this.postions[i, j] = 0;

                                    }
                                    state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                    this.postions[i - 1, j + 1] = t1;
                                    this.postions[i, j] = 1;
                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;
                                        this.move = (char)(97 + j) + (8 - i).ToString() + (char)(97 + j + 1) + ((8 - i) + 1).ToString();
                                        length_white++;
                                    }
                                }
                                if (this.postions[i - 1, j - 1] == 3 || this.postions[i - 1, j - 1] == 4)
                                {
                                    int t1 = this.postions[i - 1, j - 1];

                                    if (i - 1 == 0)
                                    {
                                        this.postions[i - 1, j - 1] = 2;
                                        this.postions[i, j] = 0;
                                    }
                                    else
                                    {
                                        this.postions[i - 1, j - 1] = 1;
                                        this.postions[i, j] = 0;

                                    }
                                    state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                    this.postions[i - 1, j - 1] = t1;
                                    this.postions[i, j] = 1;
                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;
                                        this.move = (char)(97 + j) + (8 - i).ToString() + (char)(97 + j - 1) + ((8 - i) + 1).ToString();
                                        length_white++;
                                    }
                                }
                                if (this.postions[i - 1, j] == 0)
                                {
                                    int t1 = this.postions[i - 1, j];


                                    if (i - 1 == 0)
                                    {
                                        this.postions[i - 1, j] = 2;
                                        this.postions[i, j] = 0;
                                    }
                                    else
                                    {
                                        this.postions[i - 1, j] = 1;
                                        this.postions[i, j] = 0;

                                    }
                                    state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                    this.postions[i - 1, j] = t1;
                                    this.postions[i, j] = 1;

                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;
                                        this.move = (char)(97 + j) + (8 - i).ToString() + (char)(97 + j) + (8 - i + 1).ToString();
                                        length_white++;
                                    }


                                }

                            }
                        }
                        else if (this.postions[i, j] == 2)
                        {
                            int h = i;
                            int v = j;
                            if (h != 7)
                            {
                                bool f = false;
                                int k0 = h + 1;
                                for (; k0 <= 7; k0++)
                                {
                                    if (this.postions[k0, v] == 1 || this.postions[k0, v] == 2)
                                    {
                                        break;
                                    }
                                    else if (this.postions[k0, v] == 3 || this.postions[k0, v] == 4)
                                    {
                                        int t1 = this.postions[k0, v];
                                        this.postions[k0, v] = 2;
                                        this.postions[i, j] = 0;
                                        state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                        this.postions[k0, v] = t1;
                                        this.postions[i, j] = 2;
                                        f = true;
                                        break;
                                    }
                                }
                                if (f)
                                {
                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;

                                        this.move = (char)(97 + v) + (8 - h).ToString() + (char)(97 + v) + (8 - k0).ToString();
                                        length_white++;

                                    }
                                    f = false;
                                }
                                int k1 = h - 1;

                                for (; k1 >= 0; k1--)
                                {
                                    if (this.postions[k1, v] == 1 || this.postions[k1, v] == 2)
                                    {
                                        break;
                                    }
                                    if (this.postions[k1, v] == 3 || this.postions[k1, v] == 4)
                                    {
                                        int t1 = this.postions[k1, v];
                                        this.postions[k1, v] = 2;
                                        this.postions[i, j] = 0;
                                        state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                        this.postions[k1, v] = t1;
                                        this.postions[i, j] = 2;

                                        f = true;
                                        break;
                                    }
                                }

                                if (f)
                                {
                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;
                                        this.move = (char)(97 + v) + (8 - h).ToString() + (char)(97 + v) + (8 - k1).ToString();
                                        length_white++;
                                    }

                                }
                            }
                            else if (h == 7)
                            {
                                bool f = false;
                                int k0 = h - 1;
                                for (; k0 >= 0; k0--)
                                {
                                    if (this.postions[k0, v] == 1 || this.postions[k0, v] == 2)
                                    {
                                        break;
                                    }
                                    else if (this.postions[k0, v] == 3 || this.postions[k0, v] == 4)
                                    {
                                        int t1 = this.postions[k0, v];
                                        this.postions[k0, v] = 2;
                                        this.postions[i, j] = 0;
                                        state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                        this.postions[k0, v] = t1;
                                        this.postions[i, j] = 2;
                                        f = true;
                                        break;
                                    }
                                }
                                if (f)
                                {
                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;
                                        this.move = (char)(97 + v) + (8 - h).ToString() + (char)(97 + v) + (8 - k0).ToString();
                                        length_white++;
                                    }
                                    f = false;
                                }


                            }
                            h = i;
                            v = j;
                            if (v != 0)
                            {
                                bool f = false;
                                int k0 = v + 1;
                                for (; k0 <= 7; k0++)
                                {
                                    if (this.postions[h, k0] == 1 || this.postions[h, k0] == 2)
                                    {
                                        break;
                                    }
                                    else if (this.postions[h, k0] == 3 || this.postions[h, k0] == 4)
                                    {
                                        int t1 = this.postions[h, k0];
                                        this.postions[h, k0] = 2;
                                        this.postions[i, j] = 0;
                                        state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                        this.postions[h, k0] = t1;
                                        this.postions[i, j] = 2;
                                        f = true;
                                        break;
                                    }
                                }
                                if (f)
                                {
                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;


                                        this.move = (char)(97 + v) + (8 - h).ToString() + (char)(97 + k0) + (8 - h).ToString();
                                        length_white++;
                                    }
                                    f = false;
                                }

                                int k1 = v - 1;
                                for (; k1 >= 0; k1--)
                                {
                                    if (this.postions[h, k1] == 1 || this.postions[h, k1] == 2)
                                    {
                                        break;
                                    }
                                    if (this.postions[h, k1] == 3 || this.postions[h, k1] == 4)
                                    {
                                        int t1 = this.postions[h, k1];
                                        this.postions[h, k1] = 2;
                                        this.postions[i, j] = 0;
                                        state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                        this.postions[h, k1] = t1;
                                        this.postions[i, j] = 2;

                                        f = true;
                                        break;
                                    }
                                }

                                if (f)
                                {
                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;
                                        this.move = (char)(97 + v) + (8 - h).ToString() + (char)(97 + k1) + (8 - h).ToString();
                                        length_white++;


                                    }

                                }
                            }
                            else if (v == 0)
                            {
                                bool f = false;
                                int k0 = v + 1;
                                for (; k0 <= 7; k0++)
                                {
                                    if (this.postions[h, k0] == 1 || this.postions[h, k0] == 2)
                                    {
                                        break;
                                    }
                                    else if (this.postions[h, k0] == 3 || this.postions[h, k0] == 4)
                                    {
                                        int t1 = this.postions[h, k0];
                                        this.postions[h, k0] = 2;
                                        this.postions[i, j] = 0;
                                        state_move_white[length_white] = new CPE480(this.postions, this.alpha, Double.MaxValue);
                                        this.postions[h, k0] = t1;
                                        this.postions[i, j] = 2;
                                        f = true;
                                        break;
                                    }
                                }
                                if (f)
                                {
                                    state_move_white[length_white].beta = THE_BEST_MOVE_IN_DEBTH_TWO_Black(state_move_white[length_white]);
                                    if (this.alpha < state_move_white[length_white].beta)
                                    {
                                        this.alpha = state_move_white[length_white].beta;
                                        this.move = (char)(97 + v) + (8 - h).ToString() + (char)(97 + k0) + (8 - h).ToString();
                                        length_white++;

                                    }
                                    f = false;
                                }


                            }

                        }





                    }








                }
            }
            else if (copy_color_stone == "black")
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (this.postions[i, j] == 3)
                        {

                            if (j == 0)
                            {

                                if (this.postions[i + 1, j + 1] == 1 || this.postions[i + 1, j + 1] == 2)
                                {
                                    int t1 = this.postions[i + 1, j + 1];

                                    if (i + 1 == 7)
                                    {
                                        this.postions[i + 1, j + 1] = 4;
                                        this.postions[i, j] = 0;
                                    }
                                    else
                                    {
                                        this.postions[i + 1, j + 1] = 3;
                                        this.postions[i, j] = 0;

                                    }
                                    state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                    this.postions[i + 1, j + 1] = t1;
                                    this.postions[i, j] = 3;
                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta > state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;
                                        this.move = 'a' + (8 - i).ToString() + 'b' + (8 - i - 1).ToString();
                                        length_white++;
                                    }

                                }




                                if (i == 1)
                                {
                                    if (this.postions[i + 1, j] == 0)
                                    {
                                        int t1 = this.postions[i + 1, j];

                                        this.postions[i + 1, j] = 3;
                                        this.postions[i, j] = 0;

                                        state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                        this.postions[i + 1, j] = t1;
                                        this.postions[i, 0] = 3;

                                        state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                        if (this.beta > state_move_white[length_white].alpha)
                                        {
                                            this.beta = state_move_white[length_white].alpha;
                                            this.move = 'a' + (8 - i).ToString() + 'a' + (8 - i - 1).ToString();
                                            length_white++;
                                        }




                                    }
                                    if (this.postions[i + 2, j] == 0 && (this.postions[i + 1, j] == 0))
                                    {
                                        int t1 = this.postions[i + 2, j];



                                        this.postions[i + 2, j] = 3;
                                        this.postions[i, j] = 0;

                                        state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                        this.postions[i + 2, j] = t1;
                                        this.postions[i, j] = 3;
                                        state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                        if (this.beta > state_move_white[length_white].alpha)
                                        {
                                            this.beta = state_move_white[length_white].alpha;
                                            this.move = 'a' + (8 - i).ToString() + 'a' + (8 - i - 2).ToString();
                                            length_white++;
                                        }




                                    }
                                }
                                else if (i != 1)
                                {
                                    if (this.postions[i + 1, j] == 0)
                                    {
                                        int t1 = this.postions[i + 1, j];


                                        if (i + 1 == 7)
                                        {
                                            this.postions[i + 1, j] = 4;
                                            this.postions[i, j] = 0;
                                        }
                                        else
                                        {
                                            this.postions[i + 1, j] = 3;
                                            this.postions[i, j] = 0;

                                        }
                                        state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                        this.postions[i + 1, j] = t1;
                                        this.postions[i, 0] = 3;

                                        state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                        if (this.beta > state_move_white[length_white].alpha)
                                        {
                                            this.beta = state_move_white[length_white].beta;
                                            this.move = 'a' + (8 - i).ToString() + 'a' + (8 - i - 1).ToString();
                                            length_white++;
                                        }



                                    }
                                }

                            }
                            else if (j == 7)
                            {

                                if (this.postions[i + 1, j - 1] == 1 || this.postions[i + 1, j - 1] == 2)
                                {
                                    int t1 = this.postions[i + 1, j - 1];

                                    if (i + 1 == 7)
                                    {
                                        this.postions[i + 1, j - 1] = 4;
                                        this.postions[i, j] = 0;
                                    }
                                    else
                                    {
                                        this.postions[i + 1, j - 1] = 3;
                                        this.postions[i, j] = 0;

                                    }
                                    state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                    this.postions[i + 1, j - 1] = t1;
                                    this.postions[i, j] = 3;
                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta > state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;
                                        this.move = 'h' + (8 - i).ToString() + 'g' + (8 - i - 1).ToString();
                                        length_white++;
                                    }
                                }
                                if (i == 1)
                                {
                                    if (this.postions[i + 1, j] == 0)
                                    {
                                        int t1 = this.postions[i + 1, j];


                                        this.postions[i + 1, j] = 3;
                                        this.postions[i, j] = 0;


                                        state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                        this.postions[i + 1, j] = t1;
                                        this.postions[i, 0] = 3;

                                        state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                        if (this.beta > state_move_white[length_white].alpha)
                                        {
                                            this.beta = state_move_white[length_white].alpha;

                                            this.move = 'h' + (8 - i).ToString() + 'h' + (8 - i - 1).ToString();
                                            length_white++;



                                        }
                                    }

                                    if (this.postions[i + 2, j] == 0 && (this.postions[i + 1, j] == 0))
                                    {
                                        int t1 = this.postions[i + 2, j];



                                        this.postions[i + 2, j] = 3;
                                        this.postions[i, j] = 0;


                                        state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                        this.postions[i + 2, j] = t1;
                                        this.postions[i, j] = 1;

                                        state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                        if (this.beta > state_move_white[length_white].alpha)
                                        {
                                            this.beta = state_move_white[length_white].alpha;
                                            this.move = 'h' + (8 - i).ToString() + 'h' + (8 - i - 2).ToString();
                                            length_white++;
                                        }
                                    }
                                }
                                else if (i != 1)
                                {
                                    if (this.postions[i + 1, j] == 0)
                                    {
                                        int t1 = this.postions[i + 1, j];


                                        if (i + 1 == 7)
                                        {
                                            this.postions[i + 1, j] = 4;
                                            this.postions[i, j] = 0;
                                        }
                                        else
                                        {
                                            this.postions[i + 1, j] = 3;
                                            this.postions[i, j] = 0;

                                        }
                                        state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                        this.postions[i + 1, j] = t1;
                                        this.postions[i, j] = 3;

                                        state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                        if (this.beta > state_move_white[length_white].alpha)
                                        {
                                            this.beta = state_move_white[length_white].alpha;
                                            this.move = 'h' + (8 - i).ToString() + 'h' + (8 - i - 1).ToString();
                                            length_white++;
                                        }


                                    }
                                }
                            }
                            else if (i == 1)
                            {

                                if (this.postions[i + 1, j + 1] == 1 || this.postions[i + 1, j + 1] == 2)
                                {
                                    int t1 = this.postions[i + 1, j + 1];


                                    this.postions[i + 1, j + 1] = 3;
                                    this.postions[i, j] = 0;


                                    state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                    this.postions[i + 1, j + 1] = t1;
                                    this.postions[i, j] = 3;
                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta > state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;

                                        this.move = (char)(97 + j) + (8 - i).ToString() + (char)(97 + j + 1) + ((8 - i) - 1).ToString();

                                        length_white++;
                                    }
                                }
                                if (this.postions[i + 1, j - 1] == 1 || this.postions[i + 1, j - 1] == 2)
                                {
                                    int t1 = this.postions[i + 1, j - 1];


                                    this.postions[i + 1, j - 1] = 3;
                                    this.postions[i, j] = 0;


                                    state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                    this.postions[i + 1, j - 1] = t1;
                                    this.postions[i, j] = 1;
                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta > state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;
                                        this.move = (char)(97 + j) + (8 - i).ToString() + (char)(97 + j - 1) + ((8 - i) - 1).ToString();
                                        length_white++;

                                    }
                                }
                                if (this.postions[i + 1, j] == 0)
                                {
                                    int t1 = this.postions[i + 1, j];



                                    this.postions[i + 1, j] = 3;
                                    this.postions[i, j] = 0;


                                    state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                    this.postions[i + 1, j] = t1;
                                    this.postions[i, j] = 3;

                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta > state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;
                                        this.move = (char)(97 + j) + (8 - i).ToString() + (char)(97 + j) + ((8 - i) - 1).ToString();
                                        length_white++;
                                    }



                                }
                                if (this.postions[i + 2, j] == 0 && (this.postions[i + 1, j] == 0))
                                {
                                    int t1 = this.postions[i + 2, j];



                                    this.postions[i + 2, j] = 3;
                                    this.postions[i, j] = 0;


                                    state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                    this.postions[i + 2, j] = t1;
                                    this.postions[i, j] = 3;
                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta > state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;

                                        this.move = (char)(97 + j) + (8 - i).ToString() + (char)(97 + j) + ((8 - i) - 2).ToString();
                                        length_white++;
                                    }




                                }

                            }
                            else if (i != 1)
                            {
                                if (this.postions[i + 1, j + 1] == 1 || this.postions[i + 1, j + 1] == 2)
                                {
                                    int t1 = this.postions[i + 1, j + 1];

                                    if (i + 1 == 7)
                                    {
                                        this.postions[i - 1, j + 1] = 4;
                                        this.postions[i, j] = 0;
                                    }
                                    else
                                    {
                                        this.postions[i + 1, j + 1] = 3;
                                        this.postions[i, j] = 0;

                                    }
                                    state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                    this.postions[i + 1, j + 1] = t1;
                                    this.postions[i, j] = 3;
                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta > state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;
                                        this.move = (char)(97 + j) + (8 - i).ToString() + (char)(97 + j + 1) + ((8 - i) - 1).ToString();
                                    }
                                }
                                if (this.postions[i + 1, j - 1] == 1 || this.postions[i + 1, j - 1] == 2)
                                {
                                    int t1 = this.postions[i + 1, j - 1];

                                    if (i + 1 == 7)
                                    {
                                        this.postions[i + 1, j - 1] = 4;
                                        this.postions[i, j] = 0;
                                    }
                                    else
                                    {
                                        this.postions[i + 1, j - 1] = 3;
                                        this.postions[i, j] = 0;

                                    }
                                    state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                    this.postions[i + 1, j - 1] = t1;
                                    this.postions[i, j] = 3;
                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta > state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;
                                        this.move = (char)(97 + j) + (8 - i).ToString() + (char)(97 + j - 1) + ((8 - i) - 1).ToString();
                                        length_white++;
                                    }
                                }
                                if (this.postions[i + 1, j] == 0)
                                {
                                    int t1 = this.postions[i + 1, j];


                                    if (i + 1 == 7)
                                    {
                                        this.postions[i + 1, j] = 4;
                                        this.postions[i, j] = 0;
                                    }
                                    else
                                    {
                                        this.postions[i + 1, j] = 3;
                                        this.postions[i, j] = 0;

                                    }
                                    state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                    this.postions[i + 1, j] = t1;
                                    this.postions[i, j] = 3;

                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta > state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;
                                        this.move = (char)(97 + j) + (8 - i).ToString() + (char)(97 + j) + (8 - i - 1).ToString();
                                        length_white++;
                                    }


                                }

                            }
                        }
                        else if (this.postions[i, j] == 4)
                        {
                            int h = i;
                            int v = j;
                            if (h != 0)
                            {
                                bool f = false;
                                int k0 = h - 1;
                                for (; k0 >= 0; k0++)
                                {
                                    if (this.postions[k0, v] == 3 || this.postions[k0, v] == 4)
                                    {
                                        break;
                                    }
                                    else if (this.postions[k0, v] == 1 || this.postions[k0, v] == 2)
                                    {
                                        int t1 = this.postions[k0, v];
                                        this.postions[k0, v] = 4;
                                        this.postions[i, j] = 0;
                                        state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                        this.postions[k0, v] = t1;
                                        this.postions[i, j] = 4;
                                        f = true;
                                        break;
                                    }
                                }
                                if (f)
                                {
                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta > state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;

                                        this.move = (char)(97 + v) + (8 - h).ToString() + (char)(97 + v) + (8 - k0).ToString();
                                        length_white++;

                                    }
                                    f = false;
                                }
                                int k1 = h + 1;

                                for (; k1 <= 7; k1++)
                                {
                                    if (this.postions[k1, v] == 3 || this.postions[k1, v] == 4)
                                    {
                                        break;
                                    }
                                    else if (this.postions[k1, v] == 1 || this.postions[k1, v] == 2)
                                    {
                                        int t1 = this.postions[k1, v];
                                        this.postions[k1, v] = 4;
                                        this.postions[i, j] = 0;
                                        state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                        this.postions[k1, v] = t1;
                                        this.postions[i, j] = 4;

                                        f = true;
                                        break;
                                    }
                                }

                                if (f)
                                {
                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta > state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;
                                        this.move = (char)(97 + v) + (8 - h).ToString() + (char)(97 + v) + (8 - k1).ToString();
                                        length_white++;
                                    }

                                }
                            }
                            else if (h == 0)
                            {
                                bool f = false;
                                int k0 = h + 1;
                                for (; k0 <= 7; k0++)
                                {
                                    if (this.postions[k0, v] == 3 || this.postions[k0, v] == 4)
                                    {
                                        break;
                                    }
                                    else if (this.postions[k0, v] == 1 || this.postions[k0, v] == 2)
                                    {
                                        int t1 = this.postions[k0, v];
                                        this.postions[k0, v] = 4;
                                        this.postions[i, j] = 0;
                                        state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                        this.postions[k0, v] = t1;
                                        this.postions[i, j] = 4;
                                        f = true;
                                        break;
                                    }
                                }
                                if (f)
                                {
                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta > state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;
                                        this.move = (char)(97 + v) + (8 - h).ToString() + (char)(97 + v) + (8 - k0).ToString();
                                        length_white++;
                                    }
                                    f = false;
                                }


                            }
                            h = i;
                            v = j;
                            if (v != 0)
                            {
                                bool f = false;
                                int k0 = v + 1;
                                for (; k0 <= 7; k0++)
                                {
                                    if (this.postions[h, k0] == 3 || this.postions[h, k0] == 4)
                                    {
                                        break;
                                    }
                                    else if (this.postions[h, k0] == 1 || this.postions[h, k0] == 2)
                                    {
                                        int t1 = this.postions[h, k0];
                                        this.postions[h, k0] = 4;
                                        this.postions[i, j] = 0;
                                        state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                        this.postions[h, k0] = t1;
                                        this.postions[i, j] = 4;
                                        f = true;
                                        break;
                                    }
                                }
                                if (f)
                                {
                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta > state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;


                                        this.move = (char)(97 + v) + (8 - h).ToString() + (char)(97 + k0) + (8 - h).ToString();
                                        length_white++;
                                    }
                                    f = false;
                                }

                                int k1 = v - 1;
                                for (; k1 >= 0; k1--)
                                {
                                    if (this.postions[h, k1] == 3 || this.postions[h, k1] == 4)
                                    {
                                        break;
                                    }
                                    if (this.postions[h, k1] == 1 || this.postions[h, k1] == 2)
                                    {
                                        int t1 = this.postions[h, k1];
                                        this.postions[h, k1] = 2;
                                        this.postions[i, j] = 0;
                                        state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                        this.postions[h, k1] = t1;
                                        this.postions[i, j] = 2;

                                        f = true;
                                        break;
                                    }
                                }

                                if (f)
                                {
                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta > state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;
                                        this.move = (char)(97 + v) + (8 - h).ToString() + (char)(97 + k1) + (8 - h).ToString();
                                        length_white++;


                                    }

                                }
                            }
                            else if (v == 0)
                            {
                                bool f = false;
                                int k0 = v + 1;
                                for (; k0 <= 7; k0++)
                                {
                                    if (this.postions[h, k0] == 3 || this.postions[h, k0] == 4)
                                    {
                                        break;
                                    }
                                    else if (this.postions[h, k0] == 1 || this.postions[h, k0] == 2)
                                    {
                                        int t1 = this.postions[h, k0];
                                        this.postions[h, k0] = 4;
                                        this.postions[i, j] = 0;
                                        state_move_white[length_white] = new CPE480(this.postions, Double.MinValue, this.beta);
                                        this.postions[h, k0] = t1;
                                        this.postions[i, j] = 4;
                                        f = true;
                                        break;
                                    }
                                }
                                if (f)
                                {
                                    state_move_white[length_white].alpha = THE_BEST_MOVE_IN_DEBTH_TWO_White(state_move_white[length_white]);
                                    if (this.beta < state_move_white[length_white].alpha)
                                    {
                                        this.beta = state_move_white[length_white].alpha;
                                        this.move = (char)(97 + v) + (8 - h).ToString() + (char)(97 + k0) + (8 - h).ToString();
                                        length_white++;

                                    }
                                    f = false;
                                }


                            }

                        }









                    }








                }








            }


            return this.move;
        }







        public double move_stone(int[,] postion4, int old_postion, int new_postion)
        {

            int old_i = old_postion / 10;
            int old_j = old_postion % 10;
            int new_i = new_postion / 10;
            int new_j = new_postion % 10;
            postion4[new_i, new_j] = postion4[old_i, old_j];
            postion4[old_i, old_j] = 0;
            if (new_i == 0)
            {
                postion4[new_i, new_j] = 2;

            }
            if (new_i == 7)
            {
                postion4[new_i, new_j] = 4;
            }

            double score = this.evaluate(postion4);

            return score;
        }


        public int evaluate(int[,] postion5)
        {
            //int Pawns_white = 0;
            //int Pawns_black = 0;
            //int Rooks_white = 0;
            //int Rooks_black = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (postion5[i, j] == 4)
                    {

                        this.h = this.h - 50;
                    }
                    else if (postion5[i, j] == 3)
                    {

                        this.h = this.h - 10;
                    }
                    else if (postion5[i, j] == 1)
                    {
                        this.h = this.h + 10;
                    }
                    else if (postion5[i, j] == 2)
                    {
                        this.h = this.h + 50;
                    }
                }
            }


            return this.h;
        }
        public double THE_BEST_MOVE_IN_DEBTH_TWO_Black(CPE480 THE_BEST)
        {
            double score;

            for (int c = 0; c < 8; c++)
            {
                for (int e = 0; e < 8; e++)
                {
                    if (THE_BEST.postions[c, e] == 3)
                    {


                        if (e == 0)
                        {


                            if (THE_BEST.postions[c + 1, e + 1] == 1 || THE_BEST.postions[c + 1, e + 1] == 2)
                            {

                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c + 1) * 10 + (e + 1));
                                THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                if (THE_BEST.alpha >= THE_BEST.beta)
                                {
                                    return THE_BEST.beta;
                                }
                            }

                            if (c == 1)
                            {
                                if (THE_BEST.postions[c + 1, e] == 0)
                                {
                                    score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c + 1) * 10 + (e));
                                    THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                    if (THE_BEST.alpha >= THE_BEST.beta)
                                    {
                                        return THE_BEST.beta;
                                    }
                                    if (THE_BEST.postions[c + 2, e] == 0)
                                    {
                                        score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c + 2) * 10 + (e));
                                        THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                        if (THE_BEST.alpha >= THE_BEST.beta)
                                        {
                                            return THE_BEST.beta;
                                        }
                                    }
                                }


                            }
                        }

                        else if (e == 7)
                        {

                            if (THE_BEST.postions[c + 1, e - 1] == 1 || THE_BEST.postions[c + 1, e - 1] == 2)
                            {
                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c + 1) * 10 + (e - 1));
                                THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                if (THE_BEST.alpha >= THE_BEST.beta)
                                {
                                    return THE_BEST.beta;
                                }

                            }
                            if (c == 1)
                            {

                                if (THE_BEST.postions[c + 1, e] == 0)
                                {
                                    score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c + 1) * 10 + (e));
                                    THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                    if (THE_BEST.alpha >= THE_BEST.beta)
                                    {
                                        return THE_BEST.beta;
                                    }
                                    if (THE_BEST.postions[c + 2, e] == 0)
                                    {
                                        score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c + 2) * 10 + (e));
                                        THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                        if (THE_BEST.alpha >= THE_BEST.beta)
                                        {
                                            return THE_BEST.beta;
                                        }
                                    }

                                }



                            }

                        }
                        else if (c == 1)
                        {
                            if (THE_BEST.postions[c + 1, e + 1] == 1 || THE_BEST.postions[c + 1, e + 1] == 2)
                            {
                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c + 1) * 10 + (e + 1));
                                THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                if (THE_BEST.alpha >= THE_BEST.beta)
                                {
                                    return THE_BEST.beta;
                                }
                            }
                            if (THE_BEST.postions[c + 1, e - 1] == 1 || THE_BEST.postions[c + 1, e - 1] == 2)
                            {
                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c + 1) * 10 + (e - 1));
                                THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                if (THE_BEST.alpha >= THE_BEST.beta)
                                {
                                    return THE_BEST.beta;
                                }
                            }

                            if (THE_BEST.postions[c + 1, e] == 0)
                            {
                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c + 1) * 10 + (e));
                                THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                if (THE_BEST.alpha >= THE_BEST.beta)
                                {
                                    return THE_BEST.beta;
                                }
                                if (THE_BEST.postions[c + 2, e] == 0)
                                {
                                    score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c + 2) * 10 + (e));
                                    THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                    if (THE_BEST.alpha >= THE_BEST.beta)
                                    {
                                        return THE_BEST.beta;
                                    }
                                }
                            }


                        }
                        else
                        {
                            if (THE_BEST.postions[c + 1, e + 1] == 1 || THE_BEST.postions[c + 1, e + 1] == 2)
                            {
                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c + 1) * 10 + (e + 1));
                                THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                if (THE_BEST.alpha >= THE_BEST.beta)
                                {
                                    return THE_BEST.beta;
                                }
                            }
                            if (THE_BEST.postions[c + 1, e - 1] == 1 || THE_BEST.postions[c + 1, e - 1] == 2)
                            {
                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c + 1) * 10 + (e - 1));
                                THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                if (THE_BEST.alpha >= THE_BEST.beta)
                                {
                                    return THE_BEST.beta;
                                }
                            }

                            if (THE_BEST.postions[c + 1, e] == 0)
                            {
                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c + 1) * 10 + (e));
                                THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                if (THE_BEST.alpha >= THE_BEST.beta)
                                {
                                    return THE_BEST.beta;
                                }

                            }


                        }



                    }
                    else if (THE_BEST.postions[c, e] == 4)
                    {

                        int h = c;
                        int v = e;
                        if (h != 0)
                        {

                            int k0 = h - 1;
                            for (; k0 >= 0; k0--)
                            {
                                if (THE_BEST.postions[k0, v] == 3 || THE_BEST.postions[k0, v] == 4)
                                {
                                    break;
                                }
                                else if (THE_BEST.postions[k0, v] == 1 || THE_BEST.postions[k0, v] == 2)
                                {

                                    score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, k0 * 10 + v);
                                    THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                    if (THE_BEST.alpha >= THE_BEST.beta)
                                    {
                                        return THE_BEST.beta;
                                    }

                                    break;
                                }
                            }

                            int k1 = h + 1;
                            for (; k1 <= 7; k1++)
                            {
                                if (this.postions[k1, v] == 3 || this.postions[k1, v] == 4)
                                {
                                    break;
                                }
                                if (this.postions[k1, v] == 1 || this.postions[k1, v] == 2)
                                {

                                    score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, k1 * 10 + v);
                                    THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                    if (THE_BEST.alpha >= THE_BEST.beta)
                                    {
                                        return THE_BEST.beta;
                                    }

                                    break;
                                }
                            }


                        }
                        else if (h == 0)
                        {
                            bool f = false;
                            int k0 = h + 1;
                            for (; k0 <= 7; k0++)
                            {
                                if (this.postions[k0, v] == 3 || this.postions[k0, v] == 4)
                                {
                                    break;
                                }
                                else if (this.postions[k0, v] == 1 || this.postions[k0, v] == 2)
                                {

                                    if (f)
                                    {
                                        score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, k0 * 10 + v);
                                        THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                    }
                                    if (THE_BEST.alpha >= THE_BEST.beta)
                                    {
                                        return THE_BEST.beta;
                                    }

                                    break;
                                }
                            }



                        }

                    }
                }
            }
            return THE_BEST.beta;
        }
        public double THE_BEST_MOVE_IN_DEBTH_TWO_White(CPE480 THE_BEST)
        {
            double score;

            for (int c = 0; c < 8; c++)
            {
                for (int e = 0; e < 8; e++)
                {
                    if (THE_BEST.postions[c, e] == 1)
                    {


                        if (e == 0)
                        {


                            if (THE_BEST.postions[c - 1, e + 1] == 3 || THE_BEST.postions[c - 1, e + 1] == 4)
                            {

                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c - 1) * 10 + (e + 1));
                                THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                if (THE_BEST.beta <= THE_BEST.alpha)
                                {
                                    return THE_BEST.alpha;
                                }
                            }

                            if (c == 6)
                            {
                                if (THE_BEST.postions[c - 1, e] == 0)
                                {
                                    score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c - 1) * 10 + (e));
                                    THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                    if (THE_BEST.beta <= THE_BEST.alpha)
                                    {
                                        return THE_BEST.alpha;
                                    }
                                    if (THE_BEST.postions[c - 2, e] == 0)
                                    {
                                        score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c - 2) * 10 + (e));
                                        THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                        if (THE_BEST.beta <= THE_BEST.alpha)
                                        {
                                            return THE_BEST.alpha;
                                        }
                                    }
                                }


                            }
                        }

                        else if (e == 7)
                        {

                            if (THE_BEST.postions[c - 1, e - 1] == 3 || THE_BEST.postions[c - 1, e - 1] == 4)
                            {
                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c - 1) * 10 + (e - 1));
                                THE_BEST.beta = Math.Min(THE_BEST.beta, score);
                                if (THE_BEST.alpha >= THE_BEST.beta)
                                {
                                    return THE_BEST.beta;
                                }

                            }
                            if (c == 6)
                            {

                                if (THE_BEST.postions[c - 1, e] == 0)
                                {
                                    score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c - 1) * 10 + (e));
                                    THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                    if (THE_BEST.beta <= THE_BEST.alpha)
                                    {
                                        return THE_BEST.alpha;
                                    }
                                    if (THE_BEST.postions[c - 2, e] == 0)
                                    {
                                        score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c - 2) * 10 + (e));
                                        THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                        if (THE_BEST.beta <= THE_BEST.alpha)
                                        {
                                            return THE_BEST.alpha;
                                        }
                                    }

                                }



                            }

                        }
                        else if (c == 6)
                        {
                            if (THE_BEST.postions[c - 1, e + 1] == 3 || THE_BEST.postions[c - 1, e + 1] == 4)
                            {
                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c - 1) * 10 + (e + 1));
                                THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                if (THE_BEST.beta <= THE_BEST.alpha)
                                {
                                    return THE_BEST.alpha;
                                }
                            }
                            if (THE_BEST.postions[c - 1, e - 1] == 3 || THE_BEST.postions[c - 1, e - 1] == 4)
                            {
                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c - 1) * 10 + (e - 1));
                                THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                if (THE_BEST.beta <= THE_BEST.alpha)
                                {
                                    return THE_BEST.alpha;
                                }
                            }

                            if (THE_BEST.postions[c - 1, e] == 0)
                            {
                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c - 1) * 10 + (e));
                                THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                if (THE_BEST.beta <= THE_BEST.alpha)
                                {
                                    return THE_BEST.alpha;
                                }
                                if (THE_BEST.postions[c - 2, e] == 0)
                                {
                                    score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c - 2) * 10 + (e));
                                    THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                    if (THE_BEST.beta <= THE_BEST.alpha)
                                    {
                                        return THE_BEST.alpha;
                                    }
                                }
                            }


                        }
                        else
                        {
                            if (THE_BEST.postions[c - 1, e + 1] == 3 || THE_BEST.postions[c - 1, e + 1] == 4)
                            {
                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c - 1) * 10 + (e + 1));
                                THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                if (THE_BEST.beta <= THE_BEST.alpha)
                                {
                                    return THE_BEST.alpha;
                                }
                            }
                            if (THE_BEST.postions[c - 1, e - 1] == 3 || THE_BEST.postions[c - 1, e - 1] == 4)
                            {
                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c - 1) * 10 + (e - 1));
                                THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                if (THE_BEST.beta <= THE_BEST.alpha)
                                {
                                    return THE_BEST.alpha;
                                }
                            }

                            if (THE_BEST.postions[c - 1, e] == 0)
                            {
                                score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, (c - 1) * 10 + (e));
                                THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                if (THE_BEST.beta <= THE_BEST.alpha)
                                {
                                    return THE_BEST.alpha;
                                }

                            }


                        }



                    }
                    else if (THE_BEST.postions[c, e] == 2)
                    {

                        int h = c;
                        int v = e;
                        if (h != 0)
                        {

                            int k0 = h - 1;
                            for (; k0 >= 0; k0--)
                            {
                                if (THE_BEST.postions[k0, v] == 1 || THE_BEST.postions[k0, v] == 2)
                                {
                                    break;
                                }
                                else if (THE_BEST.postions[k0, v] == 3 || THE_BEST.postions[k0, v] == 4)
                                {

                                    score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, k0 * 10 + v);
                                    THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                    if (THE_BEST.beta <= THE_BEST.alpha)
                                    {
                                        return THE_BEST.alpha;
                                    }

                                    break;
                                }
                            }

                            int k1 = h + 1;
                            for (; k1 <= 7; k1++)
                            {
                                if (this.postions[k1, v] == 1 || this.postions[k1, v] == 2)
                                {
                                    break;
                                }
                                if (this.postions[k1, v] == 3 || this.postions[k1, v] == 4)
                                {

                                    score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, k1 * 10 + v);
                                    THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                    if (THE_BEST.beta <= THE_BEST.alpha)
                                    {
                                        return THE_BEST.alpha;
                                    }

                                    break;
                                }
                            }


                        }
                        else if (h == 0)
                        {
                            bool f = false;
                            int k0 = h + 1;
                            for (; k0 <= 7; k0++)
                            {
                                if (this.postions[k0, v] == 1 || this.postions[k0, v] == 2)
                                {
                                    break;
                                }
                                else if (this.postions[k0, v] == 3 || this.postions[k0, v] == 4)
                                {

                                    if (f)
                                    {
                                        score = THE_BEST.move_stone(THE_BEST.postions, c * 10 + e, k0 * 10 + v);
                                        THE_BEST.alpha = Math.Max(THE_BEST.alpha, score);
                                    }
                                    if (THE_BEST.beta <= THE_BEST.alpha)
                                    {
                                        return THE_BEST.alpha;
                                    }

                                    break;
                                }
                            }



                        }

                    }
                }
            }
            return THE_BEST.alpha;
        }








    }
     class program
     {

         static void Main(string[] args)
         {
             int[,] start_chess = new int[8, 8] {
                                                {4,0,0,0,0,0,0,4},
                                                {3,3,3,3,3,3,3,3},
                                                {0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0},
                                                {0,0,1,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0},
                                                {1,1,0,1,1,1,1,1},
                                                {2,0,0,0,0,0,0,2}};
             string d = CPE480.Project(start_chess);
             Console.WriteLine(d);
             int[,] start_chess4 = new int[8, 8] {
                                                {4,0,0,0,0,0,0,4},
                                                {3,3,3,3,0,3,3,3},
                                                {0,0,0,0,0,0,0,0},
                                                {0,0,0,0,3,0,0,0},
                                                {1,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,1,0,0},
                                                {0,1,1,1,1,0,1,1},
                                                {2,0,0,0,0,0,0,2}};
             string d4 = CPE480.Project(start_chess4);
             Console.WriteLine(d4);
             int[,] start_chess5 = new int[8, 8] {
                                                {4,0,0,0,0,0,0,4},
                                                {3,3,0,3,0,3,3,3},
                                                {0,0,0,0,0,0,0,0},
                                                {1,0,3,0,3,0,0,0},
                                                {0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0},
                                                {0,1,1,1,1,1,1,1},
                                                {2,0,0,0,0,0,0,2}};
             string d5 = CPE480.Project(start_chess5);
             Console.WriteLine(d5);
             int[,] start_chess6 = new int[8, 8] {
                                                {4,0,0,0,0,0,0,4},
                                                {3,3,0,3,0,3,0,3},
                                                {1,0,0,0,0,0,0,0},
                                                {0,0,3,0,3,0,3,0},
                                                {0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0},
                                                {0,1,1,1,1,1,1,1},
                                                {2,0,0,0,0,0,0,2}};
             string d6 = CPE480.Project(start_chess6);
             Console.WriteLine(d6);
             int[,] start_chess1 = new int[8, 8] {
                                                {4,0,0,0,0,0,0,4},
                                                {0,3,3,3,3,3,3,3},
                                                {0,0,0,0,0,0,0,0},
                                                {3,0,0,0,0,0,0,0},
                                                {0,1,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0},
                                                {1,0,1,1,1,1,1,1},
                                                {2,0,0,0,0,0,0,2}};
             string d1 = CPE480.Project(start_chess1);
             Console.WriteLine(d1);

             int[,] start_chess2 = new int[8, 8] {
                                                {0,0,0,0,0,0,0,4},
                                                {1,3,3,3,3,3,3,3},
                                                {0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0},
                                                {0,0,1,1,1,1,1,1},
                                                {4,0,0,0,0,0,0,2}};
             string d2 = CPE480.Project(start_chess2);
             Console.WriteLine(d2);

             int[,] start_chess3 = new int[8, 8] {
                                                {0,0,0,0,0,0,0,0},
                                                {2,0,3,3,3,0,3,3},
                                                {0,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0},
                                                {4,0,0,0,0,0,0,0},
                                                {0,0,0,0,0,0,0,0},
                                                {0,0,0,1,0,1,1,1},
                                                {0,0,0,0,0,0,0,0}};
             string d3 = CPE480.Project(start_chess3);
             Console.WriteLine(d3);
         }

     }



}
