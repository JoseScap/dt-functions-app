
using System;

namespace Company.Function.Entities;
public class Player
{
    public string id { get; set; }
    public string fullname { get; set; }
    public int basePrice { get; set; }
    public int stars { get; set; }
    public string mainSkill { get; set; }
    public Player() { }
    public Player(string Fullname, int BasePrice, int Stars)
    {
        id = Guid.NewGuid().ToString();
        fullname = Fullname;
        basePrice = BasePrice;
        stars = Stars;
    }
    public Player(string Fullname, int BasePrice, int Stars, string MainSkill)
    {
        id = Guid.NewGuid().ToString();
        fullname = Fullname;
        basePrice = BasePrice;
        stars = Stars;
        mainSkill = MainSkill;
    }
}