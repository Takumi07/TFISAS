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


Partial Public Class AgregarRemito
    
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
    '''Control lbl_AgregarRemito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_AgregarRemito As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lbl_NRemito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_NRemito As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_nroremito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_nroremito As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control rav_nroRemito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rav_nroRemito As Global.System.Web.UI.WebControls.RangeValidator
    
    '''<summary>
    '''Control txt_nroRemito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_nroRemito As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_FechaRemito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_FechaRemito As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_FechaRemito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_FechaRemito As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_FechaRemito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_FechaRemito As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_Proveedor.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Proveedor As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control ddl_Proveedor.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Proveedor As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control lbl_Producto.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Producto As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control ddl_Producto.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Producto As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control lbl_Cantidad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Cantidad As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_cantidad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_cantidad As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control rav_txt_cantidad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rav_txt_cantidad As Global.System.Web.UI.WebControls.RangeValidator
    
    '''<summary>
    '''Control rev_precioVenta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rev_precioVenta As Global.System.Web.UI.WebControls.RegularExpressionValidator
    
    '''<summary>
    '''Control txt_cantidad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_cantidad As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control btn_agregar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_agregar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control gv_Remito.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents gv_Remito As Global.System.Web.UI.WebControls.GridView
    
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
