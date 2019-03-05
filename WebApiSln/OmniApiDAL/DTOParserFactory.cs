using OmniApiDTO;
using OmniApiDTO.DTOParsers;
using System;
using System.Diagnostics;

namespace OmniApiDAL
{
    internal static class DTOParserFactory
    {
        internal static DTOParser GetParser(System.Type DTOType)
        {
            switch (DTOType.Name)
            {
                /*************************************************
                 *         PONER EN ORDEN ALFABETICA             *
                 ************************************************/

                case "Usuarios":
                    return new DTOParserUser();

            }
            Trace.WriteLine("BrokenAggregator ; DTOParseFactory; Tipo del DTO desconocido."); //EN CASO DEL QUE EL OBJETO NO EXISTA LLEGARA A MOSTRAR ESTE ERROR EN LA TRAZA DE ERRORES
            throw new Exception("Tipo del DTO desconocido."); //GENERA LA EXCEPCION. 
        }
    }
}
