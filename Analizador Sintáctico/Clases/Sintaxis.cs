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
            ///
            S.lstSintaxDerecha.Add("PROD");
            S.lstSintaxDerecha.Add("PROI");
            S.lstSintaxDerecha.Add("FNCD");
            S.lstSintaxDerecha.Add("FNCI");
            S.lstSintaxDerecha.Add("PASA");
            S.lstSintaxDerecha.Add("ASIG OPEA");
            S.lstSintaxDerecha.Add("ASIG PROI");
            Sintax.Add(S);

            //♥♥ GRAMATICA LIBRE DE CONTEXTO EQUIPO #8 ♥♥
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
            FNCI.lstSintaxDerecha.Add("ASIG IDEN FIRI");
            FNCI.lstSintaxDerecha.Add("ASIG IDEN FIRD");
            FNCI.lstSintaxDerecha.Add("TIPO ASIG IDEN FIRI");
            FNCI.lstSintaxDerecha.Add("ASIG IDEN SINP");
            FNCI.lstSintaxDerecha.Add("TIPO ASIG IDEN SINP");
            Sintax.Add(FNCI);
            SintaxLibre PASA = new SintaxLibre();
            PASA.SintaxIzquierda = "PASA";
            PASA.lstSintaxDerecha.Add("PR17 FIRI");
            Sintax.Add(PASA);
            SintaxLibre ACCE = new SintaxLibre();
            ACCE.SintaxIzquierda = "ACCE";
            ACCE.lstSintaxDerecha.Add("PR19");
            ACCE.lstSintaxDerecha.Add("PR21");
            Sintax.Add(ACCE);
            SintaxLibre FIRD = new SintaxLibre();
            FIRD.SintaxIzquierda = "FIRD";
            FIRD.lstSintaxDerecha.Add("PARD");
            FIRD.lstSintaxDerecha.Add("PAR2 PARD PAR1");
            FIRD.lstSintaxDerecha.Add("PAR2 PARD FIRD PAR1");
            Sintax.Add(FIRD);
            SintaxLibre PARD = new SintaxLibre();
            PARD.SintaxIzquierda = "PARD";
            PARD.lstSintaxDerecha.Add("TIPO VARI");
            PARD.lstSintaxDerecha.Add("TIPO IDEN");
            PARD.lstSintaxDerecha.Add("PARD PARD");
            PARD.lstSintaxDerecha.Add("PR22 TIPO VARI");
            PARD.lstSintaxDerecha.Add("PR22 TIPO VARI");
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
            FIRI.lstSintaxDerecha.Add("PAR2 VARI PAR1");
            FIRI.lstSintaxDerecha.Add("PAR2 IDEN PAR1");
            FIRI.lstSintaxDerecha.Add("PAR2 VARR PAR1");
            FIRI.lstSintaxDerecha.Add("PAR2 VARI FIRI PAR1");
            FIRI.lstSintaxDerecha.Add("PAR2 IDEN FIRI PAR1");
            FIRI.lstSintaxDerecha.Add("PAR2 VARR FIRI PAR1");
            Sintax.Add(FIRI);
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
            //VARI.lstSintaxDerecha.Add("IDEN");
            VARI.lstSintaxDerecha.Add("CONU");
            VARI.lstSintaxDerecha.Add("OPEA");
            VARI.lstSintaxDerecha.Add("CADE");
            Sintax.Add(VARI);
            SintaxLibre IDEN = new SintaxLibre();
            IDEN.SintaxIzquierda = "IDEN";
            IDEN.lstSintaxDerecha.Add("ID");
            IDEN.lstSintaxDerecha.Add("IDEN IDEN");
            Sintax.Add(IDEN);
            //SINTAXIS LIBRE DE CONTEXTO OTROS EQUIPOS :)
            SintaxLibre OPEA = new SintaxLibre();
            OPEA.SintaxIzquierda = "OPEA";
            OPEA.lstSintaxDerecha.Add("IDEN OPAR IDEN");
            OPEA.lstSintaxDerecha.Add("CONU OPAR CONU");
            OPEA.lstSintaxDerecha.Add("CONU OPAR IDEN");
            OPEA.lstSintaxDerecha.Add("IDEN OPAR CONU");
            OPEA.lstSintaxDerecha.Add("OPEA OPAR IDEN");
            OPEA.lstSintaxDerecha.Add("IDEN OPAR OPEA");
            OPEA.lstSintaxDerecha.Add("OPEA OPAR OPEA");
            OPEA.lstSintaxDerecha.Add("CONU OPAR OPEA");
            OPEA.lstSintaxDerecha.Add("OPEA OPAR CONU");
            OPEA.lstSintaxDerecha.Add("PAR2 OPEA PAR1");
            Sintax.Add(OPEA);
            SintaxLibre ASIG = new SintaxLibre();
            ASIG.SintaxIzquierda = "ASIG";
            ASIG.lstSintaxDerecha.Add("IDEN OPA6");
            ASIG.lstSintaxDerecha.Add("FIRD OPA6");
            Sintax.Add(ASIG);
            SintaxLibre OPER = new SintaxLibre();
            OPER.SintaxIzquierda = "OPER";
            OPER.lstSintaxDerecha.Add("IDEN OPRE IDEN");
            OPER.lstSintaxDerecha.Add("CONU OPRE IDEN");
            OPER.lstSintaxDerecha.Add("IDEN OPRE CONU");
            OPER.lstSintaxDerecha.Add("OPRE OPRE IDEN");
            OPER.lstSintaxDerecha.Add("IDEN OPRE OPEA");
            OPER.lstSintaxDerecha.Add("OPEA OPRE OPEA");
            OPER.lstSintaxDerecha.Add("CONU OPRE OPEA");
            OPER.lstSintaxDerecha.Add("PAR2 OPRE PAR1");
            OPER.lstSintaxDerecha.Add("PAR2 OPER PAR1");
            Sintax.Add(OPER);
            SintaxLibre OPEL = new SintaxLibre();
            OPEL.SintaxIzquierda = "OPEL";
            OPEL.lstSintaxDerecha.Add("OL03 OPER");
            OPEL.lstSintaxDerecha.Add("OL03 OPEL");
            OPEL.lstSintaxDerecha.Add("OPER OL02 OPER");
            OPEL.lstSintaxDerecha.Add("OPER OL01 OPER");
            OPEL.lstSintaxDerecha.Add("OPEL OL02 OPER");
            OPEL.lstSintaxDerecha.Add("OPEL OL01 OPER");
            OPEL.lstSintaxDerecha.Add("OPER OL02 OPEL");
            OPEL.lstSintaxDerecha.Add("OPER OL01 OPEL");
            OPEL.lstSintaxDerecha.Add("OPEL OL02 OPEL");
            OPEL.lstSintaxDerecha.Add("OPEL OL01 OPEL");
            OPEL.lstSintaxDerecha.Add("PAR2 OPEL PAR1");
            Sintax.Add(OPEL);
            SintaxLibre OPRE = new SintaxLibre();
            OPRE.SintaxIzquierda = "OPRE";
            OPRE.lstSintaxDerecha.Add("OPR1");
            OPRE.lstSintaxDerecha.Add("OPR2");
            OPRE.lstSintaxDerecha.Add("OPR3");
            OPRE.lstSintaxDerecha.Add("OPR4");
            OPRE.lstSintaxDerecha.Add("OPR5");
            OPRE.lstSintaxDerecha.Add("OPR6");
            Sintax.Add(OPRE);
        }
    }
}
