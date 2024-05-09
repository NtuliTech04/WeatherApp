﻿using System.ComponentModel;

namespace Weather.BLL.Constants.Enums
{
    public enum Provinces
    {
        [Description("Eastern Cape")] EasternCape,
        [Description("Free State")] FreeState,
        [Description("Gauteng")] Gauteng,
        [Description("KwaZulu-Natal")] KwaZuluNatal,
        [Description("Limpopo")] Limpopo,
        [Description("Mpumalanga")] Mpumalanga,
        [Description("North West")] NorthWest,
        [Description("Northern Cape")] NorthernCape,
        [Description("Western Cape")] WesternCape
    }

    public enum Countries
    {
        [Description("South Africa")] RSA
    }
}