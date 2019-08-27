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
            S.lstSintaxDerecha.Add("PARA"); //PARA
            S.lstSintaxDerecha.Add("PROD"); //PROD
            S.lstSintaxDerecha.Add("PROI"); //PROI
            S.lstSintaxDerecha.Add("FNCD"); //FNCD
            S.lstSintaxDerecha.Add("FNCI"); //FNCI
            S.lstSintaxDerecha.Add("PASA"); //PASA
            S.lstSintaxDerecha.Add("ASIG"); //ASIG
            S.lstSintaxDerecha.Add("IMPR"); //IMPR
            S.lstSintaxDerecha.Add("CAPT"); //CAPT
            S.lstSintaxDerecha.Add("PR05"); //Antes era PR04
            S.lstSintaxDerecha.Add("COND"); //COND 
            S.lstSintaxDerecha.Add("SWTC"); //SWTC
            //  S.lstSintaxDerecha.Add("ARGU ARGM ARGN");
            S.lstSintaxDerecha.Add("PR21");  //Antes era PR08

            Sintax.Add(S);
            SintaxLibre PARA = new SintaxLibre();
            PARA.SintaxIzquierda = "PARA"; //PARA
            PARA.lstSintaxDerecha.Add("PR06 ASIG PR19 OPER PR17 ASIG"); //Antes era PR16 ASIG PR10 OPER PR24 ASIG
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
            OPER.lstSintaxDerecha.Add("PAR1 OPRE PAR2"); //Antes era PAR2 OPRE PAR1
            OPER.lstSintaxDerecha.Add("PAR1 OPER PAR2"); //Antes era PAR2 OPER PAR1
            Sintax.Add(OPER);
    

            SintaxLibre FNCD = new SintaxLibre();
            FNCD.SintaxIzquierda = "FNCD"; //FNCD
            FNCD.lstSintaxDerecha.Add("PR07 TIPO ACCE IDEN FIRD"); //Antes era PR09 TIPO ACCE IDEN FIRD
            FNCD.lstSintaxDerecha.Add("PR07 TIPO ACCE IDEN SINP"); //Antes era PR09 TIPO ACCE IDEN SINP
            Sintax.Add(FNCD);
            SintaxLibre CAPT = new SintaxLibre();
            CAPT.SintaxIzquierda = "CAPT"; //CAPT
            CAPT.lstSintaxDerecha.Add("PR13 IDEN");//Antes era PR01 IDEN            
            Sintax.Add(CAPT);
            SintaxLibre IMPR = new SintaxLibre();
            IMPR.SintaxIzquierda = "IMPR"; //IMPR
            IMPR.lstSintaxDerecha.Add("PR09 VARI"); //Antes era PR12 VARI
            IMPR.lstSintaxDerecha.Add("PR09 IDEN"); //Antes era PR12 IDEN
            IMPR.lstSintaxDerecha.Add("IMPR IDEN"); //IMPR IDEN
            IMPR.lstSintaxDerecha.Add("IMPR VARI"); //IMPR VARI
            IMPR.lstSintaxDerecha.Add("IMPR CONU"); //IMPR CONU
            Sintax.Add(IMPR);
       

            SintaxLibre FNCI = new SintaxLibre();
            FNCI.SintaxIzquierda = "FNCI"; //FNCI
            FNCI.lstSintaxDerecha.Add("TIPO ASIG IDEN FIRI"); //TIPO ASIG IDEN FIRI
            FNCI.lstSintaxDerecha.Add("IDEN PAR1 IDEN PAR2"); // Antes era IDEN PAR2 IDEN PAR1
            FNCI.lstSintaxDerecha.Add("IDEN PAR1 VARI PAR2"); // Antes era IDEN PAR2 VARI PAR1
            FNCI.lstSintaxDerecha.Add("ASIG IDEN FIRI"); //ASIG IDEN FIRI
            FNCI.lstSintaxDerecha.Add("ASIG IDEN FIRD"); //ASIG IDEN FIRD
            FNCI.lstSintaxDerecha.Add("ASIG IDEN SINP"); //ASIG IDEN SINP          
            Sintax.Add(FNCI);
                     

            SintaxLibre PROD = new SintaxLibre();
            PROD.SintaxIzquierda = "PROD"; //PROD 
            PROD.lstSintaxDerecha.Add("PR11 ACCE IDEN FIRD"); //Antes era PR20 ACCE IDEN FIRD
            PROD.lstSintaxDerecha.Add("PR11 ACCE IDEN SINP"); //Antes era PR20 ACCE IDEN SINP
            Sintax.Add(PROD);

            SintaxLibre FIRD = new SintaxLibre();
            FIRD.SintaxIzquierda = "FIRD";  //FIRD
            FIRD.lstSintaxDerecha.Add("PAR1 PARD FIRD PAR2"); //Antes era PAR2 PARD FIRD PAR1
            FIRD.lstSintaxDerecha.Add("PAR1 PARD PAR2"); //Antes era PAR2 PARD PAR1
            FIRD.lstSintaxDerecha.Add("PARD"); //PARD
            Sintax.Add(FIRD);

           

            SintaxLibre PARD = new SintaxLibre();
            PARD.SintaxIzquierda = "PARD"; //PARD
            PARD.lstSintaxDerecha.Add("PR14 TIPO VARI"); //Antes era PR22 TIPO VARI
            PARD.lstSintaxDerecha.Add("PR14 TIPO IDEN"); //Antes eraPR22 TIPO IDEN
            PARD.lstSintaxDerecha.Add("TIPO VARI"); //TIPO VARI
            PARD.lstSintaxDerecha.Add("TIPO IDEN"); //TIPO IDEN
            PARD.lstSintaxDerecha.Add("PARD PARD"); //PARD PARD 
            Sintax.Add(PARD);
          
           
            //♥♥ GRAMATICA LIBRE DE CONTEXTO EQUIPO #8 ♥♥

            SintaxLibre PROI = new SintaxLibre();
            PROI.SintaxIzquierda = "PROI"; //PROI
            PROI.lstSintaxDerecha.Add("IDEN FIRI"); //IDEN FIRI
            PROI.lstSintaxDerecha.Add("IDEN SINP"); //IDEN SINP
            Sintax.Add(PROI);
           
            SintaxLibre PASA = new SintaxLibre();
            PASA.SintaxIzquierda = "PASA"; //PASA
            PASA.lstSintaxDerecha.Add("PR15 FIRI"); //Antes era PR17 FIRI
            Sintax.Add(PASA);
            SintaxLibre ACCE = new SintaxLibre();
            ACCE.SintaxIzquierda = "ACCE"; //ACCE
            ACCE.lstSintaxDerecha.Add("PR10"); //Antes era PR19
            ACCE.lstSintaxDerecha.Add("PR12"); //Antes era PR21
            Sintax.Add(ACCE);
 
        
            SintaxLibre TIPO = new SintaxLibre();
            TIPO.SintaxIzquierda = "TIPO"; //TIPO 
            TIPO.lstSintaxDerecha.Add("TDD1"); //TDD1
            TIPO.lstSintaxDerecha.Add("TDD2"); //TDD2
            TIPO.lstSintaxDerecha.Add("TDD3"); //TDD3
            TIPO.lstSintaxDerecha.Add("TDD4"); //TDD4
            Sintax.Add(TIPO);
        
        
            SintaxLibre FIRI = new SintaxLibre();
            FIRI.SintaxIzquierda = "FIRI"; //FIRI
            FIRI.lstSintaxDerecha.Add("PAR1 VARI PAR2"); //Antes era PAR2 VARI PAR1
            FIRI.lstSintaxDerecha.Add("PAR1 IDEN PAR2"); //Antes era PAR2 IDEN PAR1
            FIRI.lstSintaxDerecha.Add("PAR1 VARR PAR2"); //Antes era PAR2 VARR PAR1
            FIRI.lstSintaxDerecha.Add("PAR1 VARI FIRI PAR2"); //Antes era PAR2 VARI FIRI PAR1
            FIRI.lstSintaxDerecha.Add("PAR1 IDEN FIRI PAR2"); //Antes era PAR2 IDEN FIRI PAR1
            FIRI.lstSintaxDerecha.Add("PAR1 VARR FIRI PAR2"); //Antes era PAR2 VARR FIRI PAR1

            Sintax.Add(FIRI);
            SintaxLibre SINP = new SintaxLibre();
            SINP.SintaxIzquierda = "SINP"; //SINP
            SINP.lstSintaxDerecha.Add("PAR1 PAR2"); //Antes era PAR2 PAR1
            Sintax.Add(SINP);
            SintaxLibre CONU = new SintaxLibre();
            CONU.SintaxIzquierda = "CONU"; //CONU
            CONU.lstSintaxDerecha.Add("CNE"); //CNE
            CONU.lstSintaxDerecha.Add("CNEE"); //CNEE
            CONU.lstSintaxDerecha.Add("CNR"); //CNR
            CONU.lstSintaxDerecha.Add("CNRE"); //CNRE
       
            Sintax.Add(CONU);
            SintaxLibre OPAR = new SintaxLibre();
            OPAR.SintaxIzquierda = "OPAR"; //OPAR
            OPAR.lstSintaxDerecha.Add("OPA1"); //OPA1
            OPAR.lstSintaxDerecha.Add("OPA2"); //OPA2
            OPAR.lstSintaxDerecha.Add("OPA3"); //OPA3
            OPAR.lstSintaxDerecha.Add("OPA4"); //OPA4
            OPAR.lstSintaxDerecha.Add("OPA5"); //OPA5
            Sintax.Add(OPAR);
            SintaxLibre VARR = new SintaxLibre();
            VARR.SintaxIzquierda = "VARR"; //VARR
            VARR.lstSintaxDerecha.Add("PR14 IDEN"); //Antes era PR22 IDEN
            Sintax.Add(VARR);
            SintaxLibre VARI = new SintaxLibre();
            VARI.SintaxIzquierda = "VARI";  //VARI
            VARI.lstSintaxDerecha.Add("CONU"); //CONU
            VARI.lstSintaxDerecha.Add("OPEA"); //OPEA
            VARI.lstSintaxDerecha.Add("CADE"); //CADE
            Sintax.Add(VARI);
            SintaxLibre IDEN = new SintaxLibre();
            IDEN.SintaxIzquierda = "IDEN"; //IDEN
            IDEN.lstSintaxDerecha.Add("ID"); //ID
            Sintax.Add(IDEN);            
            SintaxLibre COND = new SintaxLibre();
           COND.SintaxIzquierda = "COND"; //COND 
            COND.lstSintaxDerecha.Add("PR08 OPER"); //Antes era PR23 OPER SI -> IF
            COND.lstSintaxDerecha.Add("PR08 OPEL"); //Antes era PR23 OPEL
            Sintax.Add(COND);

            SintaxLibre SWTC = new SintaxLibre();
            SWTC.SintaxIzquierda = "SWTC";
            SWTC.lstSintaxDerecha.Add("PR18 PAR1 IDEN PAR2");
            Sintax.Add(SWTC);


            SintaxLibre OPEA = new SintaxLibre();
            OPEA.SintaxIzquierda = "OPEA"; //OPEA
            OPEA.lstSintaxDerecha.Add("IDEN OPAR IDEN"); //IDEN OPAR IDEN
            OPEA.lstSintaxDerecha.Add("CONU OPAR CONU"); //CONU OPAR CONU
            OPEA.lstSintaxDerecha.Add("CONU OPAR IDEN"); //CONU OPAR IDEN
            OPEA.lstSintaxDerecha.Add("IDEN OPAR CONU"); //IDEN OPAR CONU
            OPEA.lstSintaxDerecha.Add("OPEA OPAR IDEN");//OPEA OPAR IDEN
            OPEA.lstSintaxDerecha.Add("IDEN OPAR OPEA"); //IDEN OPAR OPEA
            OPEA.lstSintaxDerecha.Add("OPEA OPAR OPEA"); //OPEA OPAR OPEA
            OPEA.lstSintaxDerecha.Add("CONU OPAR OPEA"); //CONU OPAR OPEA
            OPEA.lstSintaxDerecha.Add("OPEA OPAR CONU"); //OPEA OPAR CONU
            OPEA.lstSintaxDerecha.Add("PAR1 OPEA PAR2"); //Antes era PAR2 OPEA PAR1
            OPEA.lstSintaxDerecha.Add("FNCI OPAR CONU"); //FNCI OPAR CONU
            OPEA.lstSintaxDerecha.Add("FNCI OPAR OPEA"); //FNCI OPAR OPEA
            Sintax.Add(OPEA);

            SintaxLibre OPEL = new SintaxLibre();
            OPEL.SintaxIzquierda = "OPEL"; //OPEL
            OPEL.lstSintaxDerecha.Add("OL03 OPER"); //OL03 OPER
            OPEL.lstSintaxDerecha.Add("OL03 OPEL"); //OL03 OPEL
            OPEL.lstSintaxDerecha.Add("OPER OL02 OPER"); //OPER OL02 OPER
            OPEL.lstSintaxDerecha.Add("OPER OL01 OPER"); //OPER OL01 OPER
            OPEL.lstSintaxDerecha.Add("OPEL OL02 OPER"); //OPEL OL02 OPER
            OPEL.lstSintaxDerecha.Add("OPEL OL01 OPER"); //OPEL OL01 OPER
            OPEL.lstSintaxDerecha.Add("OPER OL02 OPEL"); //OPER OL02 OPEL
            OPEL.lstSintaxDerecha.Add("OPER OL01 OPEL"); //OPER OL01 OPEL
            OPEL.lstSintaxDerecha.Add("OPEL OL02 OPEL"); //OPEL OL02 OPEL
            OPEL.lstSintaxDerecha.Add("OPEL OL01 OPEL"); //OPEL OL01 OPEL
            OPEL.lstSintaxDerecha.Add("PAR1 OPEL PAR2"); //Antes era PAR1 OPEL PAR2
            Sintax.Add(OPEL);
            
            SintaxLibre OPRE = new SintaxLibre();
            OPRE.SintaxIzquierda = "OPRE"; //OPRE
            OPRE.lstSintaxDerecha.Add("OPR1"); //OPR1
            OPRE.lstSintaxDerecha.Add("OPR2"); //OPR2
            OPRE.lstSintaxDerecha.Add("OPR3"); //OPR3
            OPRE.lstSintaxDerecha.Add("OPR4"); //OPR4
            OPRE.lstSintaxDerecha.Add("OPR5"); //OPR5
            OPRE.lstSintaxDerecha.Add("OPR6"); //OPR6
            Sintax.Add(OPRE);
        }
    }
}
