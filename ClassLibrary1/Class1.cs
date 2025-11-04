namespace ClassLibrary1
{
     public  class NumeroComplesso
    {
        public int R { get; set; }
        public int IMG { get; set; }

        public NumeroComplesso(int parteReale, int parteImmaginaria)
        {
            R = parteReale;
            IMG = parteImmaginaria;
        }

        public static NumeroComplesso Parse(string s)
        {
           
            string t = s.Trim().Replace(" ", "");
            if (t.Length == 0)
                throw new Exception("La stringa non può essere vuota");

            bool isImmaginario = t.EndsWith("i", StringComparison.OrdinalIgnoreCase);
            int reale = 0;
            int immaginaria = 0;

            if (isImmaginario)
            {
                string core = t.Substring(0, t.Length - 1);         // toglie la "i" finale

                if (string.IsNullOrEmpty(core))
                {
                    immaginaria = 1;                                // "i"
                    return new NumeroComplesso(0, immaginaria);
                }
                if (core == "+")
                {
                    immaginaria = 1;
                    return new NumeroComplesso(0, immaginaria);
                }
                if (core == "-")                                    // "-i"
                {
                    immaginaria = -1;
                    return new NumeroComplesso(0, immaginaria);
                }
                int dividiRealeImmaginaria = -1;
                for (int i = core.Length - 1; i >= 1; i--)          //trova l'inizio della parte immaginaria
                {
                    char c = core[i];
                    if (c == '+' || c == '-')
                    {
                        dividiRealeImmaginaria = i;
                        break;
                    }
                }
                string realeStringa = null;
                string immaginariaString = null;

                if (dividiRealeImmaginaria > 0)
                {
                    realeStringa = core.Substring(0, dividiRealeImmaginaria);
                    immaginariaString = core.Substring(dividiRealeImmaginaria);
                }
                else
                {
                    immaginariaString = core;               // solo parte immaginaria
                }
                if (string.IsNullOrEmpty(immaginariaString))
                    throw new Exception("parte immaginaria non valida");
                if (immaginariaString == "+")
                    immaginaria = 1;
                else if (immaginariaString == "-")
                    immaginaria = -1;
                else
                {
                    if (!int.TryParse(immaginariaString, out immaginaria))
                        throw new Exception($"Parte immaginaria non valida: '{immaginariaString}'.");
                }
                if (!string.IsNullOrEmpty(realeStringa))
                {
                    if (!int.TryParse(realeStringa, out reale))
                        throw new Exception($"Parte reale non valida: '{realeStringa}'.");
                }
                return new NumeroComplesso(reale, immaginaria);
            }
            else
            {
                if (!int.TryParse(t, out reale))                                    // solo parte reale
                    throw new Exception($"Parte reale non valida: '{t}'.");
                return new NumeroComplesso(reale, 0);
            }
        }


      
        public static NumeroComplesso operator +(NumeroComplesso a, NumeroComplesso b)
        {
            return new NumeroComplesso(a.R + b.R, a.IMG + b.IMG);
        }
        public static NumeroComplesso operator -(NumeroComplesso a, NumeroComplesso b)
        {
            return new NumeroComplesso(a.R - b.R, a.IMG - b.IMG);
        }
        public static NumeroComplesso operator *(NumeroComplesso a, NumeroComplesso b)
        {
            int R = a.R * b.R - a.IMG * b.IMG;
            int parteImmaginaria = a.R * b.IMG + a.IMG * b.R;
            return new NumeroComplesso(R, parteImmaginaria);
        }
        public static NumeroComplesso operator /(NumeroComplesso a, NumeroComplesso b)
        {
            int denominatore = b.R * b.R + b.IMG * b.IMG;
            int r = (a.R * b.R + a.IMG * b.IMG) / denominatore;
            int img = (a.IMG * b.R - a.R * b.IMG) / denominatore;
            return new NumeroComplesso(r, img);
        }

    }
}
