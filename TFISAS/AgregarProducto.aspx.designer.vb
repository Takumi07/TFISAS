'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class AgregarProducto
    
    '''<summary>
    '''Control divError.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents divError As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control lblMensajeError.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblMensajeError As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lbl_NuevoProducto.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_NuevoProducto As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lbl_Nombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Nombre As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_Nombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_Nombre As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_Nombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_Nombre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_Descripcion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Descripcion As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_Descripcion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_Descripcion As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_descripcion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_descripcion As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_Genero.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Genero As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control ddl_Genero.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Genero As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control lbl_TipoProducto.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_TipoProducto As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control ddl_TipoProducto.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_TipoProducto As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control lbl_FechaSalida.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_FechaSalida As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_txt_fechaSalida.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_txt_fechaSalida As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_FechaSalida.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_FechaSalida As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_FechaArribo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_FechaArribo As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_txt_FechaArribo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_txt_FechaArribo As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_FechaArribo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_FechaArribo As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control chk_Importado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents chk_Importado As Global.System.Web.UI.WebControls.CheckBox
    
    '''<summary>
    '''Control lbl_PrecioVenta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_PrecioVenta As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_PrecioVenta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_PrecioVenta As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control rev_precioVenta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rev_precioVenta As Global.System.Web.UI.WebControls.RegularExpressionValidator
    
    '''<summary>
    '''Control rv_txt_PrecioVenta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rv_txt_PrecioVenta As Global.System.Web.UI.WebControls.RangeValidator
    
    '''<summary>
    '''Control txt_PrecioVenta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_PrecioVenta As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_Imagen.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Imagen As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control FilePhoto.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents FilePhoto As Global.System.Web.UI.WebControls.FileUpload
    
    '''<summary>
    '''Control lbl_Imagen2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Imagen2 As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control FilePhoto2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents FilePhoto2 As Global.System.Web.UI.WebControls.FileUpload
    
    '''<summary>
    '''Control lbl_Imagen3.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Imagen3 As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control FilePhoto3.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents FilePhoto3 As Global.System.Web.UI.WebControls.FileUpload
    
    '''<summary>
    '''Control lbl_Imagen4.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Imagen4 As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control FilePhoto4.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents FilePhoto4 As Global.System.Web.UI.WebControls.FileUpload
    
    '''<summary>
    '''Control btn_Aceptar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_Aceptar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btn_Cancelar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_Cancelar As Global.System.Web.UI.WebControls.Button
End Class
