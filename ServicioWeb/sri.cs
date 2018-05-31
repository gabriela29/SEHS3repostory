using System;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using System.Data;

namespace ServicioWeb
{
    public class sri
    {
        //Class.DB.ConectSFE db;
        SqlDataReader datosfact, datosdetfact;

        public string claveAcceso(string cod_colegio, string id_comprobante, string tipo_ambiente, string tipo_emision, string fec_emision, string ruc, string serie, string secuencial)
        {
            //GENERA CÓDIGO NUMERICO
            long codigo = 1;
            int aux = 1, total = 0, modulo11 = 0;
            int[] code = { 7, 1, 7, 2, 7, 3, 7, 4, 7, 5 };
            int[] codemodulo = { 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            if (serie[2] <= '0') aux = 2;
            else aux = 3;

            for (var i = 0; i < code.Length; i++)
            {
                if (ruc[i] != '0') codigo = (codigo * (code[i] * Convert.ToInt32(ruc[i] + string.Empty) * aux)) + Convert.ToInt32(cod_colegio) * 7;
            }
            
            //COMPONE CLAVE 48 DÍGITOS
            //com = new AutoCompleta();
            string clave = fec_emision.Substring(0, 2) + fec_emision.Substring(3, 2) + fec_emision.Substring(6, 4) + id_comprobante + ruc + tipo_ambiente + serie + secuencial + Convert.ToString(codigo).Substring(1, 8) + tipo_emision;
             
            for (var i = 0; i < codemodulo.Length; i++)
            {
                total = total + (codemodulo[i] * Convert.ToInt32(clave[i] + string.Empty));
            }
            modulo11 = 11 - (total % 11);

            //COLOCA DÍGITO VERIFICADOR
            if (modulo11 == 10) return clave + "1";
            else if (modulo11 == 11) return clave + "0";
            else return clave + modulo11.ToString();
        }


        public void GeneraXMLFactura(string num_estab_fact, string p_fact, string secuencial_fact, DataTable dtCab, DataTable dtDet)
        {
            //GENERA XML DE FACTURA
            XmlTextWriter wr = new XmlTextWriter(@"C:\DocumentosElectrónicos\Facturas\factnosigned.xml", Encoding.GetEncoding("UTF-8"));
            wr.WriteStartDocument(true);
            wr.Formatting = Formatting.Indented;
            wr.Indentation = 2;

            wr.WriteStartElement("factura");

            wr.WriteStartAttribute("id");
            wr.WriteString("comprobante");
            wr.WriteEndAttribute();

            wr.WriteStartAttribute("version");
            wr.WriteString("1.0.0");
            wr.WriteEndAttribute();

            //OBTIENE DATOS DE FACTURA

            while (datosfact.Read())
            {
                wr.WriteStartElement("infoTributaria");

                wr.WriteStartElement("ambiente");
                wr.WriteString(datosfact["cod_tipo_ambiente"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("tipoEmision");
                wr.WriteString(datosfact["cod_tipo_emision"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("razonSocial");
                wr.WriteString(datosfact["cod_ruc"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("nombreComercial");
                wr.WriteString(datosfact["cod_colegio"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("ruc");
                wr.WriteString(datosfact["cod_ruc"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("claveAcceso");
                wr.WriteString(datosfact["clave_acceso"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("codDoc");
                wr.WriteString("01");
                wr.WriteEndElement();

                wr.WriteStartElement("estab");
                wr.WriteString(num_estab_fact);
                wr.WriteEndElement();

                wr.WriteStartElement("ptoEmi");
                wr.WriteString(p_fact);
                wr.WriteEndElement();

                wr.WriteStartElement("secuencial");
                wr.WriteString(secuencial_fact);
                wr.WriteEndElement();

                wr.WriteStartElement("dirMatriz");
                wr.WriteString(datosfact["dirMatriz"].ToString());
                wr.WriteEndElement();

                wr.WriteEndElement();

                wr.WriteStartElement("infoFactura");

                wr.WriteStartElement("fechaEmision");
                wr.WriteString(datosfact["fecha_emision"].ToString().Substring(0, 10));
                wr.WriteEndElement();

                wr.WriteStartElement("dirEstablecimiento");
                wr.WriteString(datosfact["dirEstablecimiento"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("contribuyenteEspecial");
                wr.WriteString(datosfact["cod_ruc"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("obligadoContabilidad");
                wr.WriteString(datosfact["cod_ruc"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("tipoIdentificacionComprador");
                wr.WriteString(datosfact["cod_responsable"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("razonSocialComprador");
                wr.WriteString(datosfact["cod_responsable"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("identificacionComprador");
                wr.WriteString(datosfact["cod_responsable"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("totalSinImpuestos");
                wr.WriteString(string.Format("{0:0.00}", Convert.ToDouble(datosfact["total_sinImpuesto"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("totalDescuento");
                wr.WriteString(string.Format("{0:0.00}", Convert.ToDouble(datosfact["total_descuento"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("totalConImpuestos");
                //SUMA DETALLE SEGÚN TIPO DE IVA
                SumTipoImpuestoIVA(wr, num_estab_fact, p_fact, secuencial_fact);

                wr.WriteEndElement();

                wr.WriteStartElement("propina");
                wr.WriteString(string.Format("{0:0.00}", Convert.ToDouble(datosfact["propina_10"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("importeTotal");
                wr.WriteString(string.Format("{0:0.00}", Convert.ToDouble(datosfact["valorTotal"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("moneda");
                wr.WriteString("DOLAR");
                wr.WriteEndElement();

                wr.WriteEndElement();

                wr.WriteStartElement("detalles");
                //GENERA DETALLE DE FACTURA
                CreaDetalleFactura(wr, num_estab_fact, p_fact, secuencial_fact);

                wr.WriteEndElement();

                wr.WriteStartElement("infoAdicional");

                //INFO ADICIONAL
                wr.WriteStartElement("campoAdicional");
                wr.WriteStartAttribute("nombre");
                wr.WriteString("Dirección: ");
                wr.WriteEndAttribute();
                wr.WriteString(datosfact["cod_responsable"].ToString());
                wr.WriteEndElement();

                //INFO ADICIONAL
                wr.WriteStartElement("campoAdicional");
                wr.WriteStartAttribute("nombre");
                wr.WriteString("Teléfono: ");
                wr.WriteEndAttribute();
                wr.WriteString(datosfact["cod_responsable"].ToString());
                wr.WriteEndElement();

                //INFO ADICIONAL
                wr.WriteStartElement("campoAdicional");
                wr.WriteStartAttribute("nombre");
                wr.WriteString("E-mail: ");
                wr.WriteEndAttribute();
                wr.WriteString(datosfact["cod_responsable"].ToString());
                wr.WriteEndElement();

                //INFO ADICIONAL
                wr.WriteStartElement("campoAdicional");
                wr.WriteStartAttribute("nombre");
                wr.WriteString("Periodo Lectivo: ");
                wr.WriteEndAttribute();
                wr.WriteString(datosfact["cod_periodo"].ToString());
                wr.WriteEndElement();

                wr.WriteEndElement();
            }
            //datosfact.Close();
            //db.Desconectar();

            wr.WriteEndElement();

            wr.WriteEndDocument();
            wr.Close();
        }

        public void SumTipoImpuestoIVA(XmlTextWriter wr, string num_estab_fact, string p_fact, string secuencial_fact)
        {
            //OBTIENE DATOS DE DETALLE DE FACTURA SEGÚN TIPO DE IVA
            //db = new DB.ConectSFE();
            //db.Conectar();
            //db.SqlComando("Select cod_tarifa_iva, baseImponible=(SUM(subtotal_0) + SUM(subtotal_12)), valoriva12=SUM(iva_12) from Facturas_Detalle where cod_factura='" + num_estab_fact + p_fact + secuencial_fact + "' group by cod_tarifa_iva");
            //datosdetfact = db.SqlComandoEjecutar();
            while (datosdetfact.Read())
            {
                wr.WriteStartElement("totalImpuesto");

                wr.WriteStartElement("codigo");
                wr.WriteString("2");
                wr.WriteEndElement();

                wr.WriteStartElement("codigoPorcentaje");
                wr.WriteString(datosdetfact["cod_tarifa_iva"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("baseImponible");
                wr.WriteString(string.Format("{0:0.00}", Convert.ToDouble(datosdetfact["baseImponible"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("valor");
                wr.WriteString(string.Format("{0:0.00}", Convert.ToDouble(datosdetfact["valoriva12"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteEndElement();
            }
        }

        public void CreaDetalleFactura(XmlTextWriter wr, string num_estab_fact, string p_fact, string secuencial_fact)
        {
            //OBTIENE DATOS DE DETALLE DE FACTURA
            //db = new DB.ConectSFE();
            //db.Conectar();
            //db.SqlComando("Select * from Facturas_Detalle a, Tarifa_IVA b where a.cod_factura='" + num_estab_fact + p_fact + secuencial_fact + "' and a.cod_tarifa_iva=b.cod_tarifa_iva order by a.cod_item, a.cod_auxiliar");
            //datosdetfact = db.SqlComandoEjecutar();
            while (datosdetfact.Read())
            {
                wr.WriteStartElement("detalle");

                wr.WriteStartElement("codigoPrincipal");
                wr.WriteString(datosdetfact["cod_item"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("codigoAuxiliar");
                wr.WriteString(datosdetfact["cod_auxiliar"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("descripcion");
                wr.WriteString(datosdetfact["descripcion"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("cantidad");
                wr.WriteString(String.Format("{0:0.00}", Convert.ToDouble(datosdetfact["cantidad"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("precioUnitario");
                wr.WriteString(String.Format("{0:0.00}", Convert.ToDouble(datosdetfact["valor_unitario"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("descuento");
                wr.WriteString(String.Format("{0:0.00}", Convert.ToDouble(datosdetfact["descuento"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("precioTotalSinImpuesto");
                wr.WriteString(String.Format("{0:0.00}", Convert.ToDouble(datosdetfact["subtotal_0"].ToString()) + Convert.ToDouble(datosdetfact["subtotal_12"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                //DETALLES ADICIONALES
                if (datosdetfact["descripcion2"].ToString() != string.Empty || datosdetfact["descripcion3"].ToString() != string.Empty)
                {
                    wr.WriteStartElement("detallesAdicionales");

                    //DETALLE ADICIONAL
                    if (datosdetfact["descripcion2"].ToString() != string.Empty)
                    {
                        wr.WriteStartElement("detAdicional");

                        wr.WriteStartAttribute("nombre");
                        wr.WriteString(datosdetfact["descripcion2"].ToString());
                        wr.WriteStartAttribute("valor");
                        wr.WriteString("Detalle1");
                        wr.WriteEndAttribute();

                        wr.WriteEndElement();
                    }

                    //DETALLE ADICIONAL
                    if (datosdetfact["descripcion3"].ToString() != string.Empty)
                    {
                        wr.WriteStartElement("detAdicional");

                        wr.WriteStartAttribute("nombre");
                        wr.WriteString(datosdetfact["descripcion3"].ToString());
                        wr.WriteStartAttribute("valor");
                        wr.WriteString("Detalle2");
                        wr.WriteEndAttribute();

                        wr.WriteEndElement();
                    }

                    wr.WriteEndElement();
                }

                wr.WriteStartElement("impuestos");

                wr.WriteStartElement("impuesto");

                wr.WriteStartElement("codigo");
                wr.WriteString(datosdetfact["cod_iva"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("codigoPorcentaje");
                wr.WriteString(datosdetfact["cod_tarifa_iva"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("tarifa");
                wr.WriteString(string.Format("{0:0.00}", Convert.ToDouble(datosdetfact["valor"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("baseImponible");
                wr.WriteString(String.Format("{0:0.00}", Convert.ToDouble(datosdetfact["subtotal_0"].ToString()) + Convert.ToDouble(datosdetfact["subtotal_12"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("valor");
                wr.WriteString(string.Format("{0:0.00}", Convert.ToDouble(datosdetfact["iva_12"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteEndElement();

                wr.WriteEndElement();

                wr.WriteEndElement();
            }
            //datosdetfact.Close();
            //db.Desconectar();
        }

        public void GeneraXMLNotaCredito(string num_estab_fact, string p_fact, string secuencial_fact)
        {
            //GENERA XML DE FACTURA
            XmlTextWriter wr = new XmlTextWriter(@"C:\DocumentosElectrónicos\NotasCredito\factnosigned.xml", Encoding.GetEncoding("UTF-8"));
            wr.WriteStartDocument(true);
            wr.Formatting = Formatting.Indented;
            wr.Indentation = 2;

            wr.WriteStartElement("notaCredito");

            wr.WriteStartAttribute("id");
            wr.WriteString("comprobante");
            wr.WriteEndAttribute();

            wr.WriteStartAttribute("version");
            wr.WriteString("1.0.0");
            wr.WriteEndAttribute();

            //OBTIENE DATOS DE NOTA DE CRÉDITO
            //db = new DB.ConectSFE();
            //db.Conectar();
            //db.SqlComando("Select * from NotasCredito where cod_notacredito='" + num_estab_fact + p_fact + secuencial_fact + "' ");
            //datosfact = db.SqlComandoEjecutar();
            while (datosfact.Read())
            {
                wr.WriteStartElement("infoTributaria");

                wr.WriteStartElement("ambiente");
                wr.WriteString(datosfact["cod_tipo_ambiente"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("tipoEmision");
                wr.WriteString(datosfact["cod_tipo_emision"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("razonSocial");
                wr.WriteString(datosfact["cod_ruc"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("nombreComercial");
                wr.WriteString(datosfact["cod_colegio"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("ruc");
                wr.WriteString(datosfact["cod_ruc"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("claveAcceso");
                wr.WriteString(datosfact["clave_acceso"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("codDoc");
                wr.WriteString("04");
                wr.WriteEndElement();

                wr.WriteStartElement("estab");
                wr.WriteString(num_estab_fact);
                wr.WriteEndElement();

                wr.WriteStartElement("ptoEmi");
                wr.WriteString(p_fact);
                wr.WriteEndElement();

                wr.WriteStartElement("secuencial");
                wr.WriteString(secuencial_fact);
                wr.WriteEndElement();

                wr.WriteStartElement("dirMatriz");
                wr.WriteString(datosfact["dirMatriz"].ToString());
                wr.WriteEndElement();

                wr.WriteEndElement();

                wr.WriteStartElement("infoNotaCredito");

                wr.WriteStartElement("fechaEmision");
                wr.WriteString(datosfact["fecha_emision"].ToString().Substring(0, 10));
                wr.WriteEndElement();

                wr.WriteStartElement("dirEstablecimiento");
                wr.WriteString(datosfact["dirEstablecimiento"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("tipoIdentificacionComprador");
                wr.WriteString(datosfact["cod_responsable"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("razonSocialComprador");
                wr.WriteString(datosfact["cod_responsable"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("identificacionComprador");
                wr.WriteString(datosfact["cod_responsable"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("contribuyenteEspecial");
                wr.WriteString(datosfact["cod_ruc"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("obligadoContabilidad");
                wr.WriteString(datosfact["cod_ruc"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("codDocModificado");
                wr.WriteString("01");
                wr.WriteEndElement();

                wr.WriteStartElement("numDocModificado");
                wr.WriteString(datosfact["num_establecimiento_dm"].ToString() + "-" + datosfact["punto_facturacion_dm"].ToString() + "-" + datosfact["secuencial_dm"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("fechaEmisionDocSustento");
                wr.WriteString(datosfact["fecha_emision_dm"].ToString().Substring(0, 10));
                wr.WriteEndElement();

                wr.WriteStartElement("totalSinImpuestos");
                wr.WriteString(string.Format("{0:0.00}", Convert.ToDouble(datosfact["total_sinImpuesto"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("valorModificacion");
                wr.WriteString(string.Format("{0:0.00}", Convert.ToDouble(datosfact["valorTotal"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("moneda");
                wr.WriteString("DOLAR");
                wr.WriteEndElement();

                wr.WriteStartElement("totalConImpuestos");
                //SUMA DETALLE SEGÚN TIPO DE IVA
                SumTipoImpuestoIVANC(wr, num_estab_fact, p_fact, secuencial_fact);

                wr.WriteEndElement();

                wr.WriteStartElement("motivo");
                wr.WriteString(datosfact["motivo"].ToString());
                wr.WriteEndElement();

                wr.WriteEndElement();

                wr.WriteStartElement("detalles");
                //GENERA DETALLE DE FACTURA
                CreaDetalleNotaCredito(wr, num_estab_fact, p_fact, secuencial_fact);

                wr.WriteEndElement();

                wr.WriteStartElement("infoAdicional");

                //INFO ADICIONAL
                wr.WriteStartElement("campoAdicional");
                wr.WriteStartAttribute("nombre");
                wr.WriteString("Dirección: ");
                wr.WriteEndAttribute();
                wr.WriteString(datosfact["cod_responsable"].ToString());
                wr.WriteEndElement();

                //INFO ADICIONAL
                wr.WriteStartElement("campoAdicional");
                wr.WriteStartAttribute("nombre");
                wr.WriteString("Teléfono: ");
                wr.WriteEndAttribute();
                wr.WriteString(datosfact["cod_responsable"].ToString());
                wr.WriteEndElement();

                //INFO ADICIONAL
                wr.WriteStartElement("campoAdicional");
                wr.WriteStartAttribute("nombre");
                wr.WriteString("E-mail: ");
                wr.WriteEndAttribute();
                wr.WriteString(datosfact["cod_responsable"].ToString());
                wr.WriteEndElement();

                wr.WriteEndElement();
            }
            //datosfact.Close();
            //db.Desconectar();

            wr.WriteEndElement();

            wr.WriteEndDocument();
            wr.Close();
        }

        public void SumTipoImpuestoIVANC(XmlTextWriter wr, string num_estab_fact, string p_fact, string secuencial_fact)
        {
            //OBTIENE DATOS DE DETALLE DE NOTA DE CRÉDITO SEGÚN TIPO DE IVA
            //db = new DB.ConectSFE();
            //db.Conectar();
            //db.SqlComando("Select cod_tarifa_iva, baseImponible=(SUM(subtotal_0) + SUM(subtotal_12)), valoriva12=SUM(iva_12) from NotasCredito_Detalle where cod_notacredito='" + num_estab_fact + p_fact + secuencial_fact + "' group by cod_tarifa_iva");
            //datosdetfact = db.SqlComandoEjecutar();
            while (datosdetfact.Read())
            {
                wr.WriteStartElement("totalImpuesto");

                wr.WriteStartElement("codigo");
                wr.WriteString("2");
                wr.WriteEndElement();

                wr.WriteStartElement("codigoPorcentaje");
                wr.WriteString(datosdetfact["cod_tarifa_iva"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("baseImponible");
                wr.WriteString(string.Format("{0:0.00}", Convert.ToDouble(datosdetfact["baseImponible"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("valor");
                wr.WriteString(string.Format("{0:0.00}", Convert.ToDouble(datosdetfact["valoriva12"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteEndElement();
            }
            datosdetfact.Close();
            //db.Desconectar();
        }

        public void CreaDetalleNotaCredito(XmlTextWriter wr, string num_estab_fact, string p_fact, string secuencial_fact)
        {
            //OBTIENE DATOS DE DETALLE DE FACTURA
            //db = new DB.ConectSFE();
            //db.Conectar();
            //db.SqlComando("Select * from NotasCredito_Detalle a, Tarifa_IVA b where a.cod_notacredito='" + num_estab_fact + p_fact + secuencial_fact + "' and a.cod_tarifa_iva=b.cod_tarifa_iva order by a.cod_item, a.cod_auxiliar");
            //datosdetfact = db.SqlComandoEjecutar();
            while (datosdetfact.Read())
            {
                wr.WriteStartElement("detalle");

                wr.WriteStartElement("codigoInterno");
                wr.WriteString(datosdetfact["cod_item"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("codigoAdicional");
                wr.WriteString(datosdetfact["cod_auxiliar"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("descripcion");
                wr.WriteString(datosdetfact["descripcion"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("cantidad");
                wr.WriteString(String.Format("{0:0.00}", Convert.ToDouble(datosdetfact["cantidad"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("precioUnitario");
                wr.WriteString(String.Format("{0:0.00}", Convert.ToDouble(datosdetfact["valor_unitario"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("descuento");
                wr.WriteString(String.Format("{0:0.00}", Convert.ToDouble(datosdetfact["descuento"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("precioTotalSinImpuesto");
                wr.WriteString(String.Format("{0:0.00}", Convert.ToDouble(datosdetfact["subtotal_0"].ToString()) + Convert.ToDouble(datosdetfact["subtotal_12"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                //DETALLES ADICIONALES
                if (datosdetfact["descripcion2"].ToString() != string.Empty || datosdetfact["descripcion3"].ToString() != string.Empty)
                {
                    wr.WriteStartElement("detallesAdicionales");

                    //DETALLE ADICIONAL
                    if (datosdetfact["descripcion2"].ToString() != string.Empty)
                    {
                        wr.WriteStartElement("detAdicional");

                        wr.WriteStartAttribute("nombre");
                        wr.WriteString(datosdetfact["descripcion2"].ToString());
                        wr.WriteStartAttribute("valor");
                        wr.WriteString("Detalle1");
                        wr.WriteEndAttribute();

                        wr.WriteEndElement();
                    }

                    //DETALLE ADICIONAL
                    if (datosdetfact["descripcion3"].ToString() != string.Empty)
                    {
                        wr.WriteStartElement("detAdicional");

                        wr.WriteStartAttribute("nombre");
                        wr.WriteString(datosdetfact["descripcion3"].ToString());
                        wr.WriteStartAttribute("valor");
                        wr.WriteString("Detalle2");
                        wr.WriteEndAttribute();

                        wr.WriteEndElement();
                    }

                    wr.WriteEndElement();
                }

                wr.WriteStartElement("impuestos");

                wr.WriteStartElement("impuesto");

                wr.WriteStartElement("codigo");
                wr.WriteString(datosdetfact["cod_iva"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("codigoPorcentaje");
                wr.WriteString(datosdetfact["cod_tarifa_iva"].ToString());
                wr.WriteEndElement();

                wr.WriteStartElement("tarifa");
                wr.WriteString(string.Format("{0:0.00}", Convert.ToDouble(datosdetfact["valor"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("baseImponible");
                wr.WriteString(String.Format("{0:0.00}", Convert.ToDouble(datosdetfact["subtotal_0"].ToString()) + Convert.ToDouble(datosdetfact["subtotal_12"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteStartElement("valor");
                wr.WriteString(string.Format("{0:0.00}", Convert.ToDouble(datosdetfact["iva_12"].ToString())).Replace(",", "."));
                wr.WriteEndElement();

                wr.WriteEndElement();

                wr.WriteEndElement();

                wr.WriteEndElement();
            }
            //datosdetfact.Close();
            //db.Desconectar();
        }
    }
}
