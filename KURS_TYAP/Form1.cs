using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KURS_TYAP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //
        // Переменные и константы
        string Txt;
        string[] Split;
        int Pos = 0;
        int Pos1 = 0, Pos2 = 0;      
        char[] Lits = new char[26];
        //
        // Структура
        struct Words
        {
            public string Word;
            public string Mean;
            public string Leks;
        };
        Words[] Mas = new Words[8];
        Words[] Mas2 = new Words[11];
        //
        //
        // Разделение на лексемы
        public void Analiz(string[] Split)
        {
            DGVleks.RowCount = 1;
            Pos = Pos1 = Pos2 = 0;
            bool k = false;
            for (int i = 0; i < Split.Length; i++)
            {
                while (k != true)
                {
                    k = KA1(Split[i], Mas);
                    if (k) break;
                    k = KA1(Split[i], Mas2);
                    if (k) break;
                    k = KA2(Split[i]);
                }
                k = false;
            }
        }
        //
        // Сравнение с зарезервированными словами
        bool KA1(string Str, Words[] Mas)
        {
            for (int i = 0; i < Mas.Length; i++)
            {
                if (Str == Mas[i].Word)
                {
                    AddRow(Mas[i].Word, Mas[i].Mean, Mas[i].Leks);
                    return true;
                }
            }
            return false;
        }
        //
        // Строка без пробелов - определение лексем
        bool KA2(string Str)
        {
            string Str2 = "";
            int VAR = 1;
            for (int i = 0; i < Str.Length; i++)
            {
                char p = Str[i];
                bool ans = (p >= 'a' && p <= 'z') || (p >= '0' && p <= '9');
                if (VAR == 1)
                {
                    if (ans) Str2 += p;
                    else
                    {
                        if (!(KA1(Str2, Mas) || KA1(Str2, Mas2))) KA3(Str2);
                        Str2 = p.ToString();
                        VAR = 2;
                    }
                    if (i + 1 < Str.Length && Str2[0] >= '0' && Str2[0] <= '9' && Str[i + 1] >= 'a' && Str[i + 1] <= 'z')
                    {
                        KA3(Str2);
                        Str2 = "";
                    }
                    if (i + 1 < Str.Length && Str[i + 1] >= '0' && Str[i + 1] <= '9' && Str2[0] >= 'a' && Str2[0] <= 'z')
                    {
                        if (KA1(Str2, Mas2)) Str2 = "";
                    }
                }
                else
                {
                    if (!ans && p=='=') Str2 += p;
                    else
                    {
                        KA1(Str2, Mas2);
                        Str2 = p.ToString();
                        VAR = 1;
                        if (i + 1 < Str.Length && (Str2[0] == '(' || Str2[0] == '+' || Str2[0] == '-' || Str2[0] == '*' || Str2[0] == '/'))
                        {
                            VAR = 2;                            
                        }
                    }
                }
            }
            if (!KA1(Str2, Mas2)) KA3(Str2);
            return true;
        }
        //
        // Конечный автомат: идентификатор или число
        void KA3(string Str)
        {
            int k = 0;
            for (int i = 0; i < Str.Length; i++)
            {
                if (Str[i] >= '0' && Str[i] <= '9') k++;
            }
            if (k == Str.Length) AddRow(Str, "Цифровое значение", "n");
            else AddRow(Str, "Идентификатор", "x");

        }
        //
        // Добавить строку в таблицу
        void AddRow(string one, string two, string thr)
        {
            DGVleks.RowCount++;
            Pos2 = Pos1 + one.Length;
            DGVleks[0, Pos].Value = one;
            DGVleks[1, Pos].Value = thr;
            DGVleks[2, Pos].Value = two;
            DGVleks[3, Pos].Value = Pos1.ToString() + "-" + Pos2.ToString();
            Txt += thr;
            Pos1 = Pos2;
            Pos++;
        }          
        //
        // СТРУКТУРА ДЛЯ РАЗБОРА
        struct MP
        {
            public string one;
            public string two;
            public string thr;
        };
        MP Prim = new MP();
        //
        // ЗАГРУЗКА ФОРМЫ
        private void Form1_Load(object sender, EventArgs e)
        {
            DGVleks.ColumnCount = 4;
            DGVleks.Columns[0].Width = 75;
            DGVleks.Columns[1].Width = 90;
            DGVleks.Columns[2].Width = 185;
            DGVleks.Columns[3].Width = 55;
            DGVleks.Columns[0].Name = "Значение";
            DGVleks.Columns[1].Name = "Представление";
            DGVleks.Columns[2].Name = "Тип лексемы";
            DGVleks.Columns[3].Name = "Позиция";
            //
            Mas[0].Word = "begin";
            Mas[0].Mean = "Зарезервированное слово";
            Mas[0].Leks = "b";
            //
            Mas[1].Word = "end.";
            Mas[1].Mean = "Зарезервированное слово";
            Mas[1].Leks = "k";
            //
            Mas[2].Word = "if";
            Mas[2].Mean = "Зарезервированное слово";
            Mas[2].Leks = "i";
            //
            Mas[3].Word = "then";
            Mas[3].Mean = "Зарезервированное слово";
            Mas[3].Leks = "t";
            //
            Mas[4].Word = "else";
            Mas[4].Mean = "Зарезервированное слово";
            Mas[4].Leks = "e";
            //
            Mas[5].Word = "and";
            Mas[5].Mean = "Зарезервированное слово";
            Mas[5].Leks = "a";
            //
            Mas[6].Word = "or";
            Mas[6].Mean = "Зарезервированное слово";
            Mas[6].Leks = "o";
            //
            Mas[7].Word = "end;";
            Mas[7].Mean = "Зарезервированное слово";
            Mas[7].Leks = "d";
            //
            Mas2[0].Word = ":=";
            Mas2[0].Mean = "Знак присваивания";
            Mas2[0].Leks = "p";
            //
            Mas2[1].Word = "/";
            Mas2[1].Mean = "Деление";
            Mas2[1].Leks = "/";
            //
            Mas2[2].Word = "+";
            Mas2[2].Mean = "Знак сложения";
            Mas2[2].Leks = "+";
            //
            Mas2[3].Word = "-";
            Mas2[3].Mean = "Знак вычитания";
            Mas2[3].Leks = "-";
            //
            Mas2[4].Word = ";";
            Mas2[4].Mean = "Точка с запятой";
            Mas2[4].Leks = ";";
            //
            Mas2[5].Word = "<";
            Mas2[5].Mean = "Знак меньше";
            Mas2[5].Leks = "<";
            //
            Mas2[6].Word = ">";
            Mas2[6].Mean = "Знак больше";
            Mas2[6].Leks = ">";
            //
            Mas2[7].Word = "=";
            Mas2[7].Mean = "Сравнение на равенство";
            Mas2[7].Leks = "=";
            //
            Mas2[8].Word = "*";
            Mas2[8].Mean = "Умножение";
            Mas2[8].Leks = "*";
            //
            Mas2[9].Word = "(";
            Mas2[9].Mean = "Скобка открывающаяся";
            Mas2[9].Leks = "(";
            //
            Mas2[10].Word = ")";
            Mas2[10].Mean = "Скобка закрывающаяся";
            Mas2[10].Leks = ")";
            //
            int j = 0;
            for (char i = 'a'; i < 'z'; i++)
            {
                Lits[j] = i;
                j++;
            }
            //
            DGVpr.RowCount = 22;
            DGVpr.ColumnCount = 22;
            for (int i=0; i<22; i++)
                DGVpr.Columns[i].Width = 25;
            //
            DGVpr.Columns[0].Name = "b";
            DGVpr.Columns[1].Name = "d";
            DGVpr.Columns[2].Name = "i";
            DGVpr.Columns[3].Name = "t";
            DGVpr.Columns[4].Name = "e";
            DGVpr.Columns[5].Name = "x";
            DGVpr.Columns[6].Name = "n";
            DGVpr.Columns[7].Name = "a";
            DGVpr.Columns[8].Name = "o";
            DGVpr.Columns[9].Name = "p";
            DGVpr.Columns[10].Name = "k";
            DGVpr.Columns[11].Name = ";";
            DGVpr.Columns[12].Name = "+";
            DGVpr.Columns[13].Name = "-";
            DGVpr.Columns[14].Name = "*";
            DGVpr.Columns[15].Name = "/";
            DGVpr.Columns[16].Name = "(";
            DGVpr.Columns[17].Name = ")";
            DGVpr.Columns[18].Name = "<";
            DGVpr.Columns[19].Name = ">";
            DGVpr.Columns[20].Name = "=";            
            DGVpr.Columns[21].Name = "$";
            //
            DGVpr.Rows[0].HeaderCell.Value = "b";
            DGVpr.Rows[1].HeaderCell.Value = "d";
            DGVpr.Rows[2].HeaderCell.Value = "i";
            DGVpr.Rows[3].HeaderCell.Value = "t";
            DGVpr.Rows[4].HeaderCell.Value = "e";
            DGVpr.Rows[5].HeaderCell.Value = "x";
            DGVpr.Rows[6].HeaderCell.Value = "n";
            DGVpr.Rows[7].HeaderCell.Value = "a";
            DGVpr.Rows[8].HeaderCell.Value = "o";
            DGVpr.Rows[9].HeaderCell.Value = "p";
            DGVpr.Rows[10].HeaderCell.Value = "k";
            DGVpr.Rows[11].HeaderCell.Value = ";";
            DGVpr.Rows[12].HeaderCell.Value = "+";
            DGVpr.Rows[13].HeaderCell.Value = "-";
            DGVpr.Rows[14].HeaderCell.Value = "*";
            DGVpr.Rows[15].HeaderCell.Value = "/";
            DGVpr.Rows[16].HeaderCell.Value = "(";
            DGVpr.Rows[17].HeaderCell.Value = ")";
            DGVpr.Rows[18].HeaderCell.Value = "<";
            DGVpr.Rows[19].HeaderCell.Value = ">";
            DGVpr.Rows[20].HeaderCell.Value = "=";            
            DGVpr.Rows[21].HeaderCell.Value = "$";        
            //            
            DGVpr[0, 0].Value = "<";
            DGVpr[0, 3].Value = "<";
            DGVpr[0, 4].Value = "<";
            DGVpr[0, 11].Value = ">";
            DGVpr[0, 21].Value = "<";
            DGVpr[1, 0].Value = "=";
            DGVpr[1, 1].Value = ">";
            DGVpr[1, 3].Value = ">";
            DGVpr[1, 4].Value = ">";
            DGVpr[1, 10].Value = ">";
            DGVpr[1, 11].Value = ">";
            DGVpr[1, 21].Value = "<";           
            DGVpr[2, 0].Value = "<";
            DGVpr[2, 11].Value = ">";
            DGVpr[2, 21].Value = "<";
            DGVpr[3, 2].Value = "=";
            DGVpr[3, 5].Value = DGVpr[3, 6].Value = DGVpr[3, 7].Value = DGVpr[3, 8].Value = ">";
            DGVpr[3, 12].Value = DGVpr[3, 13].Value = DGVpr[3, 14].Value = DGVpr[3, 15].Value = ">";
            DGVpr[3, 17].Value = ">";
            DGVpr[4, 0].Value = "<";
            DGVpr[4, 1].Value = ">";
            DGVpr[4, 3].Value = "=";
            DGVpr[4, 11].Value = ">";
            DGVpr[5, 0].Value = "<";
            DGVpr[5, 1].Value = ">";
            DGVpr[5, 2].Value = DGVpr[6, 2].Value = "<";
            DGVpr[5, 3].Value = "<";
            DGVpr[5, 4].Value = "<";
            DGVpr[5, 5].Value = DGVpr[6, 5].Value = "<";
            DGVpr[5, 6].Value = DGVpr[6, 6].Value = "<";
            DGVpr[5, 7].Value = DGVpr[6, 7].Value = "<";
            DGVpr[5, 8].Value = DGVpr[6, 8].Value = "<";
            DGVpr[5, 9].Value = DGVpr[6, 9].Value = "<";
            DGVpr[5, 11].Value = DGVpr[6, 11].Value = ">";
            DGVpr[5, 12].Value = DGVpr[6, 12].Value = "<";
            DGVpr[5, 13].Value = DGVpr[6, 13].Value = "<";
            DGVpr[5, 14].Value = DGVpr[6, 14].Value = "<";
            DGVpr[5, 15].Value = DGVpr[6, 15].Value = "<";
            DGVpr[5, 16].Value = DGVpr[6, 16].Value = "<";
            DGVpr[5, 18].Value = DGVpr[6, 18].Value = ">";
            DGVpr[5, 19].Value = DGVpr[6, 19].Value = ">";
            DGVpr[5, 20].Value = DGVpr[6, 20].Value = ">";  
            DGVpr[5, 21].Value = DGVpr[6, 21].Value = "<";           
            DGVpr[7, 2].Value = DGVpr[8, 2].Value = "<";
            DGVpr[7, 5].Value = DGVpr[8, 5].Value = ">";
            DGVpr[7, 6].Value = DGVpr[8, 6].Value = ">";
            DGVpr[7, 7].Value = DGVpr[8, 7].Value = "<";
            DGVpr[7, 8].Value = DGVpr[8, 8].Value = "<";
            DGVpr[7, 21].Value = DGVpr[8, 21].Value = "<";   
            DGVpr[9, 5].Value = "=";
            DGVpr[9, 11].Value = ">";
            DGVpr[10, 1].Value = ">";
            DGVpr[10, 3].Value = DGVpr[10, 4].Value = ">";
            DGVpr[10, 11].Value = ">";
            DGVpr[10, 21].Value = "<";
            DGVpr[11, 0].Value = DGVpr[11, 1].Value = DGVpr[11, 2].Value = "<";
            DGVpr[11, 3].Value = "=";
            DGVpr[11, 4].Value = "<"; 
            DGVpr[11, 5].Value = DGVpr[11, 6].Value = ">";
            DGVpr[11, 12].Value = DGVpr[11, 13].Value = DGVpr[11, 14].Value = DGVpr[11, 15].Value = "<";
            DGVpr[11, 17].Value = ">";
            DGVpr[11, 21].Value = "<";
            DGVpr[12, 0].Value = DGVpr[13, 0].Value = DGVpr[14, 0].Value = DGVpr[15, 0].Value = "<";
            DGVpr[12, 2].Value = DGVpr[13, 2].Value = DGVpr[14, 2].Value = DGVpr[15, 2].Value = "<";
            DGVpr[12, 4].Value = DGVpr[13, 4].Value = DGVpr[14, 4].Value = DGVpr[15, 4].Value = "<";
            DGVpr[12, 5].Value = DGVpr[13, 5].Value = DGVpr[14, 5].Value = DGVpr[15, 5].Value = ">";
            DGVpr[12, 6].Value = DGVpr[13, 6].Value = DGVpr[14, 6].Value = DGVpr[15, 6].Value = ">";
            DGVpr[12, 9].Value = DGVpr[13, 9].Value = DGVpr[14, 9].Value = DGVpr[15, 9].Value = "<";
            DGVpr[12, 11].Value = DGVpr[13, 11].Value = DGVpr[14, 11].Value = DGVpr[15, 11].Value = ">";
            DGVpr[12, 12].Value = DGVpr[12, 13].Value = DGVpr[13, 12].Value = DGVpr[13, 13].Value = ">";
            DGVpr[14, 12].Value = DGVpr[15, 12].Value = DGVpr[14, 13].Value = DGVpr[15, 13].Value = "<";
            DGVpr[12, 14].Value = DGVpr[13, 14].Value = DGVpr[14, 14].Value = DGVpr[15, 14].Value = ">";
            DGVpr[12, 15].Value = DGVpr[13, 15].Value = DGVpr[14, 15].Value = DGVpr[15, 15].Value = ">";
            DGVpr[12, 16].Value = DGVpr[13, 16].Value = DGVpr[14, 16].Value = DGVpr[15, 16].Value = "<";
            DGVpr[12, 17].Value = DGVpr[13, 17].Value = DGVpr[14, 17].Value = DGVpr[15, 17].Value = ">";
            DGVpr[12, 21].Value = DGVpr[13, 21].Value = DGVpr[14, 21].Value = DGVpr[15, 21].Value = "<";
            DGVpr[14, 20].Value = "<";
            DGVpr[16, 5].Value = DGVpr[16, 6].Value = "<";
            DGVpr[16, 9].Value = "<";
            DGVpr[16, 12].Value = DGVpr[16, 13].Value = DGVpr[16, 14].Value = DGVpr[16, 15].Value = DGVpr[16, 16].Value = "<";
            DGVpr[16, 20].Value = "<";
            DGVpr[16, 21].Value = "<";
            DGVpr[17, 5].Value = DGVpr[17, 6].Value = ">";
            DGVpr[17, 11].Value = DGVpr[17, 12].Value = DGVpr[17, 13].Value = DGVpr[17, 14].Value = DGVpr[17, 15].Value = ">";
            DGVpr[17, 16].Value = "=";
            DGVpr[17, 17].Value = ">";
            DGVpr[18, 5].Value = DGVpr[19, 5].Value = DGVpr[20, 5].Value = "<";
            DGVpr[18, 6].Value = DGVpr[19, 6].Value = DGVpr[20, 6].Value = "<";
            DGVpr[18, 21].Value = DGVpr[19, 21].Value = DGVpr[20, 21].Value = "<";
            DGVpr[21, 0].Value = "<";
            DGVpr[21, 4].Value = "<";
            DGVpr[21, 5].Value = DGVpr[21, 6].Value = ">";
            DGVpr[21, 10].Value = ">";
            DGVpr[21, 12].Value = DGVpr[21, 13].Value = DGVpr[21, 14].Value = DGVpr[21, 15].Value = ">";
            
        }
        //
        // ПРАВЫЙ АНАЛИЗАТОР
        private void Bpr_Click(object sender, EventArgs e)        {
            
            Prim.one = "$";
            Prim.two = Txt + "$";
            Prim.thr = "";
            int Res = -1;            
            int I = 0, J = 0;
            bool K = false;
            LBpr.Items.Clear();
            while (Res == -1)
            {
                LBpr.Items.Add("[" + Prim.one + "," + Prim.two + "," + Prim.thr + "] |-"); 
                if (Prim.one == "$A" && Prim.two == "$") { Res = 1; break; }
                if (Prim.two == "") { Res = 0; break; }                               
                I = SearchI(Prim.two[0].ToString());
                J = SearchJ(Prim.one[Prim.one.Length - 1].ToString());            
                //   
                if (Prim.one[Prim.one.Length - 1] != 'A')
                {
                    if (DGVpr[I, J].Value != null)
                    {
                        if (DGVpr[I, J].Value.ToString() == "<" || DGVpr[I, J].Value.ToString() == "=")
                        {
                            Perenos(ref Prim.one, ref Prim.two);
                        }
                        else
                        {
                            K = Svertka(ref Prim);
                            if (K == false) Res = 0;
                        }                        
                    }
                    else
                    {
                        Res = 0;
                        LBpr.Items.Add("ошибка");
                    }
                }
                else
                {
                    if (!Svertka(ref Prim))                    
                        Perenos(ref Prim.one, ref Prim.two);
                }
            }
            if (Res==1)
                LBpr.Items.Add("допуск");
            else
                LBpr.Items.Add("ошибка");
        }             
        //
        //
        void Perenos(ref string Str1, ref string Str2)
        {
            Str1 += Str2[0];
            string str = "";
            for (int i = 1; i < Str2.Length; i++)
            {
                str += Str2[i];
            }
            Str2 = str;
        }
        //
        //
        bool Svertka(ref MP Prim)
        {
            string str = Prim.one;
            if (P1(Prim.one, 3) == "bAk" && DGVpr[SearchI("b"), SearchJ(P2(Prim.one, 3))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 1, 3);
            if (P1(Prim.one, 3) == "bAd" && DGVpr[SearchI("b"), SearchJ(P2(Prim.one, 3))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 3, 3);
            if (P1(Prim.one, 2) == "A;" && DGVpr[SearchI(";"), SearchJ(P2(Prim.one, 2))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 6, 2);
            if (P1(Prim.one, 4) == "iAtA" && DGVpr[SearchI("i"), SearchJ(P2(Prim.one, 4))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 4, 4);
            if (P1(Prim.one, 3) == "AeA" && DGVpr[SearchI("e"), SearchJ(P2(Prim.one, 3))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 5, 3);
            if (P1(Prim.one, 2) == "AA" && DGVpr[SearchI("$"), SearchJ(P2(Prim.one, 2))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 8, 2);
            if (P1(Prim.one, 3) == "AaA" && DGVpr[SearchI("a"), SearchJ(P2(Prim.one, 3))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 10, 3);
            if (P1(Prim.one, 3) == "AoA" && DGVpr[SearchI("o"), SearchJ(P2(Prim.one, 3))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 11, 3);
            if (P1(Prim.one, 3) == "xAA" && DGVpr[SearchI("x"), SearchJ(P2(Prim.one, 3))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 12, 3);
            if (P1(Prim.one, 3) == "nAA" && DGVpr[SearchI("n"), SearchJ(P2(Prim.one, 4))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 13, 4);
            if (P1(Prim.one, 3) == "xpA" && DGVpr[SearchI("x"), SearchJ(P2(Prim.one, 3))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 14, 3);
            if (P1(Prim.one, 3) == "A+A" && DGVpr[SearchI("+"), SearchJ(P2(Prim.one, 3))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 15, 3);
            if (P1(Prim.one, 3) == "A-A" && DGVpr[SearchI("-"), SearchJ(P2(Prim.one, 3))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 16, 3);
            if (P1(Prim.one, 3) == "A*A" && DGVpr[SearchI("*"), SearchJ(P2(Prim.one, 3))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 18, 3);
            if (P1(Prim.one, 3) == "A/A" && DGVpr[SearchI("/"), SearchJ(P2(Prim.one, 3))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 19, 3);
            if (P1(Prim.one, 3) == "(A)" && DGVpr[SearchI("("), SearchJ(P2(Prim.one, 3))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 21, 3);
            if (P1(Prim.one, 1) == "x" && DGVpr[SearchI("x"), SearchJ(P2(Prim.one, 1))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 22, 1);
            if (P1(Prim.one, 1) == "n" && DGVpr[SearchI("n"), SearchJ(P2(Prim.one, 1))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 23, 1);
            if (P1(Prim.one, 1) == "<" && DGVpr[SearchI("<"), SearchJ(P2(Prim.one, 1))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 24, 1);
            if (P1(Prim.one, 1) == ">" && DGVpr[SearchI(">"), SearchJ(P2(Prim.one, 1))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 25, 1);
            if (P1(Prim.one, 1) == "=" && DGVpr[SearchI("="), SearchJ(P2(Prim.one, 1))].Value.ToString() == "<") GetRes(ref Prim.one, ref Prim.thr, 26, 1);
            if (str == Prim.one) return false;
            else return true;
        }
        //
        //
        void GetRes(ref string str1, ref string str2, int k, int n)
        {
            string str = "";
            for (int i = 0; i < str1.Length - n; i++) str += str1[i];
            str1 = str;
            str1 += "A";
            str2 += k.ToString() + "|";
        }   
        //
        //
        string P1(string Str, int k)
        {
            string str1="";
            if (Str.Length >=k+1)
            {
                 for (int i=Str.Length-k; i<Str.Length; i++)
                 {
                      str1+=Str[i];
                 }                          
            }
            return str1;
        }          
        //
        //
        string P2(string Str, int k)
        {
            string str1="A";
            int i = 1;
            while (str1 == "A")
            {
                if (Str.Length >=k+i)
                {
                    str1 = Str[Str.Length-k-i].ToString();                   
                }
                i++;   
            }  
            return str1;
        }
        //
        //
        int SearchI(string str1)
        {
            int I = 0;
            for (int i = 0; i < 22; i++)
            {
                if (DGVpr.Columns[i].Name == str1)
                {
                    I = i;
                    break;
                }
            }
            return I;
        }
        //
        //
        int SearchJ(string str1)
        {
            int J = 0,j=0;
            string str2 = "";
            foreach (DataGridViewRow row in DGVpr.Rows)
            {
                str2 = row.HeaderCell.Value.ToString();
                if (str2 == str1)
                {
                    J = j;
                    break;
                }
                j++;
            }
            return J;
        }
        //
        // Лексический анализ
        private void Bleks_Click(object sender, EventArgs e)
        {
            Txt = RTBtext.Text;
            Split = Txt.Split(new Char[] { ' ', '\n', '\t' });
            Txt = "";
            Analiz(Split);
        }
        

    }
}
