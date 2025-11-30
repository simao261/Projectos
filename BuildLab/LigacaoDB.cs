using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildLab
{
    /// <summary>
    /// Dados de ligação à base de dados.
    /// </summary>
    internal class LigacaoDB
    {

        /// <summary>
        /// Endereço do servidor.
        /// </summary>
        public static string Servidor { get; private set; } = "127.0.0.1";

        /// <summary>
        /// Nome do utilizador.
        /// </summary>
        public static string Utilizador { get; private set; } = "root"; 
        /// <summary>
        /// Password do utilizador.
        /// </summary>
        public static string Password { get; private set; } = ""; 

        /// <summary>
        /// Base de dados a utilizar.
        /// </summary>
        public static string DB { get; private set; } = "buildlab_forms"; 

        /// <summary>
        /// Obter a string de ligação (connection string) ao servidor de base de dados.
        /// </summary>
        public static string GetConnectionString()
        {
            return $"Server={Servidor};Database={DB};Uid={Utilizador};Pwd={Password};Charset=utf8mb4;Port=3306;SslMode=none";
        }
    }
}
