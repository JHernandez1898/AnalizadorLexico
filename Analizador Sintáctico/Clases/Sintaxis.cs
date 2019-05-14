using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Sintáctico.Clases
{
    class SintaxisL
    {
        public List<SintaxLibre> Sintax = new List<SintaxLibre>();

        public SintaxisL()
        {
            IniciarSintaxis();
        }

        private void IniciarSintaxis()
        {
            SintaxLibre S = new SintaxLibre();
            S.SintaxIzquierda = "S";
            S.lstSintaxDerecha.Add("PROD");
            S.lstSintaxDerecha.Add("PROI");
            S.lstSintaxDerecha.Add("FNCD");
            S.lstSintaxDerecha.Add("FNCI");
            S.lstSintaxDerecha.Add("PASA");
            
            Sintax.Add(S);

            //♥♥ SINTAXIS LIBRE DE CONTEXTO EQUIPO #8 ♥♥
            SintaxLibre PROD = new SintaxLibre();
            PROD.SintaxIzquierda = "PROD";
            PROD.lstSintaxDerecha.Add("PR20 ACCE IDEN FIRD");
            PROD.lstSintaxDerecha.Add("PR20 ACCE IDEN SINP");
            Sintax.Add(PROD);
            SintaxLibre PROI = new SintaxLibre();
            PROI.SintaxIzquierda = "PROI";
            PROI.lstSintaxDerecha.Add("IDEN FIRI");
            PROI.lstSintaxDerecha.Add("IDEN SINP");
            Sintax.Add(PROI);
            SintaxLibre FNCD = new SintaxLibre();
            FNCD.SintaxIzquierda = "FNCD";
            FNCD.lstSintaxDerecha.Add("PR09 TIPO ACCE IDEN FIRD");
            FNCD.lstSintaxDerecha.Add("PR09 TIPO ACCE IDEN SINP");
            Sintax.Add(FNCD);
            SintaxLibre FNCI = new SintaxLibre();
            FNCI.SintaxIzquierda = "FNCI";
            FNCI.lstSintaxDerecha.Add("IDEN OPA6 IDEN FIRI");
            FNCI.lstSintaxDerecha.Add("TIPO IDEN OPA6 IDEN FIRI");
            FNCI.lstSintaxDerecha.Add("IDEN OPA6 IDEN SINP");
            FNCI.lstSintaxDerecha.Add("TIPO IDEN OPA6 IDEN SINP");
            Sintax.Add(FNCI);
            SintaxLibre PASA = new SintaxLibre();
            PASA.SintaxIzquierda = "PASA";
            PASA.lstSintaxDerecha.Add("PR17 FIRP");
            PASA.lstSintaxDerecha.Add("PR17 FIRI");
            Sintax.Add(PASA);
            SintaxLibre ACCE = new SintaxLibre();
            ACCE.SintaxIzquierda = "ACCE";
            ACCE.lstSintaxDerecha.Add("PR19");
            ACCE.lstSintaxDerecha.Add("PR21");
            Sintax.Add(ACCE);
            SintaxLibre FIRD = new SintaxLibre();
            FIRD.SintaxIzquierda = "FIRD";
            FIRD.lstSintaxDerecha.Add("PAR2 PARD PAR1");
            FIRD.lstSintaxDerecha.Add("PAR2 PARD FIRD PAR1");
            Sintax.Add(FIRD);
            SintaxLibre PARD = new SintaxLibre();
            PARD.SintaxIzquierda = "PARD";
            PARD.lstSintaxDerecha.Add("TIPO IDEN");
            PARD.lstSintaxDerecha.Add("PR22 TIPO IDEN");
            Sintax.Add(PARD);
            SintaxLibre TIPO = new SintaxLibre();
            TIPO.SintaxIzquierda = "TIPO";
            TIPO.lstSintaxDerecha.Add("TDD1");
            TIPO.lstSintaxDerecha.Add("TDD2");
            TIPO.lstSintaxDerecha.Add("TDD3");
            TIPO.lstSintaxDerecha.Add("TDD4");
            Sintax.Add(TIPO);
            SintaxLibre FIRI = new SintaxLibre();
            FIRI.SintaxIzquierda = "FIRI";
            FIRI.lstSintaxDerecha.Add("PAR2 IDEN PAR1");
            FIRI.lstSintaxDerecha.Add("PAR2 VARR PAR1");
            FIRI.lstSintaxDerecha.Add("PAR2 VARI FIRI PAR1");
            FIRI.lstSintaxDerecha.Add("PAR2 VARR FIRI PAR1");
            Sintax.Add(FIRI);
            SintaxLibre FIRP = new SintaxLibre();
            FIRP.SintaxIzquierda = "FIRP";
            FIRP.lstSintaxDerecha.Add("PAR2 VARI PAR1");
            Sintax.Add(FIRP);
            SintaxLibre SINP = new SintaxLibre();
            SINP.SintaxIzquierda = "SINP";
            SINP.lstSintaxDerecha.Add("PAR2 PAR1");
            Sintax.Add(SINP);
            SintaxLibre CONU = new SintaxLibre();
            CONU.SintaxIzquierda = "CONU";
            CONU.lstSintaxDerecha.Add("CNE");
            CONU.lstSintaxDerecha.Add("CNEE");
            CONU.lstSintaxDerecha.Add("CNR");
            CONU.lstSintaxDerecha.Add("CNRE");
            Sintax.Add(CONU);
            SintaxLibre OPAR = new SintaxLibre();
            OPAR.SintaxIzquierda = "OPAR";
            OPAR.lstSintaxDerecha.Add("OPA1");
            OPAR.lstSintaxDerecha.Add("OPA2");
            OPAR.lstSintaxDerecha.Add("OPA3");
            OPAR.lstSintaxDerecha.Add("OPA4");
            OPAR.lstSintaxDerecha.Add("OPA5");
            Sintax.Add(OPAR);
            SintaxLibre VARR = new SintaxLibre();
            VARR.SintaxIzquierda = "VARR";
            VARR.lstSintaxDerecha.Add("PR22 IDEN");
            Sintax.Add(VARR);
            SintaxLibre VARI = new SintaxLibre();
            VARI.SintaxIzquierda = "VARI";
            VARI.lstSintaxDerecha.Add("CONU");
            VARI.lstSintaxDerecha.Add("OPEA");
            VARI.lstSintaxDerecha.Add("CADE");
            Sintax.Add(VARI);
            SintaxLibre IDEN = new SintaxLibre();
            IDEN.SintaxIzquierda = "IDEN";
            IDEN.lstSintaxDerecha.Add("ID");
            Sintax.Add(IDEN);
            //SINTAXIS LIBRE DE CONTEXTO OTROS EQUIPOS :)

            
        }
    }
}
