Imports System.Web.UI.Page

''' -----------------------------------------------------------------------------
''' Project	 : VAKItfUsrWeb
''' Class	 : VAKUtl
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Biblioteca de funcoes de apoio as tela do VAK
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
'''   Criacao : Clever Anjos
''' Copyright : SWB Soluções
'''          1.0.0 - 02/12/2003 - Clever
'''          1.0.1 - 29/12/2003 - Clever - otimizando algumas funções e correcao na funcao funSetErr
'''          1.0.2 - 29/12/2003 - Gutierrez - nova função funRetTxtSemCod
'''          1.0.3 - 08/01/2004 - Clever - Correcao de bug na funXMLArray quando é passado um xml sem dados
'''          1.0.4 - 13/04/2004 - Ricardo - Adaptação para o projeto VAK
'''          1.0.5 - 14/12/2004 - Getulio de Morais Pereira [getulio.m.pereira@treynet.com.br]
'''                             - Inclusao de constante 'pprVlrMnmPvtAvl' para uso em Aprovacao Automatica de RCA
''' </history>
''' -----------------------------------------------------------------------------
Public Class VAKUtl
    Private GrpDdoEst As DataSet
    Private GrpDdoBco As DataSet
    Private GrpDdoSgmMcd As DataSet
    Private GrpDdoGerVnd As DataSet
    Private GrpDdoCtn As DataSet
    Private GrpDdoAvl As DataSet
    Private GrpDdoTet As DataSet
    Private GrpDdoRstPva As DataSet
    Private sCodGerMcd As String
    Private sNomGerMcd As String
    Private sCodGerVnd As String
    Private sNomGerVnd As String
    Private sDigAgeBco As String
    Private sNumReqCttRep As String
    Private sCodEst As String
    Private sCodEstCshReg As String
    Private sCodCid As String
    Private sCodBai As String
    Private sCodBco As String
    Private sCodCplBai As String
    Private sCodAgeBco As String
    Private sCodSgmMcd As String
    Private sCodStaDoc As String
    Private sCodSitRep As String
    Private sCodRegCob As String
    Private sTipRep As String
    Private sCodGerTrp As String
    Private sCodGrpVndRep As String
    Private GrpDdoAcePnd As DataSet
    Private GrpDdoAcoTrb As DataSet
    Private GrpDdoUltMes As DataSet
    Private GrpDdoVlrVndTet As DataSet

#Region "--> Armazena mensagem : Candidato ja foi representante Martins. "
    Private sMsgRep As String
    Public Property pprMsgRep() As String
        Get
            Return sMsgRep
        End Get
        Set(ByVal Value As String)
            sMsgRep = Value
        End Set
    End Property
#End Region

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Valor minimo definido no aproveitamento de uma dada avaliacao.
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' Armazena o valor minimo definido para as notas obtidas em avaliacoes do Formar.
    ''' Utilizado para Aprovacao Automatica de RCAs.
    ''' </remarks>
    ''' <history>
    ''' 	[Getulio de Morais Pereira]	12/20/2004	getulio.m.pereira@treynet.com.br Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property pprVlrMnmPvtAvl() As String
        Get
            Return 60
        End Get
    End Property

    Public Sub funLimpaObj()
        sMsgRep = ""
        sCodGerMcd = ""
        sNomGerMcd = ""
        sCodGerVnd = ""
        sNomGerVnd = ""
        sDigAgeBco = ""
        sNumReqCttRep = ""
        sCodEst = ""
        sCodEstCshReg = ""
        sCodCid = ""
        sCodBai = ""
        sCodBco = ""
        sCodCplBai = ""
        sCodAgeBco = ""
        sCodSgmMcd = ""
        sCodStaDoc = ""
        sCodSitRep = ""
        sCodRegCob = ""
        sTipRep = ""
        sCodGerTrp = ""
        sCodGrpVndRep = ""
        GrpDdoEst = Nothing
        GrpDdoBco = Nothing
        GrpDdoSgmMcd = Nothing
        GrpDdoGerVnd = Nothing
        GrpDdoCtn = Nothing
        GrpDdoAvl = Nothing
        GrpDdoTet = Nothing
        GrpDdoRstPva = Nothing
        GrpDdoAcePnd = Nothing
        GrpDdoAcoTrb = Nothing
        GrpDdoUltMes = Nothing
        GrpDdoVlrVndTet = Nothing
    End Sub

    Public Property pprGrpDdoEst() As DataSet
        Get
            Return GrpDdoEst
        End Get
        Set(ByVal Value As DataSet)
            GrpDdoEst = Value
        End Set
    End Property

    Public Property pprGrpDdoBco() As DataSet
        Get
            Return GrpDdoBco
        End Get
        Set(ByVal Value As DataSet)
            GrpDdoBco = Value
        End Set
    End Property

    Public Property pprGrpDdoSgmMcd() As DataSet
        Get
            Return GrpDdoSgmMcd
        End Get
        Set(ByVal Value As DataSet)
            GrpDdoSgmMcd = Value
        End Set
    End Property

    Public Property pprGrpDdoGerVnd() As DataSet
        Get
            Return GrpDdoGerVnd
        End Get
        Set(ByVal Value As DataSet)
            GrpDdoGerVnd = Value
        End Set
    End Property

    Public Property pprGrpDdoCtn() As DataSet
        Get
            Return GrpDdoCtn
        End Get
        Set(ByVal Value As DataSet)
            GrpDdoCtn = Value
        End Set
    End Property

    Public Property pprGrpDdoAvl() As DataSet
        Get
            Return GrpDdoAvl
        End Get
        Set(ByVal Value As DataSet)
            GrpDdoAvl = Value
        End Set
    End Property

    Public Property pprGrpDdoTet() As DataSet
        Get
            Return GrpDdoTet
        End Get
        Set(ByVal Value As DataSet)
            GrpDdoTet = Value
        End Set
    End Property

    Public Property pprGrpDdoRstPva() As DataSet
        Get
            Return GrpDdoRstPva
        End Get
        Set(ByVal Value As DataSet)
            GrpDdoRstPva = Value
        End Set
    End Property

    Public Property pprCodGerMcd() As String
        Get
            Return sCodGerMcd
        End Get
        Set(ByVal Value As String)
            sCodGerMcd = Value
        End Set
    End Property

    Public Property pprNomGerMcd() As String
        Get
            Return sNomGerMcd
        End Get
        Set(ByVal Value As String)
            sNomGerMcd = Value
        End Set
    End Property

    Public Property pprCodGerVnd() As String
        Get
            Return sCodGerVnd
        End Get
        Set(ByVal Value As String)
            sCodGerVnd = Value
        End Set
    End Property

    Public Property pprNomGerVnd() As String
        Get
            Return sNomGerVnd
        End Get
        Set(ByVal Value As String)
            sNomGerVnd = Value
        End Set
    End Property

    Public Property pprDigAgeBco() As String
        Get
            Return sDigAgeBco
        End Get
        Set(ByVal Value As String)
            sDigAgeBco = Value
        End Set
    End Property

    Public Property pprNumReqCttRep() As String
        Get
            Return sNumReqCttRep
        End Get
        Set(ByVal Value As String)
            sNumReqCttRep = Value
        End Set
    End Property

    Public Property pprCodEst() As String
        Get
            Return sCodEst
        End Get
        Set(ByVal Value As String)
            sCodEst = Value
        End Set
    End Property

    Public Property pprCodEstCshReg() As String
        Get
            Return sCodEstCshReg
        End Get
        Set(ByVal Value As String)
            sCodEstCshReg = Value
        End Set
    End Property

    Public Property pprCodCid() As String
        Get
            Return sCodCid
        End Get
        Set(ByVal Value As String)
            sCodCid = Value
        End Set
    End Property

    Public Property pprCodBai() As String
        Get
            Return sCodBai
        End Get
        Set(ByVal Value As String)
            sCodBai = Value
        End Set
    End Property

    Public Property pprCodBco() As String
        Get
            Return sCodBco
        End Get
        Set(ByVal Value As String)
            sCodBco = Value
        End Set
    End Property

    Public Property pprCodCplBai() As String
        Get
            Return sCodCplBai
        End Get
        Set(ByVal Value As String)
            sCodCplBai = Value
        End Set
    End Property
    ' /**
    '  * Digito Verificador de uma Agencia Bancaria
    '  * Valor default, segundo definicao do BD = ' '
    '  * Alteracao : 15/12/2004
    '  * Autor : Getulio de Morais Pereira [getulio.m.pereira@treynet.com.br]
    '  */
    Public Property pprCodAgeBco() As String
        Get
            Return sCodAgeBco
        End Get
        Set(ByVal Value As String)
            sCodAgeBco = Value
        End Set
    End Property

    Public Property pprCodSgmMcd() As String
        Get
            Return sCodSgmMcd
        End Get
        Set(ByVal Value As String)
            sCodSgmMcd = Value
        End Set
    End Property

    Public Property pprCodStaDoc() As String
        Get
            Return sCodStaDoc
        End Get
        Set(ByVal Value As String)
            sCodStaDoc = Value
        End Set
    End Property

    Public Property pprCodSitRep() As String
        Get
            Return sCodSitRep
        End Get
        Set(ByVal Value As String)
            sCodSitRep = Value
        End Set
    End Property

    Public Property pprCodRegCob() As String
        Get
            Return sCodRegCob
        End Get
        Set(ByVal Value As String)
            sCodRegCob = Value
        End Set
    End Property

    Public Property pprTipRep() As String
        Get
            Return sTipRep
        End Get
        Set(ByVal Value As String)
            sTipRep = Value
        End Set
    End Property

    Public Property pprCodGerTrp() As String
        Get
            Return sCodGerTrp
        End Get
        Set(ByVal Value As String)
            sCodGerTrp = Value
        End Set
    End Property

    Public Property pprCodGrpVndRep() As String
        Get
            Return sCodGrpVndRep
        End Get
        Set(ByVal Value As String)
            sCodGrpVndRep = Value
        End Set
    End Property

    Public Property pprGrpDdoAcePnd() As DataSet
        Get
            Return GrpDdoAcePnd
        End Get
        Set(ByVal Value As DataSet)
            GrpDdoAcePnd = Value
        End Set
    End Property

    Public Property pprGrpDdoAcoTrb() As DataSet
        Get
            Return GrpDdoAcoTrb
        End Get
        Set(ByVal Value As DataSet)
            GrpDdoAcoTrb = Value
        End Set
    End Property

    Public Property pprGrpDdoUltMes() As DataSet
        Get
            Return GrpDdoUltMes
        End Get
        Set(ByVal Value As DataSet)
            GrpDdoUltMes = Value
        End Set
    End Property

    Public Property pprGrpDdoVlrVndTet() As DataSet
        Get
            Return GrpDdoVlrVndTet
        End Get
        Set(ByVal Value As DataSet)
            GrpDdoVlrVndTet = Value
        End Set
    End Property

    Public Function funXMLArray(ByVal sLngMcoExt As String, Optional ByVal bIsrTod As Boolean = False) As ArrayList
        ' Retorna um ArrayList apartir de um XML
        ' Obs.: Caso seja passado o parametro bIsrTod sera incluido o valor Todos no comeco do array
        Dim oGrpDdo As New DataSet
        Dim oObeLin As DataRow
        Dim aLst As New ArrayList
        If sLngMcoExt = "" Then
            Return aLst
        End If
        If bIsrTod Then
            aLst.Add("Todos")
        End If
        With oGrpDdo
            .ReadXml(New System.IO.StringReader(sLngMcoExt))
            If .Tables.Count > 0 Then
                For Each oObeLin In .Tables(0).Rows
                    aLst.Add(CType(oObeLin(0), String).Trim + " - " + CType(oObeLin(1), String).Trim)
                Next
            End If
        End With
        Return (aLst.Clone)
    End Function

    Public Function funPegaCodigo(ByVal s As String) As String
        Dim iPos = InStr(s, "-")
        If iPos > 0 Then
            Return s.Substring(0, iPos - 1).Trim
        Else
            Return s
        End If
    End Function

    Public Function funLstTxt(ByRef lst As System.Web.UI.WebControls.DropDownList) As String
        ' Retorna o codigo de um listbox
        ' Caso o retorno seja "todos", retorna string vazia
        Dim sVlrRet As String
        sVlrRet = funPegaCodigo(lst.SelectedItem.Text)
        Return IIf(sVlrRet.Trim.ToLower.Equals("todos"), "", sVlrRet)
    End Function

    Public Function funRetTxtSemCod(ByVal lst As System.Web.UI.WebControls.DropDownList) As String
        ' Retorna o texto de um listbox sem o codigo
        Return (lst.SelectedItem.Text.Substring(lst.SelectedItem.Text.IndexOf("-") + 2))
    End Function

    Public Function funGrpDdoGetIndexColumn(ByRef GrpDdo As System.Web.UI.WebControls.DataGridColumnCollection, _
                                            ByVal sCol As String) As Integer
        Dim oCol As System.Web.UI.WebControls.DataGridColumn
        For Each oCol In GrpDdo
            If oCol.SortExpression = sCol Then
                Return GrpDdo.IndexOf(oCol)
            End If
        Next
    End Function

    Public Sub funGrpDdoClearImage(ByVal GrpDdo As System.Web.UI.WebControls.DataGrid, _
                                    ByVal column As String)
        Dim pos As Integer
        Dim headerText As String

        pos = funGrpDdoGetIndexColumn(GrpDdo.Columns, column)
        headerText = GrpDdo.Columns.Item(pos).HeaderText

        If InStr(headerText, "<img") Then
            GrpDdo.Columns.Item(pos).HeaderText = headerText.Substring(0, InStr(headerText, "<img") - 1)
        End If

    End Sub

    Public Sub funGrpDdoPutImage(ByVal GrpDdo As System.Web.UI.WebControls.DataGrid, _
                                 ByVal column As String, ByVal order As String)
        Dim pos As Integer
        funGrpDdoClearImage(GrpDdo, column)
        pos = funGrpDdoGetIndexColumn(GrpDdo.Columns, column)
        With GrpDdo.Columns.Item(pos)
            If order.Equals("ASC") Then
                .HeaderText = .HeaderText + "<img src='images/ArqImgTop.gif' border='0'>"
            Else
                .HeaderText = .HeaderText + "<img src='images/ArqImgIfo.gif' border='0'>"
            End If
        End With
    End Sub

    Public Function funXMLDS(ByVal s As String) As DataSet
        Dim ds As New DataSet
        If s = Nothing Then
            Return Nothing
        End If
        ds.ReadXml(New System.IO.StringReader(s))
        Return ds
    End Function

    Public Function funSetErr(ByVal sErr As String) As String
        Dim s As New System.Text.StringBuilder
        s.Append("<script language='javascript' event='onreadystatechange' for='document'>")
        s.Append("  if (readyState == 'complete') {")
        If sErr.Trim = "INICAD" Then
            s.Append("    funIniSelBtnEnv(); ")
            s.Append("    document.getElementById('UsrConCab1_TitErr').innerText = '';")
        Else
            s.Append("    document.getElementById('UsrConCab1_TitErr').innerText = '" + sErr.Replace("'", "") + "';")
        End If
        s.Append("}</script>")
        Return s.ToString

    End Function

    Public Function funXMLToList(ByVal sLngMcoExt As String, ByVal iColCod As Integer, ByVal iColDes As Integer) As ArrayList
        Dim oGrpDdo As New DataSet
        Dim oObeLin As DataRow
        Dim aLst As New ArrayList

        If sLngMcoExt = "" Then
            Return aLst
        End If
        With oGrpDdo
            .ReadXml(New System.IO.StringReader(sLngMcoExt))
            If .Tables.Count > 0 Then
                For Each oObeLin In .Tables(0).Rows
                    If .Tables(0).Columns.Count > 1 Then
                        aLst.Add(CType(oObeLin(iColCod), String).Trim + " - " + CType(oObeLin(iColDes), String).Trim)
                    Else
                        aLst.Add(CType(oObeLin(iColCod), String).Trim)
                    End If
                Next
            End If
        End With
        Return (aLst.Clone)
    End Function

    Public Function funXMLToDataSet(ByVal sLngMcoExt As String, ByVal iColCod As Integer, ByVal iColDes As Integer, ByVal cPos As Char) As DataSet
        Dim oGrpDdo As New DataSet
        Dim oObeLin As DataRow
        Dim iRegistro As Integer

        If sLngMcoExt = "" Then
            Return Nothing
        End If

        With oGrpDdo
            .ReadXml(New System.IO.StringReader(sLngMcoExt))
            iRegistro = 0
            For Each oObeLin In .Tables(0).Rows
                If (.Tables(0).Columns.Count > 1) And (.Tables(0).Rows.Count > 0) Then
                    If cPos = "D" Then
                        .Tables(0).Rows(iRegistro)(iColDes) = CType(oObeLin(iColDes), String).Trim & " - " & CType(oObeLin(iColCod), String).Trim
                    ElseIf cPos = "C" Then
                        .Tables(0).Rows(iRegistro)(iColDes) = CType(oObeLin(iColCod), String).Trim & " - " & CType(oObeLin(iColDes), String).Trim
                    ElseIf cPos = "3" And .Tables(0).Columns.Count >= 3 Then
                        .Tables(0).Rows(iRegistro)(iColDes) = CType(oObeLin(iColCod), String).Trim.PadLeft(5, "0") & "-" & CType(oObeLin(iColCod + 2), String).Trim & " - " & CType(oObeLin(iColCod + 1), String).Trim
                    End If
                Else : Exit For
                End If
                iRegistro = iRegistro + 1
            Next
        End With
        Return oGrpDdo
    End Function

    'Função que modifica o texto colocando todas as letras em maiusculo e tirando acentos
    Public Function FunVldTxt(ByVal s As String) As String
        s = s.ToUpper
        s = s.Replace("Á", "A").Replace("À", "A").Replace("Ã", "A").Replace("Ä", "A").Replace("Â", "A")
        s = s.Replace("É", "E").Replace("È", "E").Replace("Ë", "E")
        s = s.Replace("Í", "I").Replace("Ì", "I").Replace("Ï", "I")
        s = s.Replace("Ó", "O").Replace("Ò", "O").Replace("Õ", "O").Replace("Ö", "O").Replace("Ô", "O")
        s = s.Replace("Ú", "U").Replace("Ù", "U").Replace("Ü", "U").Replace("Û", "U")
        s = s.Replace("Ç", "C")
        s = s.Replace("´", "").Replace("`", "").Replace("~", "").Replace("^", "")
        s = s.Replace("'", "").Replace("\", "").Replace("/", "")
        Return s
    End Function
    '  * Função que realiza um parse em uma data no formato DD/MM/AAAA para AAAA-MM-DD
    '  * para inserção no banco de dados
    '
    '  * @author Gabriel Pereira Borges
    '  *
    '  * @param dat Data a ser formatada
    '  * @return String representando a data no formato AAAA-MM-DD
    '  */
    Public Function funFrmDatIsr(ByRef dat As eWorld.UI.CalendarPopup) As String
        Dim sFrmDatIsr As String
        Dim sTmp As String

        sTmp = dat.SelectedDate.Month.ToString
        If sTmp.Length = 1 Then
            sTmp = "0" + sTmp
        End If
        sFrmDatIsr = dat.SelectedDate.Year.ToString + "-" + sTmp
        sTmp = dat.SelectedDate.Day.ToString
        If sTmp.Length = 1 Then
            sTmp = "0" + sTmp
        End If
        sFrmDatIsr = sFrmDatIsr + "-" + sTmp

        Return sFrmDatIsr
    End Function

    Public Function funCalcDigMod11(ByVal Dado As String, ByVal NumDig As Integer, ByVal LimMult As Integer) As String
        ' Retorna o(s) NumDig Dígito(s) de Controle Módulo 11 do Dado,
        ' limitando o Valor de Multiplicação em LimMult:
        '
        ' Números Comuns:
        '               NumDig  LimMult
        '       CGC     2       9
        '       CPF     2       12
        '       C/C     1       7

        Dim Mult As Integer
        Dim i As Integer, n As Integer
        Dim Soma As Long

        For n = 1 To NumDig
            Soma = 0
            Mult = 2
            For i = Len(Dado) To 1 Step -1
                Soma = Soma + (Mult * Val(Mid$(Dado, i, 1)))
                Mult = Mult + 1
                If Mult > LimMult Then Mult = 2
            Next i
            Soma = (Soma * 10) Mod 11
            Dado = Dado + Right$(Str$(Soma), 1)
        Next n
        funCalcDigMod11 = Right$(Dado, NumDig)
    End Function

    Public Function funTiraMascara(ByVal Dado As String)
        Dim sAux As String
        Dim iIndice As Integer
        sAux = ""
        For iIndice = 1 To Dado.Length
            Select Case Mid$(Dado, iIndice, 1)
                Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    sAux = sAux & Mid$(Dado, iIndice, 1)
            End Select
        Next
        Return sAux
    End Function

    Public Function funVerificaCPF(ByVal Dado As String)
        ' Devolve True se o CPF Dado está Correto:

        Dim s As String
        Dim result As Integer

        result = False
        If Len(Dado) = 14 Then
            s = Left$(Dado, 3) + Mid$(Dado, 5, 3) + Mid$(Dado, 9, 3)
            If Right$(Dado, 2) = funCalcDigMod11(s, 2, 12) Then
                result = True
            End If
        End If

        funVerificaCPF = result
    End Function

    Public Function funVerificaINSS(ByVal Dado As String) As Boolean
        Dim Soma, Resto As Double
        Dim Digito As Integer

        If Len(Dado) <> 11 Then
            'Número de dígitos inválido
            funVerificaINSS = False
        Else
            Soma = Mid(Dado, 1, 1) * 3 + Mid(Dado, 2, 1) * 2 + Mid(Dado, 3, 1) * 9 + Mid(Dado, 4, 1) * 8 + Mid(Dado, 5, 1) * 7 + Mid(Dado, 6, 1) * 6 + Mid(Dado, 7, 1) * 5 + Mid(Dado, 8, 1) * 4 + Mid(Dado, 9, 1) * 3 + Mid(Dado, 10, 1) * 2
            Resto = Int(Soma / 11)
            Resto = Soma - (Resto * 11)
            Resto = 11 - Resto
            If Resto > 9 Then
                Resto = 0
            Else
                Digito = 1
            End If
            If Resto = Mid(Dado, 11, 1) Then
                Digito = 0
                'Digito OK
                funVerificaINSS = True
            Else
                Digito = 1
                'Digito Errado
                funVerificaINSS = False
            End If
        End If
    End Function

    Public Function funMascaraCPF(ByVal Dado As String) As String
        Dado = Right("00000000000" & Dado, 11)
        funMascaraCPF = Mid(Dado, 1, 3) & "." & Mid(Dado, 4, 3) & "." & Mid(Dado, 7, 3) & "-" & Mid(Dado, 10, 2)
    End Function

    Public Function funMascaraCEP(ByVal Dado As String) As String
        Dado = Right("0000000000" & Dado, 8)
        funMascaraCEP = Mid(Dado, 1, 2) & "." & Mid(Dado, 3, 3) & "-" & Mid(Dado, 6, 3)
    End Function

    Public Function funUsr() As String
        funUsr = Split(System.Security.Principal.WindowsIdentity.GetCurrent.Name.ToString, "\")(1)
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Formata numero.
    ''' </summary>
    ''' <param name="Dado">String numerica a ser formatada</param>
    ''' <returns>String numerica formatada.</returns>
    ''' <remarks>
    ''' Retorna o numero fornecido, segundo formatacao x,xxx.xx
    ''' </remarks>
    ''' <history>
    ''' 	[Getulio de Morais Pereira]	12/28/2004	Modificacao na formatacao
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function funFrmNumIsr(ByVal Dado As String) As String
        Dim sAux As String
        sAux = Dado.Trim.Replace(".", "")  REM 1.234.567,89 --> 1234567,89
        Return sAux.Replace(",", ".")      REM 1234567,89   --> 1234567.89
        'sAux = Dado.Trim
        'Return sAux.Replace(".", "+").Replace(",", ".").Replace("+", ",")
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Formata valores numericos.
    ''' </summary>
    ''' <param name="Dado">String contendo o valor numerico a ser formatado.</param>
    ''' <returns>Valor numerico formatado.</returns>
    ''' <remarks>
    ''' Fromata o valor numerico passado como parametro segundo o padrao "Portugues do Brasil", <BR>
    ''' independentemente da configuracao do Sistema Operacional hospedeiro da aplicacao.
    ''' </remarks>
    ''' <history>
    ''' 	[Getulio de Morais Pereira]	1/15/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function funFrmNum(ByVal Dado As String) As String
        Dim currCult As System.Globalization.CultureInfo
        Dim newCult As System.Globalization.CultureInfo
        Dim value As Double
        Dim sAux As String

        currCult = System.Threading.Thread.CurrentThread.CurrentCulture  REM armazena a cultura atual
        newCult = New System.Globalization.CultureInfo("en-US", False)          REM forca para ser en-US
        System.Threading.Thread.CurrentThread.CurrentCulture = newCult
        Try
            sAux = funFrmNumIsr(Dado.Trim)
            value = CType(sAux, Double)       REM ponto de possivel disparo de excessoes
            sAux = Format(value, "##,##0.00")      REM formata o valor, segundo o padrao "Ingles Norte Americano"
            'sAux = String.Format("{0:N2}", value)
            sAux = sAux.Replace(".", "+").Replace(",", ".").Replace("+", ",") REM Muda a formatacao da string para o padrao "Portugues do Brasil"
        Catch ex As Exception
            ' nao trata excessoes, forcando o retorno como string vazia (sAux = nothing)
        Finally
            System.Threading.Thread.CurrentThread.CurrentCulture = currCult  REM retorna ao estado anterior
            currCult = Nothing
            newCult = Nothing
            value = Nothing
        End Try

        Return sAux
    End Function

    Public Function funValidaData(ByVal sData As String) As String
        Dim sAux, sDia, sMes, sAno As String
        Dim dAuxData As DateTime
        sAux = funTiraMascara(sData)

        Try
            If sAux.Trim.Length <> 8 Then
                Throw New Exception("Tamanho inválido")
            End If
            sDia = sAux.Substring(0, 2)
            sMes = sAux.Substring(2, 2)
            sAno = sAux.Substring(4, 4)
            If CInt(sAno) < 1900 Then
                Throw New Exception("Ano inválido")
            End If
            dAuxData = CDate(sAno & "-" & sMes & "-" & sDia)
            Return dAuxData.ToString
        Catch ex As Exception
            Return ""
        End Try
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Formata uma string numerica, segundo padrao pt-BR.
    ''' </summary>
    ''' <param name="str">String numerica a ser formatada.</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[gperei]	1/29/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function funFrmStrNro(ByVal str As String) As String
        Dim aux As String = ""

        If (str Is Nothing) Or (str = "") Or (Not IsNumeric(str)) Then
            str = "0"
        End If
        Dim tmp As Char()
        tmp = str.Trim.ToCharArray
        ' Elimina "0"s a esquerda
        Dim i As Integer = 0
        While (i < tmp.Length() - 1) And (tmp(i) = "0")
            tmp(i) = " "
            i = i + 1
        End While
        aux = tmp
        aux = aux.Trim

        ' Insere separador de milhares (".")
        'Dim MyCulture As New System.Globalization.CultureInfo("pt-BR")
        'Dim dec As Decimal = 0D
        'dec = Decimal.Parse(aux)
        'aux = dec.ToString("N", MyCulture)

        Return aux
    End Function



End Class


