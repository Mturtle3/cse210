using System;

class Reference
{
    private string _book;
    private int _chapter;
    private int _start;
    private int _end;

    public Reference(string book, int chapter, int start)
    {
        _book = book;
        _chapter = chapter;
        _start = start;
        _end = start;
    }

    public Reference(string book, int chapter, int start, int end)
    {
        _book = book;
        _chapter = chapter;
        _start = start;
        _end = end;
    }

    public void Display()
    {
        if (_start == _end)
        {
            Console.Write($"{_book} {_chapter}:{_start}");
        }
        else
        {
            Console.Write($"{_book} {_chapter}:{_start}-{_end}");
        }
    }
}