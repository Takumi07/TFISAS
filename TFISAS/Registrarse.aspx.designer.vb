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


Partial Public Class Registrarse
    
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
    '''Control lbl_password.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_password As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rev_passwordd.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rev_passwordd As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_password.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_password As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_ConfirmarPassword.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_ConfirmarPassword As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rev_confirmarpassword.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rev_confirmarpassword As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_confirmarPassword.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_confirmarPassword As Global.System.Web.UI.WebControls.TextBox
    
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
    '''Control txt_nombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_nombre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_apellido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_apellido As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_Apellido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_Apellido As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_apellido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_apellido As Global.System.Web.UI.WebControls.TextBox
    
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
    '''Control txt_DNI.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_DNI As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_FechaNacimiento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_FechaNacimiento As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_FechaNacimiento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_FechaNacimiento As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_FechaNacimiento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_FechaNacimiento As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_Telefono.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Telefono As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_Telefono.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_Telefono As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control rv_telefono.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rv_telefono As Global.System.Web.UI.WebControls.RangeValidator
    
    '''<summary>
    '''Control txt_telefono.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_telefono As Global.System.Web.UI.WebControls.TextBox
    
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
    '''Control lbl_Calle.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Calle As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_Calle.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_Calle As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_calle.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_calle As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_Altura.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Altura As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_Altura.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_Altura As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control rv_txt_altura.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rv_txt_altura As Global.System.Web.UI.WebControls.RangeValidator
    
    '''<summary>
    '''Control txt_altura.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_altura As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_Provincia.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Provincia As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control ddl_Provincia.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Provincia As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control lbl_localidad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_localidad As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_txt_localidad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_txt_localidad As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_localidad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_localidad As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_CodigoPostal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_CodigoPostal As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_CodigoPostal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_CodigoPostal As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control rav_CodioPostal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rav_CodioPostal As Global.System.Web.UI.WebControls.RangeValidator
    
    '''<summary>
    '''Control txt_CodigoPostal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_CodigoPostal As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_Piso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Piso As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_piso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_piso As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control txt_Piso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_Piso As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_Departamento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Departamento As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control rfv_departamento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rfv_departamento As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control rv_txt_departamento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents rv_txt_departamento As Global.System.Web.UI.WebControls.RangeValidator
    
    '''<summary>
    '''Control txt_departamento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_departamento As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control btn_aceptar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_aceptar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btn_Cancelar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_Cancelar As Global.System.Web.UI.WebControls.Button
End Class
