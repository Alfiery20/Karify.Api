using Karify.Application.Rol.Command.AgregarRol;
using System.Xml.Linq;

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
