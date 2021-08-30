using System;

class Item {

    public int Id {get; set;}
    public string Description {get; set;}
    /*
    Eu tentei deixar a variável Value como double,
    mas ainda não consegui resolver o problema de conversão
    que aparecia depois (quando tentava pegar o valor do SQLite em SqliteBroker.GetAllItems())
    */
    public string Value {get; set;}
    public string Type {get; set;}

    public Item(int id, string description, string value, string type) {
        this.Id = id;
        this.Description = description;
        this.Value = value;
        this.Type = type;
    }

    public void PrintInfo() {
        Console.WriteLine(this.Id + " - " + this.Type);
        Console.WriteLine(this.Description);
        Console.WriteLine("R$" + this.Value);
    }

}