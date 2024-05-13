export namespace UrlOptions {

  enum Provinces {
    EasternCape = "Eastern Cape",
    FreeState = "Free State",
    Gauteng = "Gauteng",
    KwaZuluNatal = "KwaZulu-Natal",
    Limpopo = "Limpopo",
    Mpumalanga = "Mpumalanga",
    NorthWest = "North West",
    NorthernCape = "Northern Cape",
    WesternCape = "Western Cape"
  }

  //Dictionary definition and usage
  export let locationOptionsData: { [key in Provinces]: string[] } = {
    [Provinces.EasternCape]:
      [
        "Alice",
        "Butterworth",
        "East London",
        "Graaff-Reinet",
        "Grahamstown",
        // "King Williams Town",
        "Mthatha",
        "Port Elizabeth",
        "Queenstown",
        "Uitenhage",
        "Zwelitsha"
      ],
    [Provinces.FreeState]:
      [
        "Bethlehem",
        "Bloemfontein",
        "Jagersfontein",
        "Kroonstad",
        "Odendaalsrus",
        "Parys",
        "Phuthaditjhaba",
        "Sasolburg",
        "Virginia",
        "Welkom"
      ],
    [Provinces.Gauteng]:
      [
        "Benoni",
        "Boksburg",
        "Brakpan",
        "Carletonville",
        "Germiston",
        "Johannesburg",
        "Krugersdorp",
        "Pretoria",
        "Randburg",
        "Randfontein",
        "Roodepoort",
        "Soweto",
        "Springs",
        "Vanderbijlpark",
        "Vereeniging"
      ],
    [Provinces.KwaZuluNatal]:
      [
        "Durban",
        "Empangeni",
        "Ladysmith",
        "Newcastle",
        "Pietermaritzburg",
        "Pinetown",
        "Ulundi",
        // "Umlazi"
      ],
    [Provinces.Limpopo]:
      [
        "Giyani",
        "Lebowakgomo",
        "Musina",
        "Phalaborwa",
        "Polokwane",
        "Seshego",
        "Sibasa",
        "Thabazimbi"
      ],
    [Provinces.Mpumalanga]:
      [
        "Emalahleni",
        "Nelspruit",
        "Secunda"
      ],
    [Provinces.NorthWest]:
      [
        "Klerksdorp",
        "Mahikeng",
        "Mmabatho",
        "Potchefstroom",
        "Rustenburg"
      ],
    [Provinces.NorthernCape]:
      [
        "Kimberley",
        "Kuruman",
        // "Port Nolloth"
      ],
    [Provinces.WesternCape]:
      [
        "Bellville",
        "Cape Town",
        "Constantia",
        "George",
        "Hopefield",
        "Oudtshoorn",
        "Paarl",
        // "Simons Town",
        "Stellenbosch",
        "Swellendam",
        "Worcester"
      ],
  };

  //Measurement units
  export enum Unit {
    Metric,
    Kelvin,
    Imperial
  }
}
