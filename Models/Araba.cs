namespace Rent_A_Car.Models;

public class Araba
{
    public string? ArabaPlaka { get; set; }
    public string? ArabaMarka { get; set; }
    public string? ArabaModel { get; set; }
    public string? ArabaRenk { get; set; }

    public int? ArabaSinifID { get; set; }

    
    //public Araba(int arabaID, string arabaPlaka,string arabaMarka,string arabaModel)
    //{
    //    this.ArabaID = arabaID;
    //    this.ArabaPlaka = arabaPlaka;
    //    this.ArabaMarka = arabaMarka;
    //    this.ArabaModel = arabaModel;
    //}    
    //public Araba(){}
}