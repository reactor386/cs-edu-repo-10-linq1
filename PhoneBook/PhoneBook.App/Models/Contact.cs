//-
using System;


namespace PhoneBook.Models;

/// <summary>
/// Оригинальная модель класса из задания 14.2.10
/// </summary>
public class Contact
{
    // метод-конструктор
    public Contact(string name, string lastName,
        long phoneNumber, string email)
    {
        Name = name;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public string Name {get;}
    public string LastName {get;}
    public long PhoneNumber {get;}
    public string Email {get;}
}
