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


Partial Public Class ModificarUsuarios
    
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
    '''Control lbl_ModificarUsuario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_ModificarUsuario As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control ListaUsuarios.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ListaUsuarios As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control gv_Usuarios.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents gv_Usuarios As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control modificarusuario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents modificarusuario As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control lbl_NombreUsuario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_NombreUsuario As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_NombreUsuario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_NombreUsuario As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_NombreUsuario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_NombreUsuario As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_correo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_correo As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_Correo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_Correo As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_correo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_correo As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_Nombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Nombre As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_nombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_nombre As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_nombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_nombre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_Apellido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Apellido As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_apellido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_apellido As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_apellido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_apellido As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_Perfil.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Perfil As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control ddl_Perfil.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Perfil As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control lbl_Idioma.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Idioma As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control ddl_idioma.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_idioma As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control chk_editarse.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents chk_editarse As Global.System.Web.UI.WebControls.CheckBox
    
    '''<summary>
    '''Control lbl_DNI.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_DNI As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_dni.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_dni As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control rv_txt_dni.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rv_txt_dni As Global.System.Web.UI.WebControls.RangeValidator
    
    '''<summary>
    '''Control txt_dni.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_dni As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control btn_modificar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_modificar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btn_cancelar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_cancelar As Global.System.Web.UI.WebControls.Button
End Class
