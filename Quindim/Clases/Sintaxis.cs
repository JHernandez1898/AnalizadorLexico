using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quindim.Clases
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
            S.lstSintaxDerecha.Add("PARA"); //PARA
            S.lstSintaxDerecha.Add("PROD"); //PROD
            S.lstSintaxDerecha.Add("PROI"); //PROI
            S.lstSintaxDerecha.Add("FNCD"); //FNCD
            S.lstSintaxDerecha.Add("FNCI"); //FNCI
            S.lstSintaxDerecha.Add("PASA"); //PASA
            S.lstSintaxDerecha.Add("ASIG"); //ASIG
            S.lstSintaxDerecha.Add("IMPR"); //IMPR
            S.lstSintaxDerecha.Add("CAPT"); //CAPT
            S.lstSintaxDerecha.Add("PR04"); //PR08
            S.lstSintaxDerecha.Add("COND"); //COND
            S.lstSintaxDerecha.Add("SWTC"); //SWTC
            //  S.lstSintaxDerecha.Add("ARGU ARGM ARGN");
            S.lstSintaxDerecha.Add("PR08");  //PR08

            Sintax.Add(S);
            SintaxLibre PARA = new SintaxLibre();
            PARA.SintaxIzquierda = "PARA"; //PARA
            PARA.lstSintaxDerecha.Add("PR16 ASIG PR10 OPER PR24 ASIG"); //PR16 ASIG PR10 OPER PR24 ASIG
            Sintax.Add(PARA);

            SintaxLibre ASIG = new SintaxLibre();
            ASIG.SintaxIzquierda = "ASIG"; //ASIG
            ASIG.lstSintaxDerecha.Add("IDEN OPA6"); // IDEN OPA6
            ASIG.lstSintaxDerecha.Add("ASIG IDEN"); // ASIG IDEN
            ASIG.lstSintaxDerecha.Add("ASIG OPEA"); // ASIG OPEA            
            ASIG.lstSintaxDerecha.Add("ASIG FNCI"); // ASIG FNCI
            ASIG.lstSintaxDerecha.Add("ASIG VARI"); // ASIG VARI
            ASIG.lstSintaxDerecha.Add("ASIG FIRI"); // ASIG FIRI
            ASIG.lstSintaxDerecha.Add("TIPO IDEN OPA6"); //TIPO IDEN OPA6
            Sintax.Add(ASIG);

            SintaxLibre OPER = new SintaxLibre();
            OPER.SintaxIzquierda = "OPER"; //OPER
            OPER.lstSintaxDerecha.Add("IDEN OPRE CONU"); //IDEN OPRE CONU
            OPER.lstSintaxDerecha.Add("IDEN OPRE IDEN"); //IDEN OPRE IDEN
            OPER.lstSintaxDerecha.Add("CONU OPRE CONU"); //CONU OPRE CONU
            OPER.lstSintaxDerecha.Add("CONU OPRE IDEN"); //CONU OPRE IDEN
             OPER.lstSintaxDerecha.Add("OPRE OPRE IDEN"); //OPRE OPRE IDEN
            OPER.lstSintaxDerecha.Add("IDEN OPRE OPEA"); //IDEN OPRE OPEA
            OPER.lstSintaxDerecha.Add("OPEA OPRE OPEA"); //OPEA OPRE OPEA
            OPER.lstSintaxDerecha.Add("CONU OPRE OPEA"); //CONU OPRE OPEA
            OPER.lstSintaxDerecha.Add("OPEA OPRE CONU"); //OPEA OPRE CONU
            OPER.lstSintaxDerecha.Add("PAR2 OPRE PAR1"); //PAR2 OPRE PAR1
            OPER.lstSintaxDerecha.Add("PAR2 OPER PAR1"); //PAR2 OPER PAR1
            Sintax.Add(OPER);
    

            SintaxLibre FNCD = new SintaxLibre();
            FNCD.SintaxIzquierda = "FNCD"; //FNCD
            FNCD.lstSintaxDerecha.Add("PR09 TIPO ACCE IDEN FIRD"); //PR09 TIPO ACCE IDEN FIRD
            FNCD.lstSintaxDerecha.Add("PR09 TIPO ACCE IDEN SINP"); //PR09 TIPO ACCE IDEN SINP
            Sintax.Add(FNCD);
            SintaxLibre CAPT = new SintaxLibre();
            CAPT.SintaxIzquierda = "CAPT"; //CAPT
            CAPT.lstSintaxDerecha.Add("PR01 IDEN");//PR01 IDEN            
            Sintax.Add(CAPT);
            SintaxLibre IMPR = new SintaxLibre();
            IMPR.SintaxIzquierda = "IMPR"; //IMPR
            IMPR.lstSintaxDerecha.Add("PR12 VARI"); //PR12 VARI
            IMPR.lstSintaxDerecha.Add("PR12 IDEN"); //PR12 IDEN
            IMPR.lstSintaxDerecha.Add("IMPR IDEN"); //IMPR IDEN
            IMPR.lstSintaxDerecha.Add("IMPR VARI"); //IMPR VARI
            IMPR.lstSintaxDerecha.Add("IMPR CONU"); //IMPR CONU
            Sintax.Add(IMPR);
       

            SintaxLibre FNCI = new SintaxLibre();
            FNCI.SintaxIzquierda = "FNCI"; //FNCI
            FNCI.lstSintaxDerecha.Add("TIPO ASIG IDEN FIRI"); //TIPO ASIG IDEN FIRI
            FNCI.lstSintaxDerecha.Add("IDEN PAR2 IDEN PAR1"); // IDEN PAR2 IDEN PAR1
            FNCI.lstSintaxDerecha.Add("IDEN PAR2 VARI PAR1"); // IDEN PAR2 VARI PAR1
            FNCI.lstSintaxDerecha.Add("ASIG IDEN FIRI"); //ASIG IDEN FIRI
            FNCI.lstSintaxDerecha.Add("ASIG IDEN FIRD"); //ASIG IDEN FIRD
            FNCI.lstSintaxDerecha.Add("ASIG IDEN SINP"); //ASIG IDEN SINP          
            Sintax.Add(FNCI);
                     

            SintaxLibre PROD = new SintaxLibre();
            PROD.SintaxIzquierda = "PROD"; //PROD 
            PROD.lstSintaxDerecha.Add("PR20 ACCE IDEN FIRD"); //PR20 ACCE IDEN FIRD
            PROD.lstSintaxDerecha.Add("PR20 ACCE IDEN SINP"); //PR20 ACCE IDEN SINP
            Sintax.Add(PROD);

            SintaxLibre FIRD = new SintaxLibre();
            FIRD.SintaxIzquierda = "FIRD"; 
            FIRD.lstSintaxDerecha.Add("PAR2 PARD FIRD PAR1");
            FIRD.lstSintaxDerecha.Add("PAR2 PARD PAR1");
            FIRD.lstSintaxDerecha.Add("PARD");
            Sintax.Add(FIRD);

           

            SintaxLibre PARD = new SintaxLibre();
            PARD.SintaxIzquierda = "PARD";           
            PARD.lstSintaxDerecha.Add("PR22 TIPO VARI");
            PARD.lstSintaxDerecha.Add("PR22 TIPO IDEN");
            PARD.lstSintaxDerecha.Add("TIPO VARI");
            PARD.lstSintaxDerecha.Add("TIPO IDEN");
            PARD.lstSintaxDerecha.Add("PARD PARD");
 
            Sintax.Add(PARD);
          
           
            //♥♥ GRAMATICA LIBRE DE CONTEXTO EQUIPO #8 ♥♥

            SintaxLibre PROI = new SintaxLibre();
            PROI.SintaxIzquierda = "PROI";
            PROI.lstSintaxDerecha.Add("IDEN FIRI");
            PROI.lstSintaxDerecha.Add("IDEN SINP");
            Sintax.Add(PROI);
           
            SintaxLibre PASA = new SintaxLibre();
            PASA.SintaxIzquierda = "PASA";
            PASA.lstSintaxDerecha.Add("PR17 FIRI");
            Sintax.Add(PASA);
            SintaxLibre ACCE = new SintaxLibre();
            ACCE.SintaxIzquierda = "ACCE";
            ACCE.lstSintaxDerecha.Add("PR19");
            ACCE.lstSintaxDerecha.Add("PR21");
            Sintax.Add(ACCE);
 
        
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
            VARI.lstSintaxDerecha.Add("CONU");
            VARI.lstSintaxDerecha.Add("OPEA");
            VARI.lstSintaxDerecha.Add("CADE");
            Sintax.Add(VARI);
            SintaxLibre IDEN = new SintaxLibre();
            IDEN.SintaxIzquierda = "IDEN";
            IDEN.lstSintaxDerecha.Add("ID");            
            Sintax.Add(IDEN);            
            SintaxLibre COND = new SintaxLibre();
           COND.SintaxIzquierda = "COND";
            COND.lstSintaxDerecha.Add("PR23 OPER");
            COND.lstSintaxDerecha.Add("PR23 OPEL");
            Sintax.Add(COND);
        
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
            OPEA.lstSintaxDerecha.Add("FNCI OPAR CONU");
            OPEA.lstSintaxDerecha.Add("FNCI OPAR OPEA");
            Sintax.Add(OPEA);

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
