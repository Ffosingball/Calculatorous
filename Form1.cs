using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculatorous
{
    public partial class Form1 : Form
    {
        Boolean dot=false;

        int num_counting = 0, sym_counting = -1, power=0, dig_counting=0;
        double num1 = 0.0, ans=0;

        List<double> nums = new List<double>();
        List<string> symbols = new List<string>();

        public Form1()
        {
            InitializeComponent();

            nums.Add(num1);
        }

        void add_num(int digit) 
        {
            if (dig_counting < 15)
            {
                if (dot)
                {
                    power++;
                    num1 = num1 + (digit / Math.Pow(10, power));
                }
                else
                    num1 = num1 * 10 + digit;

                nums.RemoveAt(num_counting);
                nums.Insert(num_counting, num1);
                dig_counting++;

                calculate();
            }
            else 
            {
                warning.Text = "Число может иметь не более 15 цифр!";
            }
        }

        void calculate() 
        {
            List<double> sums = new List<double>();

            /**/
            //string h="";
            /**/

            for (int i = 0; i < symbols.Count; i++)
            {
                sums.Add(0);
            }

            if (nums.Count==1)
            {
                ans = num1;
            }
            else if (nums.Count==2)
            {
                switch (symbols[0])
                {
                    case "+":
                        ans =nums[0]+nums[1];
                        break;
                    case "-":
                        ans = nums[0] - nums[1];
                        break;
                    case "*":
                        ans = nums[0] * nums[1];
                        break;
                    case "/":
                        ans = nums[0] / nums[1];
                        break;
                }
            }
            else
            {
                for (int i = 0; i < symbols.Count; i++)
                {
                    if (i == 0)
                    {
                        if (symbols[i] == "*" || symbols[i] == "/")
                        {
                            switch (symbols[i])
                            {
                                case "*":
                                    sums[i] = nums[i] * nums[i + 1];
                                    break;
                                case "/":
                                    sums[i] = nums[i] / nums[i + 1];
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if ((symbols[i] == "*" || symbols[i] == "/")&& (symbols[i-1] == "*" || symbols[i-1] == "/"))
                        {
                            switch (symbols[i])
                            {
                                case "*":
                                    sums[i] = sums[i-1] * nums[i + 1];
                                    sums[i - 1] = 0;
                                    break;
                                case "/":
                                    sums[i] = sums[i-1] / nums[i + 1];
                                    sums[i - 1] = 0;
                                    break;
                            }
                        }
                        else if ((symbols[i] == "*" || symbols[i] == "/") && (symbols[i-1] == "+" || symbols[i-1] == "-"))
                        {
                            switch (symbols[i])
                            {
                                case "*":
                                    /*------*/
                                    sums[i] = nums[i] * nums[i + 1];
                                    break;
                                case "/":
                                    sums[i] = nums[i] / nums[i + 1];
                                    break;
                            }
                        }
                    }
                }

                int k = 0,l=0;

                if (symbols[k] == "+" || symbols[k] == "-")
                {
                    ans = nums[0];
                }
                else
                {
                    while (sums[k] == 0)
                    {
                        k++;
                    }

                    ans = sums[k];
                }

                while (k<symbols.Count)
                {
                    if (k!=symbols.Count-1) 
                    {
                        if ((symbols[k] == "+" || symbols[k] == "-") && (symbols[k + 1] == "*" || symbols[k + 1] == "/"))
                        {
                            l = k;

                            while (sums[k] == 0)
                            {
                                k++;
                            }

                            switch (symbols[l])
                            {
                                case "+":
                                    ans += sums[k];
                                    break;
                                case "-":
                                    ans -= sums[k];
                                    break;
                            }
                        }
                        else
                        {
                            switch (symbols[k])
                            {
                                case "+":
                                    ans += nums[k + 1];
                                    break;
                                case "-":
                                    ans -= nums[k + 1];
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (symbols[k] == "+" || symbols[k] == "-")
                        {
                            switch (symbols[k])
                            {
                                case "+":
                                    ans += nums[k + 1];
                                    break;
                                case "-":
                                    ans -= nums[k + 1];
                                    break;
                            }
                        }
                    }

                    k++;
                }
            }

            out_put();
        }

        void out_put()
        {
            string line="";

            if (nums.Count==symbols.Count)
            { 
                for (int i = 0; i < nums.Count; i++)
                {
                    line = line + nums[i].ToString() + symbols[i];
                }
            }
            else
            {
                for (int i = 0; i < symbols.Count; i++)
                {
                    line = line + nums[i].ToString() + symbols[i];
                }

                line = line + nums[nums.Count - 1].ToString("N" + power);
            }

            line_counting.Text = line;

            answer.Text = "" + ans;
        }

        void action_(string d) 
        {
            num1 = 0.0;

            num_counting++;
            sym_counting++;
            power = 0;
            dot = false;
            dig_counting = 0;

            symbols.Add(d);

            out_put();

            nums.Add(num1);

            warning.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_num(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            add_num(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            add_num(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            add_num(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            add_num(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            add_num(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            add_num(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            add_num(9);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            add_num(0);
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            action_("-");
        }

        private void button_multiply_Click(object sender, EventArgs e)
        {
            action_("*");
        }

        private void button_divide_Click(object sender, EventArgs e)
        {
            action_("/");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            nums.Clear();
            symbols.Clear();
            nums.Add(ans);

            line_counting.Text = ""+ans;
            answer.Text = "";
            warning.Text = "";

            num_counting = 0;
            sym_counting = -1;
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            string num = nums[num_counting].ToString();
            string new_num;

            if (dig_counting > 0)
            {
                if (dot)
                {
                    if (power == 0)
                    {
                        dot = false;
                    }
                    else
                    {
                        int power_check=0, dig_counting_check;

                        if (!Double.IsNaN(num1) && Math.Floor(num1) == num1)
                        {
                            //dig_counting_check = num.Length;
                        }
                        else
                        {
                            int pos_dot = num.IndexOf(',');
                            power_check = num.Length - pos_dot - 1;
                        }

                        if (power!=power_check) 
                        {
                            power--;
                        }
                        else
                        {
                            new_num = num.Substring(0, num.Length - 1);

                            num1 = Convert.ToDouble(new_num);   /*357 хз*/

                            nums.RemoveAt(num_counting);
                            nums.Insert(num_counting, num1);

                            power--;
                        }
                    }
                }
                else
                {
                    if (dig_counting!=1) {
                        new_num = num.Substring(0, num.Length - 1);
                        num1 = Convert.ToDouble(new_num);   /*357 хз*/

                        nums.RemoveAt(num_counting);
                        nums.Insert(num_counting, num1);
                    }
                    else
                    {
                        nums.RemoveAt(num_counting);

                        num1 = 0.0;
                        power = 0;

                        out_put();

                        nums.Add(num1);
                    }
                }

                if (dot && power == 0)
                {
                    dig_counting--;
                    dig_counting++;
                }
                else
                    dig_counting--;


                if (dig_counting!=0)
                {
                    if (dot && power==0)
                    {
                        calculate();

                        string line = "";

                        if (nums.Count == symbols.Count)
                        {
                            for (int i = 0; i < nums.Count; i++)
                            {
                                line = line + nums[i].ToString() + symbols[i];
                            }
                        }
                        else
                        {
                            line = nums[0].ToString();

                            for (int i = 0; i < symbols.Count; i++)
                            {
                                line = line + symbols[i] + nums[i + 1].ToString();
                            }
                        }

                        line_counting.Text = line + ",";
                    }
                    else
                    {
                        calculate();
                    }
                }
                else
                {
                    if (num_counting!=0)
                    {
                        string s = symbols[sym_counting];
                        nums.RemoveAt(num_counting);
                        symbols.RemoveAt(sym_counting);

                        num_counting--;
                        sym_counting--;

                        calculate();

                        num_counting++;
                        sym_counting++;

                        symbols.Add(s);

                        out_put();

                        nums.Add(0.0);
                    }
                    else
                    {
                        dot = false;
                        num_counting = 0;
                        dig_counting = 0;
                        sym_counting = -1;
                        power = 0;
                        num1 = 0.0;

                        nums.Clear();
                        symbols.Clear();
                        nums.Add(num1);

                        line_counting.Text = "0";
                        answer.Text = "";
                        warning.Text = "";
                    }
                }

            }
            else 
            {
                if (sym_counting != -1)
                {
                    string l;

                    nums.RemoveAt(num_counting);
                    symbols.RemoveAt(sym_counting);

                    num_counting--;
                    sym_counting--;

                    num1 = nums[num_counting];

                    l = num1.ToString();

                    if (!Double.IsNaN(num1) && Math.Floor(num1) == num1)
                    {
                        dig_counting = l.Length;
                        dot = false;
                    }
                    else
                    {
                        dot = true;
                        dig_counting = l.Length - 1;

                        int pos_dot = l.IndexOf(',');
                        power = l.Length - pos_dot - 1;
                    }

                    out_put();
                }
            }
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            action_("+");
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            dot = false;
            num_counting = 0;
            dig_counting = 0;
            sym_counting = -1;
            power = 0;
            num1 = 0.0;

            nums.Clear();
            symbols.Clear();
            nums.Add(num1);

            line_counting.Text = "0";
            answer.Text = "";
            warning.Text = "";
        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            dot = true;

            string line = "";

            if (nums.Count == symbols.Count)
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    line = line + nums[i].ToString() + symbols[i];
                }
            }
            else
            {
                line = nums[0].ToString();

                for (int i = 0; i < symbols.Count; i++)
                {
                    line = line + symbols[i] + nums[i + 1].ToString();
                }
            }

            line_counting.Text = line+",";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_num(1);
        }
    }
}
