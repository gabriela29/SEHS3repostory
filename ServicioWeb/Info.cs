//  Info.cs : Libreria para consultas de Dni(s) de Peru con Reniec
//            Desventaja: tener que actualizar la libreria 
//                        cuando cambio la extructura de la pagina de reniec
//  Author:
//       .::IT::. <elmaildeit@gmail.com>
//  
//  Copyright (c) 2010 

using System;
using System.Drawing;
using System.Net;
using System.IO;

namespace LibReniec
{
    public class Info
    {
        public enum Resul
        {
            /// <summary>
            /// Se encontro la persona
            /// </summary>
            Ok = 0,
            /// <summary>
            /// No se encontro la persona
            /// </summary>
            NoResul = 1,
            /// <summary>
            /// la imagen capcha no es valida
            /// </summary>
            ErrorCapcha = 2, 
            /// <summary>
            /// Error no especificado
            /// </summary>
            Error=3,
        }

        private Resul myResul; 
        private string _Nombres;
        private string _ApePaterno;
        private string _ApeMaterno;
        private CookieContainer myCookie;

        #region Propiedades

        /// <summary>
        /// Devuelve la imagen para el reto capcha
        /// </summary>
        public Image GetCapcha { get { return ReadCapcha(); } }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve los nombres 
        /// de la persona caso contrario devuelve ""
        /// </summary>
        public string Nombres { get { return _Nombres; } }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve el Apellido Paterno
        /// de la persona caso contrario devuelve ""
        public string ApePaterno { get { return _ApePaterno; } }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve el Apellido Materno
        /// de la persona caso contrario devuelve ""
        public string ApeMaterno { get { return _ApeMaterno; } }

        /// <summary>
        /// Devuelve el resultado de la busqueda de DNI
        /// </summary>
        public Resul GetResul { get { return myResul; } }

        #endregion

        #region Constructor

        public Info()
        {
            try
            {
                myCookie = null; 
                myCookie = new CookieContainer();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ReadCapcha();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// Carga la imagen Capcha
        /// </summary>
        private Image ReadCapcha()
        {
            try
            {
                HttpWebRequest myWenRequest = (HttpWebRequest)WebRequest.Create("https://cel.reniec.gob.pe/valreg/codigo.do");
                myWenRequest.CookieContainer = myCookie;

                myWenRequest.Credentials = CredentialCache.DefaultCredentials;

                HttpWebResponse myWebResponse = (HttpWebResponse)myWenRequest.GetResponse();

                Stream myImgStream = myWebResponse.GetResponseStream();

                //myWebResponse.Close();

                return Image.FromStream(myImgStream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inicia la carga de los datos de la persona 
        /// </summary>
        /// <param name="numDni"></param>
        /// <param name="ImgCapcha"></param>
        public void GetInfo(string numDni, string ImgCapcha)
        {
            try
            {
                string line;
                int count = -1;
                string myUrl = String.Format("https://cel.reniec.gob.pe/valreg/valreg.do?accion=buscar&nuDni={0}&imagen={1}",
                                        numDni, ImgCapcha);
                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(myUrl);
                myWebRequest.CookieContainer = myCookie;
                myWebRequest.Credentials = CredentialCache.DefaultCredentials;

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();

                Stream myStream = myHttpWebResponse.GetResponseStream();

                StreamReader myStreamReader = new StreamReader(myStream);
                
                //Comenzar a leer el html devuelvto por el servidor desde la linea 150
                while ((line = myStreamReader.ReadLine()) != null)
                {
                    count++;
                    if (count >= 150)
                    {
                        string tmp = line.Trim();

                        if (tmp != "")
                            tmp = tmp.Substring(0, 4).Trim();   

                        switch (tmp)
                        {
                            case "":
                                myResul = Resul.Ok;
                                break; 
                            case "<tr>":
                                myResul = Resul.NoResul;
                                break;  
                            case "<td":
                                myResul = Resul.ErrorCapcha;
                                break;  
                            default:
                                myResul = Resul.Error;
                                break;  
                        }

                        if (myResul == Resul.Ok)
                        {
                            line = myStreamReader.ReadLine();//linea 151
                            line = myStreamReader.ReadLine();//linea 152

                            this._Nombres = myStreamReader.ReadLine().Trim(); //linea 153
                            this._ApePaterno = myStreamReader.ReadLine().Trim();   //linea 154
                            this._ApeMaterno = myStreamReader.ReadLine().Trim(); //linea 155

                            //para borrar el <br>
                            this._ApeMaterno = this._ApeMaterno.Substring(0, this._ApeMaterno.Length - 4);
                            break;
                        }
                        else
                            break; 
                    }
                }

                myHttpWebResponse.Close();   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
