using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_LUP.Arbol_LUP
{
    public class ETIQUETA_DATA : Nodo_LUP
    {

        String data;
        String data_resuelto;
        public ETIQUETA_DATA(String data)
        {
            this.data = data;
        }
        public override object ejecutar()
        {
            data = data.Replace("[+DATA]", "");
            data = data.Replace("[-DATA]", "");
            data = data.Replace("(CONTENIDODATA)", "");
            data_resuelto = data;
            return this.data_resuelto;
        }
    }
}