using Karify.Application.Rol.Command.EditarRol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace Karify.Application.Common.Utils
{
    public static class ConvertXMLMapper
    {
        public static string ConvertirPermisosAXml(AsignarPermiso[] permisos)
        {
            var xml = new XElement("Permisos",
                permisos.Select(p =>
                    new XElement("Permiso",
                        new XElement("IdRuta", p.IdRuta)
                    )
                )
            );

            return xml.ToString();
        }
    }
}
