using Almacen.Core.BL.Seguridad.Interfaces;
using Almacen.Core.Helpers;
using Almacen.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Almacen.Core.ViewModels;

namespace Almacen.Core.BL.Seguridad.Services
{
    public class SeguridadService: ISeguridad
    {
        /// Permite crear y validar JSON Web Token.
        /// </summary>
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        /// <summary>
        /// Para la configuración del JSON Web Token.
        /// </summary>
        private readonly JWTSettings _settings;
        /// <summary>
        /// Proporciona la estructura para una llave de seguridad (firma de validación).
        /// </summary>
        private SecurityKey _issuerSigningKey;
        /// <summary>
        /// Envuelve credenciales para generar llave de seguridad (firma de validación).
        /// </summary>
        private SigningCredentials _signingCredentials;
        /// <summary>
        /// Permite envolver un objeto JSON el cual podrá ser validado como JSON Web Token. Contiene los Headers Parameter Names.
        /// </summary>
        private JwtHeader _jwtHeader;
        /// <summary>
        /// Contiene los parámetros utilizados para la validación de un JSON Web Token.
        /// </summary>
        public TokenValidationParameters Parametros { get; private set; }
        #region constructor
        /// </summary>
        /// <param name="settings">Configuración inicial para el JSON Web Token.</param>
        public SeguridadService(IOptions<JWTSettings> settings)
        {
            _settings = settings.Value;
            InicializarHmac();
            InicializarJWTParametros();
        }
        #endregion

        #region Metodos
        private void InicializarHmac()
        {
            _issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            _signingCredentials = new SigningCredentials(_issuerSigningKey, SecurityAlgorithms.HmacSha256);
        }
        /// Inicializa los parametros para el objeto JWT.
        /// </summary>
        private void InicializarJWTParametros()
        {
            _jwtHeader = new JwtHeader(_signingCredentials);
            Parametros = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidIssuer = _settings.Issuer,
                IssuerSigningKey = _issuerSigningKey
            };
        }
        #endregion
        /// Inicializa los objetos _issuerSigningKey y _signingCredentials con el sistema de cifrado HMAC.
        /// </summary>
        public async Task<bool> VerificaConexion()
        {
            using (var conexion = new InventarioDbContext())
            {
                var consulta = await(from e in conexion.TipoArticulos select e).CountAsync();
                if (consulta > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<ResultadoLoginViewModel> AutentificacionUsuario(LoginViewModel usuario)
        {
            using (var Conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                var resultado = new ResultadoLoginViewModel() { Exito = false, Mensaje = "Existe un error en Servidor" };
                try
                {
                    var comando = new SqlCommand();
                    comando.Connection = Conexion;
                    comando.CommandText = "Seguridad.Authenticacion";
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    /*Agregando los parametros*/
                    comando.Parameters.AddWithValue("@usuario", usuario.Username.Trim());
                    comando.Parameters.AddWithValue("@pass", usuario.Password.Trim());
                    Conexion.Open();
                    var Lectura = await comando.ExecuteReaderAsync();
                    if (Lectura.HasRows)
                    {
                        while (Lectura.Read())
                        {
                            resultado.Exito = Lectura.GetBoolean(0);
                            resultado.Mensaje = Lectura.GetString(1);
                            resultado.NombreUsuario = Lectura.GetString(2);
                            resultado.Rol = Lectura.GetString(3);
                            resultado.IdUsuario = Lectura.GetGuid(4);
                            resultado.UserName = Lectura.GetString(5);
                            resultado.RFC = Lectura.GetString(6);
                            resultado.CodigoPuesto = Lectura.GetString(7);
                        }
                    }
                    Conexion.Close();
                    return resultado;

                }
                catch (Exception e)
                {
                    var m = e.Message.ToString();
                    return resultado;
                }
            }
        }

        public Task<bool> RegistrarHistorial(string opcion, string idUser, string detalles)
        {
            throw new NotImplementedException();
        }

        public async Task<JWTViewModel> GenerarToken(ResultadoLoginViewModel resultado)
        {
            var nombreUsuarioToken = Crypto.EncryptStringAES(resultado.NombreUsuario);
            var idUsuarioToken = Crypto.EncryptStringAES($"{resultado.IdUsuario}," +
                                                        $"{resultado.RFC}");
            //var rolToken = Crypto.EncryptStringAES(usuario.Nombre);
            //Boolean adm = usuario.Administrador;
            var nowUtc = DateTime.UtcNow;
            var expires = nowUtc.AddMinutes(_settings.Expire);
            var centuryBegin = new DateTime(1970, 1, 1);
            var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);
            var now = (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalSeconds);
            var issuer = _settings.Issuer ?? string.Empty;
            //String[] roles = {usuario.Nombre };
            //Boolean exito = usuario.Exito;
            var payload = new JwtPayload
            {
                {"sub", nombreUsuarioToken},
                {"unique_name", idUsuarioToken},
                {"rol", resultado.Rol },
                {"iss", issuer},
                {"iat", now},
                {"nbf", now},
                {"exp", exp},
                //{"roles",roles },
                //{"exito", exito },
                //{"administrador", adm },
                {"jti", Guid.NewGuid().ToString("N")}
            };
            var jwt = new JwtSecurityToken(_jwtHeader, payload);
            var token = _jwtSecurityTokenHandler.WriteToken(jwt);
            return new JWTViewModel
            {
                Token = token,
                Expires = exp,
                IdUsuario = resultado.IdUsuario,
                NombreUsuario = resultado.NombreUsuario,
                Rol = resultado.Rol,
                UserName = resultado.UserName,
                RFC = resultado.RFC,
                CodigoPuesto = resultado.CodigoPuesto,
                Exito = resultado.Exito,
                Mensaje = resultado.Mensaje
            };
        }
    }
}
