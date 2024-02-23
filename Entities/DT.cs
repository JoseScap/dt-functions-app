
using System;

namespace Company.Function.Entities;
public class DT
{
    public string id { get; set; }
    public string fullname { get; set; }
    public double money { get; set; }

    public DT() { }
    public DT(string Fullname)
    {
        id = Guid.NewGuid().ToString();
        fullname = Fullname;
        money = 1000000; // TODO: Implementar triggers para que el dinero se genere solo
    }
}