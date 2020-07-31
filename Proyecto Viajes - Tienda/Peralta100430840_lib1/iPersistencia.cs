using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peralta100430840_lib1.IOAqui
{
    interface iPersistencia
    {
        bool Grabar();
        bool Leer();
        bool Buscar(string p_str_lobuscado);
        string getMensaje();
    }
}
