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

string[] m = { "", " ", " ", " ", " ", " ", " ", " ", " ", " " };
int i;
Random r = new Random();

P:
Console.SetCursorPosition(0, 11);
Console.Write("Нажмите X или O:");
string p;
switch (char.ToUpper(Console.ReadKey().KeyChar))
{
    case 'X':
        p = "X";
        break;
    case 'O' or '0':
        p = "O";
        break;
    default:
        goto P;
}

(int x, int y) IndexToXY(int i) => ((i - 1) % 3 * 7, (i - 1) / 3 * 4);

void WriteXO(int i, string p)
{
    var (x, y) = IndexToXY(i);

    Console.SetCursorPosition(x + 2, y + 1);
    Console.Write(p);
}

int Check()
{
    Console.SetCursorPosition(0, 11);
    Console.Write("                       ");
    Console.SetCursorPosition(0, 11);
    if (String.Compare(m[1], m[2]) == 0 && String.Compare(m[2], m[3]) == 0 && m[1] != " " || String.Compare(m[1], m[4]) == 0 && String.Compare(m[4], m[7]) == 0 && m[1] != " ") {
        Console.Write("Победили:" + m[1]);
        return 1;
    }

    else if (String.Compare(m[4], m[5]) == 0 && String.Compare(m[5], m[6]) == 0 && m[5] != " " || String.Compare(m[2], m[5]) == 0 && String.Compare(m[5], m[8]) == 0 && m[5] != " " || String.Compare(m[1], m[5]) == 0 && String.Compare(m[5], m[9]) == 0 && m[5] != " " || String.Compare(m[7], m[5]) == 0 && String.Compare(m[5], m[3]) == 0 && m[5] != " ") {
        Console.Write("Победили:" + m[5]);
        return 1;
    }

    else if (String.Compare(m[7], m[8]) == 0 && String.Compare(m[8], m[9]) == 0 && m[9] != " " || String.Compare(m[3], m[6]) == 0 && String.Compare(m[6], m[9]) == 0 && m[9] != " ") {
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

if (p == "O") {
    i = r.Next(1, 9);
    WriteXO(i, "X");
    m[i] = "X";
}

while (true)
{
    while (true) 
    {
        Console.SetCursorPosition(0, 11);
        Console.Write("                       ");
        Console.SetCursorPosition(0, 11);
        Console.Write("Введите сектор:");
        i = Convert.ToInt32(Console.ReadLine());
        if (m[i] == " ") {
            WriteXO(i, p);
            m[i] = p;
            break;
        }
    }

    if (Check() == 1) {
        break;
    }

    while (true)
    {
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