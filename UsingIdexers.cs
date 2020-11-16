using System;
class MyClass
{
    private int code;
    public MyClass(char s)
    {
        code = s;
    }
    public char this[int i]
    {
        get
        {
            return (char)(code + i);
        }
        set
        {
            code = value - i;
        }
    }
}
class MyClass1
{
    private int number;
    public MyClass1(int n)
    {
        number = n;
    }
    public int this[int k]
    {
        get
        {
            int n = number;
            for (int i = 1; i < k; i++)
                n /= 10;
            return n % 10;
        }
    }
}
class MyString
{
    private string text;
    public MyString(string t)
    {
        text = t;
    }
    public static implicit operator MyString(string t)
    {
        return new MyString(t);
    }
    public override string ToString()
    {
        return text;
    }
    public char this[int k]
    {
        set
        {
            if (k < 0 || k >= text.Length)
                return;
            string t = "";
            for (int i = 0; i < k; i++)
                t += text[i];
            t += value;
            for (int i = k + 1; i < text.Length; i++)
                t += text[i];
            text = t;
        }
    }
}
class MyClass2
{
    public int code;
    public MyClass2(int n)
    {
        code = n;
    }
    public int this[MyClass2 obj]
    {
        get
        {
            return code - obj.code;
        }
        set
        {
            code = obj.code + value;
        }
    }
}
class Programm
{
    static void Main()
    {
        MyClass obj = new MyClass('A');
        for (int i = 0; i < 10; i++)
            Console.Write(obj[i] + " ");
        Console.WriteLine();
        obj[5] = 'Q';
        for (int i = 0; i < 10; i++)
            Console.Write(obj[i] + " ");
        Console.WriteLine();
        for (int i = 0; i < 10; i++)
            Console.Write(obj[-i] + " ");
        Console.WriteLine("\n-----------------------");
        MyClass1 obj1 = new MyClass1(12345);
        for (int i = 1; i < 9; i++)
            Console.Write(" | " + obj1[i]);
        Console.WriteLine(" |");
        Console.WriteLine("-----------------------");
        MyString txt = "Mуха";
        Console.WriteLine(txt);
        txt[-1] = 'Ы';
        Console.WriteLine(txt);
        txt[4] = 'Ъ';
        Console.WriteLine(txt);
        txt[0] = 'С';
        Console.WriteLine(txt);
        txt[1] = 'л';
        Console.WriteLine(txt);
        txt[2] = 'о';
        Console.WriteLine(txt);
        txt[3] = 'н';
        Console.WriteLine(txt);
        Console.WriteLine("-----------------------");
        MyClass2 A = new MyClass2(100);
        Console.WriteLine("Объект А: {0}", A.code);
        MyClass2 B = new MyClass2(150);
        Console.WriteLine("Объект B: {0}", B.code);
        int num = A[B];
        Console.WriteLine("Выражение А[B] = {0}", num);
        Console.WriteLine("Выражение B[A] = {0}", B[A]);
        A[B] = 200;
        Console.WriteLine("Объект А: {0}", A.code);
    }
}