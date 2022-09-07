public static class TicTacToe
{
    static (int x, int y) IndexToXY(int i) => ((i - 1) % 3 * 7, (i - 1) / 3 * 4);

    static void WriteXO(int i, string p)
    {
        var (x, y) = IndexToXY(i);

        Console.SetCursorPosition(x + 2, y + 1);
        Console.Write(p);
    }

    static int Check()
    {
        Console.SetCursorPosition(0, 11);
        Console.Write("                       ");
        Console.SetCursorPosition(0, 11);
        if (m[1] == m[2] && m[2] == m[3] && m[1] != " " || m[1] == m[4] && m[4] == m[7] && m[1] != " ") {
            Console.Write("Победили:" + m[1]);
            return 1;
        }
        else if (m[4] == m[5] && m[5] == m[6] && m[5] != " " || m[2] == m[5] && m[5] == m[8] && m[5] != " " || m[1] == m[5] && m[5] == m[9] && m[5] != " " || m[7] == m[5] && m[5] == m[3] && m[5] != " ") {
            Console.Write("Победили:" + m[5]);
            return 1;
        }
        else if (m[7] == m[8] && m[8] == m[9] && m[9] != " " || m[3] == m[6] && m[6] == m[9] && m[9] != " ") {
            Console.Write("Победили:" + m[9]);
            return 1;
        }
        else if (!m.Contains(" ")) {
            Console.Write("Ничья");
            return 1;
        }
        else {
            return 0;
        }
    }

    static Random r = new Random();
    static string[] m = { "", " ", " ", " ", " ", " ", " ", " ", " ", " " };

    public static void Main()
    {

        Console.SetCursorPosition(0, 0);
        Console.WriteLine(
            @"      |      |      
  1   |  2   |  3   
      |      |      
------+------+------
      |      |      
  4   |  5   |  6   
      |      |      
------+------+------
      |      |      
  7   |  8   |  9   
      |      |      ");

        int i;

    P:
        Console.SetCursorPosition(0, 11);
        Console.Write("Нажмите X или O:");
        string p;
        switch (char.ToUpper(Console.ReadKey().KeyChar)) {
            case 'X':
                p = "X";
                break;
            case 'O' or '0':
                p = "O";
                break;
            default:
                goto P;
        }



        if (p == "O") {
            i = r.Next(1, 9);
            WriteXO(i, "X");
            m[i] = "X";
        }

        while (true) {

            Console.SetCursorPosition(0, 11);
            Console.Write("                       ");
            Console.SetCursorPosition(0, 11);
            Console.Write("Введите сектор 1..9:");

            try {
                i = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
            }
            catch (FormatException) {
                continue;
            }


            if (m[i] != " ")
                continue;

            WriteXO(i, p);
            m[i] = p;

            if (Check() == 1) {
                break;
            }

            while (true) {
                i = r.Next(1, 9);
                if (m[i] == " ") {
                    string c = p == "X" ? (c = "O") : (c = "X");
                    m[i] = c;
                    WriteXO(i, c);
                    break;
                }
            }

            if (Check() == 1) {
                break;
            }
        }
    }
}
