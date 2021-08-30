using System;
using System.Collections;

class Controller
{
    
    private SqliteBroker broker;
    private Validator validator = new Validator();

    public Controller() {
        this.broker = new SqliteBroker();
        broker.CreateConnection();
        broker.CreateTable();
    }

    public void Add() {
        Console.Write("Tipo: ");
        string type = Console.ReadLine();
        Console.Write("Descrição: ");
        string description = Console.ReadLine();
        Console.Write("Valor: ");
        string value = Console.ReadLine();
        if (validator.ValidateCurrency(value) && validator.ValidateType(type)) {
            this.broker.Add(description, value, type);
        }
        else {
            Console.WriteLine("Tipo e/ou valor inválido(s)");
        }
        
    }

    public void PrintList() {
        ArrayList list = this.broker.GetAllItems();
        Console.WriteLine("---------------------------");
        foreach (Item item in list) {
            item.PrintInfo();
            Console.WriteLine("---------------------------");
        }
    }

}
