using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildLab
{
    internal class Sessao
    {
        public static User UtilizadorAtual { get; set; }
        public static bool TerminandoSessao { get; set; } = false;
    }
}
